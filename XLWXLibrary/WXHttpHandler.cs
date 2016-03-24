using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Web;
using System.Web.Handlers;
using System.Web.Routing;
using System.Reflection;

using XLWXLibrary.WXValidity;
using XLWXLibrary.WXEntity.XmlEntity;
using XLWXLibrary.WXHandler;
using XLToolLibrary.Utilities;

namespace XLWXLibrary
{
    /// <summary>
    /// 作者：Arvin
    /// 日期：2016/1/14 18:41:34
    /// 描述：HttpHandler，http转发WXHandler
    /// </summary>
    public class WXHttpHandler:IHttpHandler
    {
        /// <summary>
        /// 构造函数
        /// </summary>
        /// <param name="context"></param>
        public WXHttpHandler( RequestContext context )
        {
            ProcessRequest( context );
        }
        public bool IsReusable
        {
            get { return false; }
        }
        /// <summary>
        /// 处理请求
        /// </summary>
        /// <param name="context"></param>
        public void ProcessRequest(HttpContext context)
        {

        }
        
        /// <summary>
        /// 执行的http处理
        /// </summary>
        /// <param name="context"></param>
        public void ProcessRequest( RequestContext context )
        {
            string strUrlPath = GetUrlPath();
            
            //首次验证，请求方式为get且带echostr参数
            if ( context.HttpContext.Request.HttpMethod.ToLower() == "get" && !string.IsNullOrEmpty( context.HttpContext.Request.Params[ "echostr" ] ) )
            {
                Validity( XmlToEntity.GetRouteItems()[strUrlPath].WxPlatFormType );
                return;
            }
            //再获取一次Cache，如果再为空，则不处理
            Dictionary<string, RouteItemEntity> dictWxCache = XmlToEntity.GetRouteItems();
            if ( dictWxCache.Count > 0 )
            {
                //路由缓存中存在请求url的路径
                if(dictWxCache.Keys.Contains(strUrlPath))
                {
                    //反射获取类
                    IWXHandler iwxhandler = ( IWXHandler )Activator.CreateInstance( dictWxCache[ strUrlPath ].AssemblyName, dictWxCache[ strUrlPath ].ClassName).Unwrap();
                    iwxhandler.ProcessRequest();
                }
            }
        }

        /// <summary>
        /// 获取url的路径部分
        /// </summary>
        /// <returns></returns>
        private string GetUrlPath()
        {
            HttpRequest request = HttpContext.Current.Request;
            string strUrlPath = request.Url.AbsolutePath;
            return strUrlPath;
        }


        /// <summary>
        /// 微信域名验证
        /// </summary>
        public void Validity( string wxPlatType )
        {
            VerifyValidity vv = new VerifyValidity( HttpContext.Current.Request );
            string strResponse = string.Empty;
            //企业号验证
            if(wxPlatType == WxPlatFormTypeEnum.QY.ToString())
            {
                strResponse = vv.GetQYValidityResult();
            }
            else
            {
                strResponse = vv.GetGZValidityResult();
            }

            if ( !string.IsNullOrEmpty( strResponse ) )
            {
                HttpServerHelper.ResponseWrite( strResponse );
            }
        }
    }
}
