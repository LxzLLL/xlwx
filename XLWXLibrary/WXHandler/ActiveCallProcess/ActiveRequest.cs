using System;
using System.Text;
using System.Collections.Generic;

using XLWXLibrary.WXEntity;
using XLToolLibrary.Utilities;
namespace XLWXLibrary.WXHandler.ActiveCallProcess
{
    /// <summary>
    /// 作者：Arvin
    /// 日期：2016/2/17 17:52:00
    /// 描述：主动处理的请求类
    /// </summary>
    public class ActiveRequest
    {
        /// <summary>
        /// 发送请求，并获取回复
        /// </summary>
        /// <param name="entity"></param>
        /// <returns></returns>
        public static string SendRequest( ActiveCallBaseEntity entity )
        {
            string strResult = string.Empty;
            if(entity==null)
            {
                return strResult;
            }
            HttpItem hi = new HttpItem();
            hi.URL = ActiveRequest.UrlProcess( entity );
            if ( entity.Protocol.ToLower() == "https" )
            {
                hi.IsTrustCertificate = true;
            }
            hi.Method = entity.Method;
            hi.Postdata = entity.Content;
            hi.Encoding = Encoding.UTF8;
            hi.PostEncoding = entity.PostEncoding;
            HttpHelper hh = new HttpHelper();
            HttpResult hr = hh.GetHtml( hi );
            strResult = hr.Html;
            return strResult;
        }

        /// <summary>
        /// Url与参数的组装
        /// </summary>
        /// <param name="entity">ActiveCallBaseEntity实例</param>
        /// <returns></returns>
        private static string UrlProcess(ActiveCallBaseEntity entity)
        {
            string strUrl = string.Empty;
            if ( entity == null )
            {
                return strUrl;
            }
            StringBuilder sbUrl = new StringBuilder();
            sbUrl.Append( entity.Url ).Append( "?access_token="+entity.AccessToken );
            if ( entity.Params != null && entity.Params.Count > 0 )
            {
                foreach ( KeyValuePair<string,string> kvItem in entity.Params )
                {
                    sbUrl.Append( "&" + kvItem.Key + "=" + kvItem.Value );
                }
            }
            strUrl = sbUrl.ToString();
            return strUrl;
        }

    }
}
