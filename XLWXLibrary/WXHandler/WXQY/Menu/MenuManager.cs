using System;
using System.Collections.Generic;


using XLWXLibrary.WXHandler.ActiveCallProcess;
using XLWXLibrary.WXEntity;
namespace XLWXLibrary.WXHandler.WXQY.Menu
{
    /// <summary>
    /// 作者：Arvin
    /// 日期：2016/2/29 16:02:17
    /// 描述：企业号的菜单管理
    /// </summary>
    public class MenuManager : ActiveProcess
    {
        //请求菜单管理的url
        private string _strMenuUrl = "https://qyapi.weixin.qq.com/cgi-bin/menu/";
        /// <summary>
        /// 初始化，必须设置_strMenuUrl和_wxPlatType变量
        /// </summary>
        public MenuManager()
        {
            //微信平台
            this._wxPlatType = WxPlatFormTypeEnum.QY;
        }

        /// <summary>
        /// 创建菜单
        /// </summary>
        /// <param name="strJson">传递的json数据</param>
        /// <param name="dictParam">url上的除access_token参数</param>
        /// <returns>返回json结果</returns>
        public string Create( string strJson, Dictionary<string, string> dictParam )
        {
            return ActiveRequest.SendRequest( this.GetEntityByAction( this._strMenuUrl + MenuAction.create.ToString(), strJson,dictParam ) );
        }

        /// <summary>
        /// 删除菜单（全部删除）
        /// </summary>
        /// <param name="dictParam">url上的除access_token参数</param>
        /// <returns></returns>
        public string Delete( Dictionary<string, string> dictParam )
        {
            string strUrl = this._strMenuUrl + MenuAction.delete.ToString();
            return ActiveRequest.SendRequest( this.GetEntityByAction( strUrl, "", dictParam, "get" ) );
        }

        /// <summary>
        /// 获取菜单列表（全部菜单）
        /// </summary>
        /// <param name="dictParam">url上的除access_token参数</param>
        /// <returns></returns>
        public string Get( Dictionary<string, string> dictParam )
        {
            string strUrl = this._strMenuUrl + MenuAction.get.ToString();
            return ActiveRequest.SendRequest( this.GetEntityByAction( strUrl, "", dictParam, "get" ) );
        }
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
