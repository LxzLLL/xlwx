using System;

using XLWXLibrary.WXEntity.QYEntity;

namespace XLWXLibrary.WXHandler.WXQY.Message.Event
{
    /// <summary>
    /// 作者：Arvin
    /// 日期：2016/3/1 16:08:56
    /// 描述：取消订阅事件
    /// </summary>
    public class Unsubscribe:IMessage
    {
        private MessageSubscribeEvent _msgSubscribeEntity = new MessageSubscribeEvent();
        /// <summary>
        /// 不能无参构造
        /// </summary>
        private Unsubscribe(){ }
        public Unsubscribe( MessageSubscribeEvent msgSubscribeEntity )
        {
            this._msgSubscribeEntity = msgSubscribeEntity;
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
