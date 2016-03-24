using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Web;
using System.Reflection;


using XLWXLibrary.WXEntity.XmlEntity;
using XLWXLibrary.WXHandler;
using XLWXLibrary.WXHandler.Cryptography;
using XLToolLibrary.Utilities;
namespace XLWXLibrary.WXValidity
{
    /// <summary>
    /// 作者：Arvin
    /// 日期：2016/1/18 13:55:04
    /// 描述：微信有效性验证
    ///           直接嵌入请求处理中，判断为get且有echostr（暂未实现）
    /// </summary>
    public class VerifyValidity
    {
        private HttpRequest _request = null;
        public VerifyValidity( HttpRequest request )
        {
            this._request = request;
        }

        /// <summary>
        /// 公众号返回验证结果
        /// </summary>
        /// <returns></returns>
        public string GetGZValidityResult()
        {
            GZValidityEntity validityEntity = Request2Entity( this._request, new GZValidityEntity() );
            if ( validityEntity == null )
            {
                return "";
            }

            WXGZConfigEntity gzConfig = XmlToEntity.GetGZConfig();

            string[] arrValidity = { gzConfig.Token, validityEntity.Timestamp, validityEntity.Nonce };
            Array.Sort( arrValidity );
            string strJoin = string.Join( "", arrValidity );
            string strEncryption = ShaHelper.StrSha1Lower( strJoin );
            if ( strEncryption.Equals( validityEntity.Signature ) )
            {
                return validityEntity.echostr;
            }
            else
            {
                return "";
            }
        }

        /// <summary>
        /// 企业号返回验证结果
        /// </summary>
        /// <returns></returns>
        public string GetQYValidityResult()
        {
            QYValidityEntity validityEntity = Request2Entity( this._request, new QYValidityEntity() );
            if ( validityEntity == null )
            {
                return "";
            }
            WXQYConfigEntity qyConfig = XmlToEntity.GetQYConfig();
            WXBizMsgCrypt wxcpt = new WXBizMsgCrypt( qyConfig.Token, qyConfig.EncodingAESKey, qyConfig.CorpID );
            int ret = 0;
            string sEchoStr = "";
            ret = wxcpt.VerifyURL( validityEntity.Msg_Signature, validityEntity.Timestamp, validityEntity.Nonce, validityEntity.echostr, ref sEchoStr );
            if ( ret != 0 )
            {
                //System.Console.WriteLine( "ERR: VerifyURL fail, ret: " + ret );
                return "";
            }
            return sEchoStr;
        }

        /// <summary>
        /// 根据HttpRequest，返回泛型T对象，
        /// </summary>
        /// <typeparam name="T"></typeparam>
        /// <param name="request"></param>
        /// <param name="t"></param>
        /// <returns></returns>
        public static T Request2Entity<T>(HttpRequest request, T t)
        {
            if ( t == null )
            {
                return t;
            }
            T tRtn = tRtn = ( T )Activator.CreateInstance( typeof( T ) );
            Type type = tRtn.GetType();
            System.Collections.Specialized.NameValueCollection nvc = request.Params;
            PropertyInfo[] pis = type.GetProperties();
            foreach(PropertyInfo pi in pis )
            {
                var value = nvc.Cast<string>()
                    .Where( key => key.ToUpper() == pi.Name.ToUpper() )
                    .Select( key => nvc[ key ] );
                if(value.Count()>0)
                {
                    string strValue = value.First().ToString();
                    pi.SetValue( tRtn, strValue );
                }
            }
            return tRtn;
        }

    }

    /// <summary>
    /// 微信返回的有效性实体
    /// </summary>
    public class ValidityEntity
    {
        
        /// <summary>
        /// 时间戳
        /// </summary>
        public string Timestamp { get; set; }
        /// <summary>
        /// 随机数
        /// </summary>
        public string Nonce { get; set; }
        /// <summary>
        /// 随机字符串
        /// </summary>
        public string echostr { get; set; }
    }

    /// <summary>
    /// 公众号验证实体
    /// </summary>
    public class GZValidityEntity : ValidityEntity
    {
        /// <summary>
        /// 微信公众号加密签名
        /// </summary>
        public string Signature { get; set; }
    }

    /// <summary>
    /// 企业号验证实体
    /// </summary>
    public class QYValidityEntity : ValidityEntity
    {
        /// <summary>
        /// 微信企业号加密签名
        /// </summary>
        public string Msg_Signature { get; set; }
    }
}
