using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace XLWXLibrary.WXHandler.WXGZ
{
    /// <summary>
    /// 作者：Arvin
    /// 日期：2016/1/29 11:35:38
    /// 描述：公众号处理handler
    /// </summary>
    public class WXGZHandler:WXHandlerBase
    {
        public WXGZHandler()
        {
            //定义平台类型
            base._wxPlatFormTypeEnum = WxPlatFormTypeEnum.GZ;
        }

        /// <summary>
        /// 实现接口函数
        /// </summary>
        public override void ProcessRequest()
        {
            base.ProcessRequest();
            //1、调用并传递参数给message
            //2、message反射工厂构造对应的实体进行处理
            //string str = base.AccessToken;
            //if(string.IsNullOrEmpty(str))
            //{
            //    return;
            //}
            //HttpResponse response  = HttpContext.Current.Response;
            //response.Write( str );
            //response.End();
            //response.Flush();
        }

    }
}
