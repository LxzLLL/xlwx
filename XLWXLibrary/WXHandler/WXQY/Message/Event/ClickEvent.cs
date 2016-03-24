using System;

using XLWXLibrary.WXEntity.QYEntity;
namespace XLWXLibrary.WXHandler.WXQY.Message.Event
{
    /// <summary>
    /// 作者：Arvin
    /// 日期：2016/3/1 16:12:25
    /// 描述：点击菜单拉取消息的事件推送
    /// </summary>
    public class ClickEvent:IMessage
    {
        private MessageMenuPushEvent _msgMenuPushEntity = new MessageMenuPushEvent();
        /// <summary>
        /// 不能无参构造
        /// </summary>
        private ClickEvent(){ }
        public ClickEvent( MessageMenuPushEvent msgMenuPushEntity )
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
            sRespData = @"<xml>
                                                <ToUserName><![CDATA[{0}]]></ToUserName>
                                                <FromUserName><![CDATA[{1}]]></FromUserName>
                                                <CreateTime>{2}</CreateTime>
                                                <MsgType><![CDATA[text]]></MsgType>
                                                <Content><![CDATA[{3}]]></Content>
                                            </xml>";
            sRespData = string.Format( sRespData, this._msgMenuPushEntity.FromUserName,
                                    this._msgMenuPushEntity.ToUserName,
                                    DateTime.Now.Ticks.ToString(),
                                    "您的ID为：" + this._msgMenuPushEntity.FromUserName+Environment.NewLine+
                                    "企业CorpID为：" + this._msgMenuPushEntity.ToUserName + Environment.NewLine +
                                    "您点击的菜单事件类型为：" + this._msgMenuPushEntity.Event+Environment.NewLine +
                                    "键值为：" + this._msgMenuPushEntity.EventKey + Environment.NewLine + 
                                    "；多谢使用。" );
            return sRespData;
        }
    }
}
