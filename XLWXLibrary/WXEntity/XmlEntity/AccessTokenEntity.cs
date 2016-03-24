using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Xml.Serialization;
using XLToolLibrary.Utilities;

namespace XLWXLibrary.WXEntity.XmlEntity
{
    /// <summary>
    /// 作者：Arvin
    /// 日期：2016/1/21 14:55:20
    /// 描述：微信访问令牌实体
    /// </summary> 
    //public class AccessTokenEntity
    //{
    //    /// <summary>
    //    /// 过期时间字段
    //    /// </summary>
    //    private DateTime? _expiresDateTime = null;
    //    /// <summary>
    //    /// 有效时间字段
    //    /// </summary>
    //    private int _expiresIn = 0;
    //    /// <summary>
    //    /// 提前结束时间字段（默认10分钟）
    //    /// </summary>
    //    private int _earlyEnd = 10*60;


    //    /// <summary>
    //    /// 提前结束时间
    //    /// </summary>
    //    public int EarlyEnd
    //    {
    //        get
    //        {
    //            return _earlyEnd;
    //        }
    //        set
    //        {
    //            _earlyEnd = value;
    //        }
    //    }
    //    /// <summary>
    //    /// access_token
    //    /// </summary>
    //    public string AccessToken { get; set; }
    //    /// <summary>
    //    /// 有效时间（秒）
    //    /// </summary>
    //    public int ExpiresIn
    //    {
    //        get
    //        {
    //            return this._expiresIn;
    //        }
    //        set
    //        {
    //            this._expiresIn = value;
    //            this._expiresDateTime = DateTime.Now.AddSeconds( value - this.EarlyEnd );
    //        }
    //    }
        
    //    /// <summary>
    //    /// 过期时间
    //    /// </summary>
    //    public DateTime? ExpiresDateTime
    //    {
    //        get
    //        {
    //            return this._expiresDateTime;
    //        }
    //        set
    //        {
    //            this._expiresDateTime = value;
    //        }
    //    }

    //    /// <summary>
    //    /// 初始化
    //    /// </summary>
    //    /// <param name="strAccessToken"></param>
    //    /// <param name="iExpiresIn"></param>
    //    public AccessTokenEntity( string strAccessToken, int iExpiresIn )
    //    {
    //        this.AccessToken = strAccessToken;
    //        this.ExpiresIn = iExpiresIn;
    //    }
        
    //}


    /// <summary>
    /// 验证实体类
    /// </summary>
   [XmlRoot( "Credential" )]
    public class Credential
    {
        [XmlElement( "WxPlatFormType" )]
       public string WxPlatFormType { get; set; }
        [XmlElement( "RequestInfo" )]
        public RequestInfo RequestInfo { get; set; }
        [XmlElement( "TokenInfo" )]
        public Token TokenInfo { get; set; }

        public override string ToString()
        {
            return this.WxPlatFormType + "," + this.RequestInfo.ToString() + "," + this.TokenInfo.ToString();
        }
    }

    /// <summary>
    /// 令牌类
    /// </summary>
    public class Token
    {
        [XmlElement( "access_token" )]
        public string AccessToken { get; set; }
        [XmlElement( "expires_in" )]
        public string ExpiresIn { get; set; }
        [XmlElement( "gettoken_dt" )]
        public string GetTokenDateTime { get; set; }
        [XmlElement( "early_end" )]
        public string EarlyEnd { get; set; }

        /// <summary>
        /// 是否过期，将过期及异常情况均作为过期处理
        /// 一般情况下，异常原因需要处理，此处未处理
        /// true：过期；false：未过期
        /// </summary>
        public bool IsExpired
        {
            get
            {
                this._isExpired = true;
                ConvertDateTime cdt = new ConvertDateTime();
                DateTime dt = cdt.String2DataTime( this.GetTokenDateTime );
                if ( cdt.IsSuccess )
                {
                    try
                    {
                        if(dt.AddSeconds( double.Parse( this.ExpiresIn ) - double.Parse( this.EarlyEnd ) )>DateTime.Now)
                        {
                            this._isExpired = false;
                        }
                    }
                    catch(Exception ex)
                    {
                        throw ex;
                    }
                }
                return this._isExpired;
            }
        }
        [NonSerialized]
        private bool _isExpired;

        public override string ToString()
        {
            return this.AccessToken + "," + this.ExpiresIn + this.GetTokenDateTime + "," + this.EarlyEnd;
        }
    }

    /// <summary>
    /// 请求信息类
    /// </summary>
    public class RequestInfo
    {
        [XmlElement( "url" )]
        public string Url { get; set; }
        [XmlElement( "protocoltype" )]
        public string ProtocolType { get; set; }
        [XmlElement( "type" )]
        public string RequestType { get; set; }
        [XmlArray( "param" ), XmlArrayItem( "item" )]
        public string[ ] QueryParam { get; set; }

        public override string ToString()
        {
            return this.Url + "," + this.ProtocolType + this.RequestType + "," + string.Join("+",this.QueryParam) ;
        }
    }

}
