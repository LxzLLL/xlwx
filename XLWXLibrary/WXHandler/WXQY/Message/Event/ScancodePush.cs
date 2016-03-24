using System;

using XLWXLibrary.WXEntity.QYEntity;
namespace XLWXLibrary.WXHandler.WXQY.Message.Event
{
    /// <summary>
    /// 作者：Arvin
    /// 日期：2016/3/1 16:16:29
    /// 描述：扫码推事件的事件推送
    /// </summary>
    public class ScancodePush:IMessage
    {
        private MessageScancodePushEvent _msgScancodePushEntity = new MessageScancodePushEvent();
        /// <summary>
        /// 不能无参构造
        /// </summary>
        private ScancodePush(){ }
        public ScancodePush( MessageScancodePushEvent msgScancodePushEntity )
        {
            this._msgScancodePushEntity = msgScancodePushEntity;
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
