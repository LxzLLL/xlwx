using System;
using System.Collections.Generic;

using XLWXLibrary.WXHandler.ActiveCallProcess;
using XLWXLibrary.WXEntity;
namespace XLWXLibrary.WXHandler.WXGZ.Menu
{
    /// <summary>
    /// 作者：Arvin
    /// 日期：2016/3/1 9:54:41
    /// 描述：公众号的菜单管理
    /// </summary>
    public class MenuManager : ActiveProcess
    {
        //请求菜单管理的url
        private string _strMenuUrl = "https://api.weixin.qq.com/cgi-bin/menu/";
        /// <summary>
        /// 初始化，必须设置_strMenuUrl和_wxPlatType变量
        /// </summary>
        public MenuManager()
        {
            //微信平台
            this._wxPlatType = WxPlatFormTypeEnum.GZ;
        }

        /// <summary>
        /// 创建菜单
        /// </summary>
        /// <param name="strJson">传递的json数据</param>
        /// <returns>返回json结果</returns>
        public string Create( string strJson )
        {
            return ActiveRequest.SendRequest( this.GetEntityByAction( this._strMenuUrl + MenuAction.create.ToString(), strJson ) );
        }

        /// <summary>
        /// 删除菜单（全部删除）
        /// </summary>
        /// <returns></returns>
        public string Delete( )
        {
            string strUrl = this._strMenuUrl + MenuAction.delete.ToString();
            return ActiveRequest.SendRequest( this.GetEntityByAction( strUrl, "", null, "get" ) );
        }

        /// <summary>
        /// 获取菜单列表（全部菜单）
        /// </summary>
        /// <returns></returns>
        public string Get( )
        {
            string strUrl = this._strMenuUrl + MenuAction.get.ToString();
            return ActiveRequest.SendRequest( this.GetEntityByAction( strUrl, "", null, "get" ) );
        }

        //个性化菜单
        //获取自定义菜单配置接口

        /// <summary>
        /// 菜单管理枚举
        /// </summary>
        private enum MenuAction
        {
            create = 0,
            delete,
            get
        }
    }
}
