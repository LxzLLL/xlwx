using System;
using System.Collections.Generic;

using XLWXLibrary.WXHandler;
using XLWXLibrary.WXHandler.ActiveCallProcess;
namespace XLWXLibrary.JSSDK
{
    /// <summary>
    /// 作者：Arvin
    /// 日期：2016/3/3 8:21:01
    /// 描述：JsApiTickets管理类
    /// </summary>
    public class JsApiTicketsManager:ActiveProcess
    {
        public JsApiTicketsManager( WxPlatFormTypeEnum platType)
        {
            this._wxPlatType = platType;
        }

        /// <summary>
        /// 获取公众号或企业号的jsapi_tickets
        /// </summary>
        /// <returns>返回json数据</returns>
        public string GetJsApiTicketsJson()
        {
            string sJsApiTicketsJson = string.Empty;
            string sUrl = string.Empty;
            if(this._wxPlatType==WxPlatFormTypeEnum.QY)
            {
                sUrl = "https://qyapi.weixin.qq.com/cgi-bin/get_jsapi_ticket";
                sJsApiTicketsJson = ActiveRequest.SendRequest( this.GetEntityByAction( sUrl, "", null, "get" ) );
            }
            else if(this._wxPlatType == WxPlatFormTypeEnum.GZ)
            {
                sUrl = "https://api.weixin.qq.com/cgi-bin/ticket/getticket";
                Dictionary<string,string> dictParams = new Dictionary<string, string>() { { "type", "jsapi" } };
                sJsApiTicketsJson = ActiveRequest.SendRequest( this.GetEntityByAction( sUrl, "", dictParams, "get" ) );
            }
            return sJsApiTicketsJson;
        }
    }
}
