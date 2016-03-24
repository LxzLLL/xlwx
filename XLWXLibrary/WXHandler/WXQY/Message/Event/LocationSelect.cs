using System;

using XLWXLibrary.WXEntity.QYEntity;
namespace XLWXLibrary.WXHandler.WXQY.Message.Event
{
    /// <summary>
    /// 作者：Arvin
    /// 日期：2016/3/1 16:22:57
    /// 描述：弹出地理位置选择器的事件推送
    /// </summary>
    public class LocationSelect:IMessage
    {
        private MessageLocationSelectEvent _msgLocationSelectEntity = new MessageLocationSelectEvent();
        /// <summary>
        /// 不能无参构造
        /// </summary>
        private LocationSelect(){ }
        public LocationSelect( MessageLocationSelectEvent msgLocationSelectEntity )
        {
            this._msgLocationSelectEntity = msgLocationSelectEntity;
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
