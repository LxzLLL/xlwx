using System;

using XLWXLibrary.WXEntity.QYEntity;
namespace XLWXLibrary.WXHandler.WXQY.Message.Event
{
    /// <summary>
    /// 作者：Arvin
    /// 日期：2016/3/1 16:22:09
    /// 描述：弹出微信相册发图器的事件推送
    /// </summary>
    public class PicWeiXin:IMessage
    {
        private MessagePicSysPhotoEvent _msgPicSysPhotoEntity = new MessagePicSysPhotoEvent();
        /// <summary>
        /// 不能无参构造
        /// </summary>
        private PicWeiXin(){ }
        public PicWeiXin( MessagePicSysPhotoEvent msgPicSysPhotoEntity )
        {
            this._msgPicSysPhotoEntity = msgPicSysPhotoEntity;
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
