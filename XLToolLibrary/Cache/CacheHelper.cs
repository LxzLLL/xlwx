using System;
using System.Web;
using System.Collections;

namespace XLToolLibrary.Utilities
{
    /// <summary>
    /// 作者：Arvin
    /// 日期：2016/2/15 9:33:25
    /// 描述：数据缓存类
    /// </summary>
    public class CacheHelper
    {
        private static System.Web.Caching.Cache _cache = HttpRuntime.Cache;
        /// <summary>
        /// 获取缓存
        /// </summary>
        /// <param name="strCache">缓存内容key字符串</param>
        /// <returns></returns>
        public static object GetCache(string strCache)
        {
            return _cache[ strCache ];
        }

        /// <summary>
        /// 默认方式设置缓存
        /// </summary>
        /// <param name="strKey">缓存内容key字符串</param>
        /// <param name="objCache">缓存内容</param>
        public static void SetCache(string strKey, object objCache)
        {
            _cache.Insert( strKey, objCache );
        }

        /// <summary>
        /// 以过期时间设置缓存
        /// </summary>
        /// <param name="strKey">缓存内容key字符串</param>
        /// <param name="objCache">缓存内容</param>
        /// <param name="timeOut">过期时间间隔</param>
        public static void SetCache(string strKey, object objCache, TimeSpan timeOut)
        {
            _cache.Insert( strKey, objCache, null, System.Web.Caching.Cache.NoAbsoluteExpiration, timeOut, null );
        }

        /// <summary>
        /// 以绝对时间设置缓存
        /// </summary>
        /// <param name="strKey"></param>
        /// <param name="objCache"></param>
        /// <param name="absoluteExpiration"></param>
        public static void SetCache(string strKey, object objCache, DateTime absoluteExpiration)
        {
            _cache.Insert( strKey, objCache, null, absoluteExpiration,System.Web.Caching.Cache.NoSlidingExpiration );
        }

        /// <summary>
        /// 以文件依赖设置缓存
        /// </summary>
        /// <param name="strKey"></param>
        /// <param name="objCache"></param>
        /// <param name="strPath"></param>
        public static void SetCache(string strKey, object objCache, string strPath)
        {
            _cache.Insert( strKey, objCache, new System.Web.Caching.CacheDependency( strPath ) );
        }

        /// <summary>
        /// 移除指定的缓存项
        /// </summary>
        /// <param name="strKey"></param>
        /// <returns></returns>
        public static object RemoveCache(string strKey)
        {
            return _cache.Remove( strKey );
        }
        /// <summary>
        /// 移除全部缓存项
        /// </summary>
        public static void RemoveAllCache()
        {
            IDictionaryEnumerator cacheEnum = _cache.GetEnumerator();
            while(cacheEnum.MoveNext())
            {
                _cache.Remove( cacheEnum.Key.ToString() );
            }
        }
    }
}
