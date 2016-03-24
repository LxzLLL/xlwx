using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Web;
using System.Net;
using System.Net.Security;
using System.Security.Cryptography.X509Certificates;
using System.IO;
using System.Runtime.Serialization;
using Newtonsoft.Json;
using System.Xml.Linq;

using XLWXLibrary.WXEntity.XmlEntity;
using XLToolLibrary.Utilities;

namespace XLWXLibrary.WXHandler
{
    /// <summary>
    /// 作者：Arvin
    /// 日期：2016/1/28 11:02:28
    /// 描述：微信处理基类
    /// Cache["***"]为缓存的微信平台验证类，key为WxPlatFormTypeEnum中类型
    /// </summary>
    public class WXHandlerBase:IWXHandler
    {
        /// <summary>
        /// 令牌
        /// </summary>
        public string AccessToken 
        {
            get
            {
                return this.GetAccessToken();
            }
        }
        /// <summary>
        /// 当前验证实体
        /// </summary>
        public Credential CurrentCredential
        {
            get
            {
                return this.GetCredential();
            }
        }

        
        /// <summary>
        /// 微信平台类型
        /// </summary>
        protected WxPlatFormTypeEnum _wxPlatFormTypeEnum = WxPlatFormTypeEnum.None;

        /// <summary>
        /// 凭证xml路径
        /// </summary>
        private static string strFilePath = HttpRuntime.AppDomainAppPath + @"bin\xmlConfig\Credential.xml";
        /// <summary>
        /// xml实体
        /// </summary>
        protected XmlHelper<string> _xo = new XmlHelper<string>( strFilePath );
        
        /// <summary>
        /// 获取AccessToken
        /// </summary>
        /// <param name="credential">验证实体类（公众号与企业号验证实体类的抽象）</param>
        /// <returns></returns>
        private string GetAccessToken()
        {
            string strAccessToken = string.Empty;
            if ( this._wxPlatFormTypeEnum.Equals(WxPlatFormTypeEnum.None) )
            {
                return strAccessToken;
            }
            //只有 存在AccessToken且未过期 则返回AccessToken，否则重新获取
            return this.CurrentCredential.TokenInfo.AccessToken;
        }

        /// <summary>
        /// 运行函数，子类必须实现
        /// </summary>
        public virtual void ProcessRequest()
        {
            
        }

        #region  私有方法
        /// <summary>
        /// 获取凭证
        /// </summary>
        /// <returns></returns>
        private Credential GetCredential()
        {
            //1.获取缓存
            //2.如果为null则获取xml
            //3.如果xml中过期则根据Credential重新获取AccessToken
            Credential credential = null;
            List<Credential> listCredential = new List<Credential>();
            if(CacheHelper.GetCache(this._wxPlatFormTypeEnum.ToString())==null)
            {
                listCredential = GetCredentialsFromXml();
                //将xml中没有过期的Credential写入Cache
                if(listCredential.Count>0)
                {
                    foreach(Credential c in listCredential)
                    {
                        if(c.WxPlatFormType == this._wxPlatFormTypeEnum.ToString())
                        {
                            //判断是否过期
                            if ( !c.TokenInfo.IsExpired )
                            {
                                DateTime dtExpired = new ConvertDateTime().String2DataTime( c.TokenInfo.GetTokenDateTime ).AddSeconds( double.Parse( c.TokenInfo.ExpiresIn ) - double.Parse( c.TokenInfo.EarlyEnd ) );
                                //设置cache过期时间
                                CacheHelper.SetCache( c.WxPlatFormType, c, dtExpired );
                            }
                            break;
                        } 
                    } //end for foreach
                }  //end for if
            }
            object objCredential  = CacheHelper.GetCache( this._wxPlatFormTypeEnum.ToString() );

            //从xml中也为找到AccessToken则需要请求获取
            if(objCredential==null)
            {
                //获取后写入xml，cache 并返回credential
                credential = RequestAccessToken( listCredential );
            }
            else
            {
                credential = ( Credential )objCredential;
            }
            return credential;
        }

        /// <summary>
        /// 请求AccessToken
        /// </summary>
        /// <param name="credentials">xml的credential凭证列表</param>
        private Credential RequestAccessToken( List<Credential> credentials )
        {
            //获取要请求的Credential类（公众号还是企业号类型）
            Credential credential = GetCredentialsFromXmlByType();
            
            //请求
            //HttpWebRequest webRequest;
            string strUrl = credential.RequestInfo.Url;
            if(credential.RequestInfo.RequestType.ToLower()=="get")
            {
                string strParams=string.Empty;
                //组装参数到url上
                foreach(string str in credential.RequestInfo.QueryParam)
                {
                    string[] strKeyValue = str.Split( ':' );
                    if(strKeyValue.Length>1)
                    {
                        strParams += strKeyValue[ 0 ] + "=" + strKeyValue[ 1 ]+"&";
                    }
                    else
                    {
                        strParams += strKeyValue[ 0 ] + "=" + strKeyValue[ 0 ] + "&";
                    }
                }
                strUrl += "?" + strParams.TrimEnd( '&' );
            }
            //请求
            HttpItem hi = new HttpItem();
            hi.URL = strUrl;
            hi.Method = credential.RequestInfo.RequestType;
            if ( credential.RequestInfo.ProtocolType.ToLower() == "https" )
            {
                hi.IsTrustCertificate = true;
            }
            hi.Encoding = Encoding.UTF8;
            HttpHelper hh = new HttpHelper();
            HttpResult hr = hh.GetHtml( hi );
            string strContext = hr.Html;
            //转换返回结果为实体
            WxAccessToken wxat = JsonConvert.DeserializeObject<WxAccessToken>( strContext );
            //写入xml
            this.WriteXmlAccessToken( wxat );
            //写入cache
            Credential c =  GetCredentialsFromXmlByType();
            DateTime dtExpired = new ConvertDateTime().String2DataTime( c.TokenInfo.GetTokenDateTime ).AddSeconds( double.Parse( c.TokenInfo.ExpiresIn ) - double.Parse( c.TokenInfo.EarlyEnd ) );
            CacheHelper.SetCache( c.WxPlatFormType, c, dtExpired );
            //返回Credential
            return c;
        }

        /// <summary>
        /// 写入xml元素文本
        /// </summary>
        /// <param name="wxat"></param>
        private void WriteXmlAccessToken(WxAccessToken wxat)
        {
            List<XElement> listEleRtn = this._xo.GetXEleFromStrFormat( "Credentials.Credential" );
            if(listEleRtn==null || listEleRtn.Count<=0)
            {
                return;
            }
            foreach(XElement xele in listEleRtn)
            {
                string strWxPlatFormType = xele.Element( "WxPlatFormType" ).Value;
                //如果与平台相同，则写入xml
                if(strWxPlatFormType.Equals(this._wxPlatFormTypeEnum.ToString()))
                {
                    xele.Element( "TokenInfo" ).Element( "access_token" ).SetValue( wxat.access_token );
                    xele.Element( "TokenInfo" ).Element( "expires_in" ).SetValue( wxat.expires_in );
                    xele.Element( "TokenInfo" ).Element( "gettoken_dt" ).SetValue( DateTime.Now.ToString( "yyyy-MM-dd HH:mm:ss" ) );
                    this._xo.XElement.Save( strFilePath );
                    break;
                }
            }
        }

        /// <summary>
        /// 从xml中获取Credential列表
        /// </summary>
        /// <returns></returns>
        private List<Credential> GetCredentialsFromXml()
        {            
            List<Credential> listCredential = this._xo.GetObject<Credential>( "Credentials.Credential" );
            return listCredential;
        }

        /// <summary>
        /// 根据平台类型从xml中获取Credential
        /// </summary>
        /// <returns></returns>
        private Credential GetCredentialsFromXmlByType()
        {
            Credential credential = new Credential();
            List<Credential> listCredential = GetCredentialsFromXml();
            foreach ( Credential c in listCredential )
            {
                if ( c.WxPlatFormType == this._wxPlatFormTypeEnum.ToString() )
                {
                    credential = c;
                    break;
                }
            }
            return credential;
        }

        #endregion
    }

    /// <summary>
    /// 微信平台类型
    /// </summary>
    public enum WxPlatFormTypeEnum
    {
        None = -1,
        GZ=0,
        QY=1
    }
    /// <summary>
    /// 微信返回AccessToken实体结构
    /// </summary>
    public class WxAccessToken
    {
        public string access_token { get; set; }
        public string expires_in { get; set; }
    }
}
