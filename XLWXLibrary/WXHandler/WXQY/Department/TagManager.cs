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
    /// 日期：2016/2/18 13:58:37
    /// 描述：通信录标签管理
    /// </summary>
    public class TagManager:ActiveProcess
    {
        //请求微信通信录标签url
        private string _strDepartmentUrl = "https://qyapi.weixin.qq.com/cgi-bin/tag/";
        /// <summary>
        /// 初始化，必须设置_strDepartmentUrl和_wxPlatType变量
        /// </summary>
        public TagManager()
        {
            //微信平台
            this._wxPlatType = WxPlatFormTypeEnum.QY;
        }

        /// <summary>
        /// 创建标签
        /// </summary>
        /// <param name="createJson">json字符串</param>
        /// <param name="dictParam">url上的除access_token参数</param>
        /// <returns></returns>
        public string Create( string createJson, Dictionary<string, string> dictParam )
        {
            string strUrl = this._strDepartmentUrl + TagAction.create.ToString();
            return ActiveRequest.SendRequest( this.GetEntityByAction( strUrl, createJson, dictParam ) );
        }

        /// <summary>
        /// 更新标签名字
        /// </summary>
        /// <param name="updateJson">json字符串</param>
        /// <returns></returns>
        public string Update( string updateJson )
        {
            string strUrl = this._strDepartmentUrl + TagAction.update.ToString();
            return ActiveRequest.SendRequest( this.GetEntityByAction( strUrl, updateJson ) );
        }

        /// <summary>
        /// 删除标签
        /// </summary>
        /// <param name="deleteJson">json字符串</param>
        /// <param name="dictParam">url上的除access_token参数</param>
        /// <returns></returns>
        public string Delete( string deleteJson, Dictionary<string, string> dictParam )
        {
            string strUrl = this._strDepartmentUrl + TagAction.delete.ToString();
            return ActiveRequest.SendRequest( this.GetEntityByAction( strUrl, deleteJson, dictParam, "get" ) );
        }

        /// <summary>
        /// 获取标签成员
        /// </summary>
        /// <param name="getJson">json字符串</param>
        /// <param name="dictParam">url上的除access_token参数</param>
        /// <returns></returns>
        public string Get( string getJson, Dictionary<string, string> dictParam )
        {
            string strUrl = this._strDepartmentUrl + TagAction.get.ToString();
            return ActiveRequest.SendRequest( this.GetEntityByAction( strUrl, getJson, dictParam, "get" ) );
        }

        /// <summary>
        /// 增加标签成员
        /// </summary>
        /// <param name="addTagUsersJson">json字符串</param>
        /// <param name="dictParam">url上的除access_token参数</param>
        /// <returns></returns>
        public string AddTagUsers( string addTagUsersJson )
        {
            string strUrl = this._strDepartmentUrl + TagAction.addtagusers.ToString();
            return ActiveRequest.SendRequest( this.GetEntityByAction( strUrl, addTagUsersJson ) );
        }

        /// <summary>
        /// 删除标签成员
        /// </summary>
        /// <param name="delTagUsersJson">json字符串</param>
        /// <param name="dictParam">url上的除access_token参数</param>
        /// <returns></returns>
        public string DelTagUsers( string delTagUsersJson )
        {
            string strUrl = this._strDepartmentUrl + TagAction.deltagusers.ToString();
            return ActiveRequest.SendRequest( this.GetEntityByAction( strUrl, delTagUsersJson ) );
        }
        /// <summary>
        /// 获取标签列表
        /// </summary>
        /// <param name="listJson">json字符串</param>
        /// <param name="dictParam">url上的除access_token参数</param>
        /// <returns></returns>
        public string List( string listJson)
        {
            string strUrl = this._strDepartmentUrl + TagAction.list.ToString();
            return ActiveRequest.SendRequest( this.GetEntityByAction( strUrl, listJson,null, "get" ) );
        }

        /// <summary>
        /// 标签动作枚举
        /// </summary>
        private enum TagAction
        {
            create = 0,
            update = 1,      //更新标签名字
            delete,
            get,                //获取标签成员
            addtagusers,   //增加标签成员
            deltagusers,    //删除标签成员
            list                 //获取标签列表
        }
    }
}
