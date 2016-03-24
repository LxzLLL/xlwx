using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using XLWXLibrary.WXHandler.ActiveCallProcess;
namespace XLWXLibrary.WXHandler.WXQY.Department
{
    /// <summary>
    /// 作者：Arvin
    /// 日期：2016/2/18 11:29:06
    /// 描述：部门用户管理
    /// </summary>
    public class UserManager:ActiveProcess
    {
        //请求微信部门成员url
        private string _strDepartmentUrl = "https://qyapi.weixin.qq.com/cgi-bin/";
        /// <summary>
        /// 初始化，必须设置_strDepartmentUrl和_wxPlatType变量
        /// </summary>
        public UserManager()
        {
            //微信平台
            this._wxPlatType = WxPlatFormTypeEnum.QY;
        }

        /// <summary>
        /// 创建成员
        /// </summary>
        /// <param name="createJson">json字符串</param>
        /// <param name="dictParam">url上的除access_token参数</param>
        /// <returns></returns>
        public string Create( string createJson, Dictionary<string, string> dictParam )
        {
            string strUrl = this._strDepartmentUrl + "user/" + UserAction.create.ToString();
            return ActiveRequest.SendRequest( this.GetEntityByAction( strUrl, createJson, dictParam ) );
        }
        /// <summary>
        /// 更新成员
        /// </summary>
        /// <param name="updateJson">json字符串</param>
        /// <returns></returns>
        public string Update( string updateJson )
        {
            string strUrl = this._strDepartmentUrl + "user/" + UserAction.update.ToString();
            return ActiveRequest.SendRequest( this.GetEntityByAction( strUrl, updateJson ) );
        }

        /// <summary>
        /// 删除成员
        /// </summary>
        /// <param name="deleteJson">json字符串</param>
        /// <param name="dictParam">url上的除access_token参数</param>
        /// <returns></returns>
        public string Delete( string deleteJson, Dictionary<string, string> dictParam )
        {
            string strUrl = this._strDepartmentUrl + "user/" + UserAction.delete.ToString();
            return ActiveRequest.SendRequest( this.GetEntityByAction( strUrl, deleteJson, dictParam, "get" ) );
        }

        /// <summary>
        /// 批量删除成员
        /// </summary>
        /// <param name="batchDeleteJson">json字符串</param>
        /// <param name="dictParam">url上的除access_token参数</param>
        /// <returns></returns>
        public string BatchDelete( string batchDeleteJson )
        {
            string strUrl = this._strDepartmentUrl + "user/" + UserAction.batchdelete.ToString();
            return ActiveRequest.SendRequest( this.GetEntityByAction( strUrl, batchDeleteJson) );
        }

        /// <summary>
        /// 获取成员
        /// </summary>
        /// <param name="getJson">json字符串</param>
        /// <param name="dictParam">url上的除access_token参数</param>
        /// <returns></returns>
        public string Get( string getJson, Dictionary<string, string> dictParam )
        {
            string strUrl = this._strDepartmentUrl + "user/" + UserAction.get.ToString();
            return ActiveRequest.SendRequest( this.GetEntityByAction( strUrl, getJson, dictParam, "get" ) );
        }

        /// <summary>
        /// 获取部门成员
        /// </summary>
        /// <param name="simpleListJson">json字符串</param>
        /// <param name="dictParam">url上的除access_token参数</param>
        /// <returns></returns>
        public string SimpleList( string simpleListJson, Dictionary<string, string> dictParam )
        {
            string strUrl = this._strDepartmentUrl + "user/" + UserAction.simplelist.ToString();
            return ActiveRequest.SendRequest( this.GetEntityByAction( strUrl, simpleListJson, dictParam, "get" ) );
        }

        /// <summary>
        /// 获取部门成员详情
        /// </summary>
        /// <param name="listJson">json字符串</param>
        /// <param name="dictParam">url上的除access_token参数</param>
        /// <returns></returns>
        public string List( string listJson, Dictionary<string, string> dictParam )
        {
            string strUrl = this._strDepartmentUrl + "user/" + UserAction.list.ToString();
            return ActiveRequest.SendRequest( this.GetEntityByAction( strUrl, listJson, dictParam, "get" ) );
        }

        /// <summary>
        /// 邀请成员关注
        /// </summary>
        /// <param name="sendJson">json字符串</param>
        /// <param name="dictParam">url上的除access_token参数</param>
        /// <returns></returns>
        public string Send( string sendJson)
        {
            string strUrl = this._strDepartmentUrl + "invite/" + UserAction.send.ToString();
            return ActiveRequest.SendRequest( this.GetEntityByAction( strUrl, sendJson ) );
        }


        /// <summary>
        /// 部门用户动作枚举
        /// </summary>
        private enum UserAction
        {
            create = 0,
            update = 1,
            delete,
            batchdelete,   //批量删除
            get,                //获取成员
            simplelist,        //获取部门成员
            list,                //获取部门成员详细
            send                //邀请成员
        }
    }
}
