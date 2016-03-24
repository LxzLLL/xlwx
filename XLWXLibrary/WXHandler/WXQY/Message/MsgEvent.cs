using System;
using System.IO;
using System.Text;

using XLWXLibrary.WXEntity.QYEntity;
using XLWXLibrary.WXHandler.WXQY.Message.Event;
using XLToolLibrary.Utilities;
namespace XLWXLibrary.WXHandler.WXQY.Message
{
    /// <summary>
    /// 作者：Arvin
    /// 日期：2016/3/1 11:37:05
    /// 描述：企业事件消息类
    /// </summary>
    public class MsgEvent : IMessage
    {
        private string _sContent = string.Empty;
        /// <summary>
        /// 不能无参构造
        /// </summary>
        private MsgEvent(){ }
        public MsgEvent( string sContent )
        {
            this._sContent = sContent;
            //this._stream.Seek( 0, SeekOrigin.Begin );
        }
        /// <summary>
        /// 接口，返回数据
        /// </summary>
        /// <returns></returns>
        public string MsgResponse()
        {
            string sRespData = string.Empty;
            if(string.IsNullOrEmpty(this._sContent))
            {
                return sRespData;
            }
            XmlHelper<Stream> xo = new XmlHelper<Stream>( ConvertDataType.String2Stream( this._sContent,Encoding.UTF8 ) );
            string sEvent = xo.GetXElementContent( "xml.Event" );
            switch(sEvent.ToLower())
            {
                //订阅事件
                case "subscribe":
                    sRespData = new Subscribe( xo.GetObj<MessageSubscribeEvent>( "xml" ) ).MsgResponse();
                    break;
                //取消订阅事件
                case "unsubscribe":
                    sRespData = new Unsubscribe( xo.GetObj<MessageSubscribeEvent>( "xml" ) ).MsgResponse();
                    break;
                //上报地理位置事件
                case "location":
                    sRespData = new Location( xo.GetObj<MessageLocationEvent>( "xml" ) ).MsgResponse();
                    break;
                //点击菜单拉取消息的事件推送
                case "click":
                    sRespData = new ClickEvent( xo.GetObj<MessageMenuPushEvent>( "xml" ) ).MsgResponse();
                    break;
                //点击菜单跳转链接的事件推送
                case "view":
                    sRespData = new ViewEvent( xo.GetObj<MessageMenuPushEvent>( "xml" ) ).MsgResponse();
                    break;
                //扫码推事件的事件推送
                case "scancode_push":
                    sRespData = new ScancodePush( xo.GetObj<MessageScancodePushEvent>( "xml" ) ).MsgResponse();
                    break;
                //扫码推事件且弹出“消息接收中”提示框的事件推送
                case "scancode_waitmsg":
                    sRespData = new ScancodeWaitmsg( xo.GetObj<MessageScancodePushEvent>( "xml" ) ).MsgResponse();
                    break;
                //弹出系统拍照发图的事件推送
                case "pic_sysphoto":
                    sRespData = new PicSysPhoto( xo.GetObj<MessagePicSysPhotoEvent>( "xml" ) ).MsgResponse();
                    break;
                //弹出拍照或者相册发图的事件推送
                case "pic_photo_or_album":
                    sRespData = new PicPhotoOrAlbum( xo.GetObj<MessagePicSysPhotoEvent>( "xml" ) ).MsgResponse();
                    break;
                //弹出微信相册发图器的事件推送
                case "pic_weixin":
                    sRespData = new PicWeiXin( xo.GetObj<MessagePicSysPhotoEvent>( "xml" ) ).MsgResponse();
                    break;
                //弹出地理位置选择器的事件推送
                case "location_select":
                    sRespData = new LocationSelect( xo.GetObj<MessageLocationSelectEvent>( "xml" ) ).MsgResponse();
                    break;
                //成员进入应用的事件推送
                case "enter_agent":
                    sRespData = new EnterAgent( xo.GetObj<MessageMenuPushEvent>( "xml" ) ).MsgResponse();
                    break;
                //异步任务完成事件推送
                case "batch_job_result":
                    sRespData = new BatchJobResult( xo.GetObj<MessageBatchJobResultEvent>( "xml" ) ).MsgResponse();
                    break;
                default: break;
            }
            return sRespData;
        }

    }
}
