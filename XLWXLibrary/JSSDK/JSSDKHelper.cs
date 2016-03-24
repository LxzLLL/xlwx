using System;
using System.Collections.Generic;
using System.Text;
using System.Web;
using System.Web.Script.Serialization;
using System.Linq;

using XLWXLibrary.WXEntity;
using XLWXLibrary.WXHandler;
using XLWXLibrary.WXHandler.ActiveCallProcess;
using XLToolLibrary.Utilities;
namespace XLWXLibrary.JSSDK
{
    /// <summary>
    /// 作者：Arvin
    /// 日期：2016/3/2 16:19:18
    /// 描述：微信JSSDK的帮助类
    /// </summary>
    public class JSSDKHelper
    {
        /// <summary>
        /// 获取TimesTamp
        /// </summary>
        /// <returns></returns>
        public static string GetTimesTamp()
        {
            return ConvertDateTime.GetTimeStamp();
        }

        /// <summary>
        /// 获取NonceStr
        /// </summary>
        /// <returns></returns>
        public static string GetNonceStr()
        {
            return RandomHelper.GenerateRandomNumber( 16 );
        }

        /// <summary>
        /// 获取JS-SDK权限验证的签名Signature
        /// </summary>
        /// <param name="jsapi_ticket">jsapi_ticket</param>
        /// <param name="noncestr">随机字符串(必须与wx.config中的nonceStr相同)</param>
        /// <param name="timestamp">时间戳(必须与wx.config中的timestamp相同)</param>
        /// <param name="url">当前网页的URL，不包含#及其后面部分(必须是调用JS接口页面的完整URL)</param>
        /// <returns></returns>
        public static string GetSignature( string jsapi_ticket, string noncestr, string timestamp, string url )
        {
            Dictionary<string, string> signData = new Dictionary<string, string>() { 
                {"noncestr",noncestr},
                {"jsapi_ticket",jsapi_ticket},
                {"timestamp",timestamp},
                {"url",url.IndexOf( "#" ) >= 0 ? url.Substring( 0, url.IndexOf( "#" ) ) : url }
            };
            var dataList = signData.ToList();
            //按照字段名的ASCII码从小到大排序（字典序）
            dataList.Sort( ( KeyValuePair<string, string> x, KeyValuePair<string, string> y ) => { return x.Key.CompareTo( y.Key ); } );
            //使用URL键值对的格式拼接成字符串
            var queryString = dataList.Aggregate( string.Empty, ( query, item ) => string.Concat( query, "&", item.Key, "=", item.Value ) ).TrimStart( '&' );

            //StringBuilder sb = new StringBuilder();
            //sb.Append( "jsapi_ticket=" ).Append( jsapi_ticket ).Append( "&" )
            // .Append( "noncestr=" ).Append( noncestr ).Append( "&" )
            // .Append( "timestamp=" ).Append( timestamp ).Append( "&" )
            // .Append( "url=" ).Append( url.IndexOf( "#" ) >= 0 ? url.Substring( 0, url.IndexOf( "#" ) ) : url );
            return ShaHelper.StrSha1Lower( queryString.ToString() );
        }
        /// <summary>
        /// 获取JsApiTicket
        /// </summary>
        /// <param name="platType">平台类型</param>
        /// <param name="cacheKey">缓存关键字</param>
        /// <returns></returns>
        private static string GetJsApiTicket(WxPlatFormTypeEnum platType,string cacheKey)
        {
            object result =CacheHelper.GetCache( cacheKey );
            if ( result == null )
            {
                try
                {
                    string sResult = new JsApiTicketsManager( platType ).GetJsApiTicketsJson();
                    JavaScriptSerializer serializer = new JavaScriptSerializer();
                    Dictionary<string, object> jsonObj = serializer.Deserialize<dynamic>( sResult );
                    if ( jsonObj.ContainsKey( "ticket" ) )
                    {
                        result = jsonObj[ "ticket" ].ToString();
                        CacheHelper.SetCache( cacheKey, result, DateTime.Now.AddSeconds( 7000 ) );
                    }
                    else
                    {
                        //为了程序正常运行，不抛出错误，可以记录日志
                        result = jsonObj[ "errmsg" ];
                        throw new Exception( result.ToString() );
                    }
                }
                catch(Exception ex)
                {
                    throw ex;
                }
            }
            return result.ToString();
            
        }

        /// <summary>
        /// 获取企业wx.config结构
        /// </summary>
        /// <param name="jsapi">jsapi组合（例如：JsApiEnum.scanQRCode|JsApiEnum.onMenuShareQQ）</param>
        /// <returns></returns>
        public static SignPackage GetQySignPackage(  QyJsApiEnum jsapi )
        {
            string sAppid = XmlToEntity.GetQYConfig().CorpID;
            string sJsapi_ticket = GetJsApiTicket( WxPlatFormTypeEnum .QY,"qy_jsapi_tikect");
            HttpContext httpcontext = System.Web.HttpContext.Current;
            string sUrl = httpcontext.Request.Url.AbsoluteUri;
            string sNonce = GetNonceStr();
            string sTimesTamp =  GetTimesTamp();
            string sSignature = GetSignature( sJsapi_ticket, sNonce, sTimesTamp, sUrl );
            SignPackage sp = new SignPackage()
            {
                debug = "true",
                appId = sAppid,
                timestamp = sTimesTamp,
                nonceStr = sNonce,
                signature = sSignature,
                jsApiList = jsapi.ToString().Replace( " ", "" ).Split( ',' )
            };
            return sp;
        }

        /// <summary>
        /// 获取公众号wx.config结构
        /// </summary>
        /// <param name="jsapi">jsapi组合（例如：JsApiEnum.scanQRCode|JsApiEnum.onMenuShareQQ）</param>
        /// <returns></returns>
        public static SignPackage GetGzSignPackage( GzJsApiEnum jsapi )
        {
            //string strAppid = XmlToEntity.
            string sAppid = XmlToEntity.GetGZConfig().AppID;
            string sJsapi_ticket = GetJsApiTicket( WxPlatFormTypeEnum.GZ, "gz_jsapi_tikect" );
            HttpContext httpcontext = System.Web.HttpContext.Current;
            string sUrl = httpcontext.Request.Url.AbsoluteUri;
            string sNonce = GetNonceStr();
            string sTimesTamp =  GetTimesTamp();
            string sSignature = GetSignature( sJsapi_ticket, sNonce, sTimesTamp, sUrl );
            SignPackage sp = new SignPackage()
            {
                debug = "true",
                appId = sAppid,
                timestamp = sTimesTamp,
                nonceStr = sNonce,
                signature = sSignature,
                jsApiList = jsapi.ToString().Replace( " ", "" ).Split( ',' )
            };
            return sp;
        }
    }
}
