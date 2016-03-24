using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Web;
using System.Web.Routing;

namespace XLWXLibrary
{
    /// <summary>
    /// 作者：Arvin
    /// 日期：2016/1/14 18:38:01
    /// 描述：
    /// </summary>
    public class WXRouteHandler:IRouteHandler
    {
        public IHttpHandler GetHttpHandler(RequestContext requestContext)
        {
            return new WXHttpHandler( requestContext );
        }
    }
}
