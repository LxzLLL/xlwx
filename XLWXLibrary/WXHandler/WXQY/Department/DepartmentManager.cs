using System;
using System.Collections.Generic;
using System.Text;

using XLWXLibrary.WXHandler.ActiveCallProcess;

namespace XLWXLibrary.WXHandler.WXQY.Department
{
    /// <summary>
    /// 作者：Arvin
    /// 日期：2016/2/18 9:04:20
    /// 描述：管理部门
    /// </summary>
    public class DepartmentManager : ActiveProcess
    {
        //请求微信部门url
        private string _strDepartmentUrl = "https://qyapi.weixin.qq.com/cgi-bin/department/";
        /// <summary>
        /// 初始化，必须设置_strDepartmentUrl和_wxPlatType变量
        /// </summary>
        public DepartmentManager()
        {
            //微信平台
            this._wxPlatType = WxPlatFormTypeEnum.QY;
        }
        /// <summary>
        /// 创建部门
        /// </summary>
        /// <param name="createJson">json字符串</param>
        /// <param name="dictParam">url上的除access_token参数</param>
        /// <returns></returns>
        public string Create(string createJson,Dictionary<string,string> dictParam)
        {
            return ActiveRequest.SendRequest( this.GetEntityByAction(this._strDepartmentUrl+DepartmentAction.create.ToString(),createJson,dictParam) );
        }
        /// <summary>
        /// 更新部门
        /// </summary>
        /// <param name="UpdateJson">json字符串</param>
        /// <returns></returns>
        public string Update( string UpdateJson )
        {
            return ActiveRequest.SendRequest( this.GetEntityByAction( this._strDepartmentUrl + DepartmentAction.update.ToString(), UpdateJson ) );
        }
        /// <summary>
        /// 删除部门
        /// </summary>
        /// <param name="deleteJson">传递的json数据</param>
        /// <param name="dictParam">url上的除access_token参数</param>
        /// <returns></returns>
        public string Delete( string deleteJson, Dictionary<string, string> dictParam )
        {
            return ActiveRequest.SendRequest( this.GetEntityByAction( this._strDepartmentUrl + DepartmentAction.delete.ToString(), deleteJson, dictParam,"get" ) );
        }
        /// <summary>
        /// 查询部门
        /// </summary>
        /// <param name="listJson">传递的json数据</param>
        /// <param name="dictParam">url上的除access_token参数</param>
        /// <returns></returns>
        public string List( string listJson, Dictionary<string, string> dictParam )
        {
            return ActiveRequest.SendRequest( this.GetEntityByAction( this._strDepartmentUrl + DepartmentAction.list.ToString(), listJson, dictParam,"get" ) );
        }

        /// <summary>
        /// 部门动作枚举
        /// </summary>
        private enum DepartmentAction
        {
            create = 0,
            update = 1,
            delete,
            list
        }
    }
    
}
