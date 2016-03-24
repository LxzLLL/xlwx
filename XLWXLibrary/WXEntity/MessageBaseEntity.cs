using System;
using System.Xml;
using System.Xml.Serialization;

namespace XLWXLibrary.WXEntity
{
    /// <summary>
    /// 作者：Arvin
    /// 日期：2016/2/16 9:50:31
    /// 描述：微信消息类，其公众号和企业号使用同一实体，
    ///          如果差异较大，则分化出两种不同的实体
    /// </summary>
    [Serializable]
    public class MessageCommBaseEntity
    {
        /// <summary>
        /// 开发者微信号
        /// </summary>
        public string ToUserName { get; set; }
        /// <summary>
        /// 发送方帐号（一个OpenID）
        /// </summary>
        public string FromUserName { get; set; }
        /// <summary>
        /// 消息创建时间 （整型）
        /// </summary>
        public string CreateTime { get; set; }
        /// <summary>
        /// 消息类型
        /// </summary>
        public string MsgType { get; set; }

        [NonSerialized]
        private string _agentId = string.Empty;
        /// <summary>
        /// 企业应用的id，整型。可在应用的设置页面查看；
        /// 只在企业号中使用
        /// </summary>
        public string AgentID
        {
            get
            {
                return this._agentId;
            }
            set
            {
                this._agentId = value;
            }
        }

    }

    #region 普通消息
    /// <summary>
    /// 文本消息
    /// </summary>
    [XmlRoot( "xml" )]
    public class MessageTextEntity : MessageCommBaseEntity
    {
        /// <summary>
        /// 文本消息内容
        /// </summary>
        public string Content { get; set; }
        /// <summary>
        /// 消息id，64位整型
        /// </summary>
        public string MsgId { get; set; }
    }

    /// <summary>
    /// 图片消息
    /// </summary>
    public class MessageImageEntity : MessageCommBaseEntity
    {
        /// <summary>
        /// 图片链接
        /// </summary>
        public string PicUrl { get; set; }
        /// <summary>
        /// 图片媒体文件id，可以调用获取媒体文件接口拉取数据
        /// </summary>
        public string MediaId { get; set; }
        /// <summary>
        /// 消息id，64位整型
        /// </summary>
        public string MsgId { get; set; }
    }

    // <summary>
    /// 语音消息
    /// </summary>
    public class MessageVoiceEntity : MessageCommBaseEntity
    {
        /// <summary>
        /// 语音格式，如amr，speex等
        /// </summary>
        public string Format { get; set; }
        /// <summary>
        /// 语音媒体文件id，可以调用获取媒体文件接口拉取数据
        /// </summary>
        public string MediaId { get; set; }
        /// <summary>
        /// 语音识别结果，使用UTF8编码；
        /// 开通语音识别后，用户每次发送语音给公众号时，微信会在推送的语音消息XML数据包中，增加一个Recongnition字段；
        /// </summary>
        public string Recongnition { get; set; }
        /// <summary>
        /// 消息id，64位整型
        /// </summary>
        public string MsgId { get; set; }
        
    }

    // <summary>
    /// 视频消息
    /// </summary>
    public class MessageVideoEntity : MessageCommBaseEntity
    {
        /// <summary>
        /// 语音媒体文件id，可以调用获取媒体文件接口拉取数据
        /// </summary>
        public string MediaId { get; set; }
        /// <summary>
        /// 视频消息缩略图的媒体id，可以调用获取媒体文件接口拉取数据
        /// </summary>
        public string ThumbMediaId { get; set; }
        /// <summary>
        /// 消息id，64位整型
        /// </summary>
        public string MsgId { get; set; }

    }
    // <summary>
    /// 小视频消息
    /// </summary>
    public class MessageShortVideoEntity : MessageCommBaseEntity
    {
        /// <summary>
        /// 语音媒体文件id，可以调用获取媒体文件接口拉取数据
        /// </summary>
        public string MediaId { get; set; }
        /// <summary>
        /// 视频消息缩略图的媒体id，可以调用获取媒体文件接口拉取数据
        /// </summary>
        public string ThumbMediaId { get; set; }
        /// <summary>
        /// 消息id，64位整型
        /// </summary>
        public string MsgId { get; set; }
    }

    // <summary>
    /// 地理位置消息
    /// </summary>
    public class MessageLocationEntity : MessageCommBaseEntity
    {
        /// <summary>
        /// 地理位置纬度
        /// </summary>
        public string Location_X { get; set; }
        /// <summary>
        /// 地理位置经度
        /// </summary>
        public string Location_Y { get; set; }
        /// <summary>
        /// 地图缩放大小
        /// </summary>
        public string Scale { get; set; }
        /// <summary>
        /// 地理位置信息
        /// </summary>
        public string Label { get; set; }
        /// <summary>
        /// 消息id，64位整型
        /// </summary>
        public string MsgId { get; set; }
    }

    // <summary>
    /// 链接消息
    /// </summary>
    public class MessageLinkEntity : MessageCommBaseEntity
    {
        /// <summary>
        /// 标题
        /// </summary>
        public string Title { get; set; }
        /// <summary>
        /// 描述
        /// </summary>
        public string Description { get; set; }
        /// <summary>
        /// 封面缩略图的url；用于企业号
        /// </summary>
        public string PicUrl { get; set; }
        /// <summary>
        /// 消息链接；用于公众号
        /// </summary>
        public string Url { get; set; }
        /// <summary>
        /// 消息id，64位整型
        /// </summary>
        public string MsgId { get; set; }
    }
    #endregion

    #region 事件消息
    /// <summary>
    /// 事件消息基类
    /// </summary>
    public class MessageEventEntity:MessageCommBaseEntity
    {
        /// <summary>
        /// 事件类型
        /// </summary>
        public string Event { get; set; }
    }

    #endregion


    /// <summary>
    /// 作者：Arvin
    /// 日期：2016/2/16 9:53:03
    /// 描述：微信消息类型
    /// </summary>
    public enum MessageTypeEnum
    {
        /// <summary>
        /// 文本消息
        /// </summary>
        text = 0,
        /// <summary>
        /// 图片消息
        /// </summary>
        image = 1,
        /// <summary>
        /// 音频消息
        /// </summary>
        voice = 2,
        /// <summary>
        /// 视频消息
        /// </summary>
        video = 3,
        /// <summary>
        /// 小视频消息
        /// </summary>
        shortvideo = 4,
        /// <summary>
        /// 地理位置消息
        /// </summary>
        location = 5,
        /// <summary>
        /// 链接消息
        /// </summary>
        link = 6
    }
}
