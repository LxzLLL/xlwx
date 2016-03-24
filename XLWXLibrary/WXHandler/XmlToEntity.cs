using System;
using System.Web;
using System.Collections.Generic;

using XLWXLibrary.WXEntity.XmlEntity;
using XLToolLibrary.Utilities;
namespace XLWXLibrary.WXHandler
{
    /// <summary>
    /// 作者：Arvin
    /// 日期：2016/2/19 11:34:44
    /// 描述：基于微信业务的xml处理
    /// </summary>
    public class XmlToEntity
    {
        #region 获取微信配置实体（公众、企业）
        /// <summary>
        /// 获取公众平台配置对象
        /// </summary>
        /// <returns></returns>
        public static WXGZConfigEntity GetGZConfig()
        {
            string strXmlPath = HttpRuntime.AppDomainAppPath + @"bin\xmlConfig\WXGZConfig.xml";
            WXGZConfigEntity gzConfig = SetWXConfigCache( "WxGzConfig", strXmlPath, "GZConfig", new WXGZConfigEntity() );
            return gzConfig;
        }

        /// <summary>
        /// 获取企业平台配置对象
        /// </summary>
        /// <returns></returns>
        public static WXQYConfigEntity GetQYConfig()
        {
            string strXmlPath = HttpRuntime.AppDomainAppPath + @"bin\xmlConfig\WXQYConfig.xml";
            WXQYConfigEntity qyConfig = SetWXConfigCache( "WxQyConfig", strXmlPath, "QYConfig", new WXQYConfigEntity() );
            return qyConfig;
        }
        /// <summary>
        /// 获取并配置对象缓存
        /// </summary>
        /// <typeparam name="T">公众或企业平台类型</typeparam>
        /// <param name="cacheKey">缓存key</param>
        /// <param name="xmlPath">配置路径</param>
        /// <param name="xmlNodeName">要转为对象的节点名称</param>
        /// <param name="t"></param>
        /// <returns></returns>
        private static T SetWXConfigCache<T>( string cacheKey, string xmlPath, string xmlNodeName, T t )
        {

            T tXmlEntity  = default( T );
            if ( CacheHelper.GetCache( cacheKey ) == null )
            {
                XmlHelper<string> xo = new XmlHelper<string>( xmlPath );
                List<T> listGzConfig = xo.GetObject<T>( xmlNodeName );
                if ( listGzConfig.Count > 0 )
                {
                    tXmlEntity = listGzConfig[ 0 ];
                    CacheHelper.SetCache( cacheKey, tXmlEntity );
                }
            }
            else
            {
                tXmlEntity = ( T )CacheHelper.GetCache( cacheKey );
            }
            return tXmlEntity;
        }
        #endregion 

        #region 获取路由信息
        public static Dictionary<string, RouteItemEntity> GetRouteItems()
        {
            string strAppPath = HttpRuntime.AppDomainAppPath + @"bin\xmlConfig\RouteConfig.xml";
            List<RouteItemEntity> listRouteItemEntity  = new List<RouteItemEntity>();
            Dictionary<string,RouteItemEntity> dictRoute = new Dictionary<string, RouteItemEntity>();
            //名为WXRoute的cache为一个字典
            //先获取xml中的路由配置，以conller为字典项的key
            if ( CacheHelper.GetCache( "WXRoute" ) == null )
            {
                XmlHelper<string> xo = new XmlHelper<string>( strAppPath );
                listRouteItemEntity = xo.GetObject<RouteItemEntity>( "RouteItems.RouteItem" );
                if ( listRouteItemEntity.Count > 0 )
                {
                    foreach ( RouteItemEntity rie in listRouteItemEntity )
                    {
                        dictRoute.Add( rie.Controller, rie );
                    }
                    CacheHelper.SetCache( "WXRoute", dictRoute, strAppPath );
                }
            }
            else
            {
                dictRoute = ( Dictionary<string, RouteItemEntity> )CacheHelper.GetCache( "WXRoute" );
            }
            return dictRoute;
        }
        #endregion
    }
}
