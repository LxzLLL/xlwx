using System;

using XLWXLibrary.WXEntity;
namespace XLWXLibrary.WXHandler.WXQY.Message
{
    /// <summary>
    /// 作者：Arvin
    /// 日期：2016/2/19 15:25:42
    /// 描述：企业文本消息类
    /// </summary>
    public class MsgText:IMessage
    {
        private MessageTextEntity _msgTextEntity = new MessageTextEntity();
        /// <summary>
        /// 不能无参构造
        /// </summary>
        private MsgText(){ }
        public MsgText(MessageTextEntity msgTextEntity)
        {
            this._msgTextEntity = msgTextEntity;
        }

        /// <summary>
        /// 接口，返回数据
        /// </summary>
        /// <returns></returns>
        public string MsgResponse()
        {
            string sRespData = @"<xml>
                                                <ToUserName><![CDATA[{0}]]></ToUserName>
                                                <FromUserName><![CDATA[{1}]]></FromUserName>
                                                <CreateTime>{2}</CreateTime>
                                                <MsgType><![CDATA[text]]></MsgType>
                                                <Content><![CDATA[{3}]]></Content>
                                            </xml>";
            sRespData = string.Format( sRespData, this._msgTextEntity.FromUserName,
                                    this._msgTextEntity.ToUserName,
                                    DateTime.Now.Ticks.ToString(),
                                    "您输入的是："+this._msgTextEntity.Content+"；多谢使用。");
            return sRespData;
        }
    }
}
