using System;

using XLWXLibrary.WXEntity.QYEntity;
namespace XLWXLibrary.WXHandler.WXQY.Message.Event
{
    /// <summary>
    /// 作者：Arvin
    /// 日期：2016/3/1 16:10:29
    /// 描述：上报地理位置事件
    /// </summary>
    public class Location:IMessage
    {
        private MessageLocationEvent _msgLocationEntity = new MessageLocationEvent();
        /// <summary>
        /// 不能无参构造
        /// </summary>
        private Location(){ }
        public Location( MessageLocationEvent msgLocationEntity )
        {
            this._msgLocationEntity = msgLocationEntity;
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
