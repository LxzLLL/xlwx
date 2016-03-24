using System;

using XLWXLibrary.WXEntity.QYEntity;
namespace XLWXLibrary.WXHandler.WXQY.Message.Event
{
    /// <summary>
    /// 作者：Arvin
    /// 日期：2016/3/1 16:14:07
    /// 描述：点击菜单跳转链接的事件推送
    /// </summary>
    public class ViewEvent:IMessage
    {
        private MessageMenuPushEvent _msgMenuPushEntity = new MessageMenuPushEvent();
        /// <summary>
        /// 不能无参构造
        /// </summary>
        private ViewEvent(){ }
        public ViewEvent( MessageMenuPushEvent msgMenuPushEntity )
        {
            this._msgMenuPushEntity = msgMenuPushEntity;
        }

        /// <summary>
        /// 接口，返回数据
        /// </summary>
        /// <returns></returns>
        public string MsgResponse()
        {
            string sRespData = string.Empty ;
            
            return sRespData;
        }
    }
}
