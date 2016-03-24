using System;
using System.Collections.Generic;
using System.Text;

using XLWXLibrary.WXEntity;
namespace XLWXLibrary.WXHandler.ActiveCallProcess
{
    /// <summary>
    /// 作者：Arvin
    /// 日期：2016/2/18 11:12:32
    /// 描述：主动调用处理基类
    /// </summary>
    public class ActiveProcess
    {
        protected WxPlatFormTypeEnum _wxPlatType = WxPlatFormTypeEnum.None;
        /// <summary>
        /// 构造需要传递给主动请求的ActiveCallBaseEntity对象
        /// </summary>
        /// <param name="url">完整的url，不带参数</param>
        /// <param name="wxPlatType">平台类型</param>
        /// <param name="strJson">传递的json数据</param>
        /// <param name="strMethod">请求方式，默认post</param>
        /// <param name="dictParams">url上的除access_token参数</param>
        /// <returns></returns>
        protected ActiveCallBaseEntity GetEntityByAction( string url, string strJson, Dictionary<string, string> dictParams = null, string strMethod = "post" )
        {
            ActiveCallBaseEntity entity = new ActiveCallBaseEntity();
            string strUrl = string.Empty;
            strUrl = url;
            if ( this._wxPlatType == WxPlatFormTypeEnum.QY )
            {
                entity.AccessToken = new WXQY.WXQYHandler().AccessToken;
            }
            else if ( this._wxPlatType == WxPlatFormTypeEnum.GZ )
            {
                entity.AccessToken = new WXGZ.WXGZHandler().AccessToken;
            }
            entity.Url = strUrl;
            entity.Content = strJson;
            entity.Params = dictParams;
            entity.Method = strMethod;
            entity.PostEncoding = Encoding.UTF8;
            return entity;
        }
    }
}
