using System;

using XLWXLibrary.WXEntity.QYEntity;
namespace XLWXLibrary.WXHandler.WXQY.Message.Event
{
    /// <summary>
    /// 作者：Arvin
    /// 日期：2016/3/1 16:15:37
    /// 描述：成员进入应用的事件推送
    /// </summary>
    public class EnterAgent:IMessage
    {
        private MessageMenuPushEvent _msgMenuPushEntity = new MessageMenuPushEvent();
        /// <summary>
        /// 不能无参构造
        /// </summary>
        private EnterAgent(){ }
        public EnterAgent( MessageMenuPushEvent msgMenuPushEntity )
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
