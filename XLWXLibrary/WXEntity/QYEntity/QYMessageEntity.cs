using System;
using System.Collections.Generic;
using System.Xml;
using System.Xml.Serialization;

namespace XLWXLibrary.WXEntity.QYEntity
{
    /// <summary>
    /// 作者：Arvin
    /// 日期：2016/2/18 16:19:11
    /// 描述：企业消息对象
    /// </summary>
    #region 企业事件消息对象

    /// <summary>
    /// 成员关注（subscribe）/取消关注事件（unsubscribe）
    /// 事件类型：成员关注（subscribe）
    ///                 取消关注事件（unsubscribe）
    /// </summary>
    [XmlRoot( "xml" )]
    public class MessageSubscribeEvent:MessageEventEntity
    {

    }

    /// <summary>
    /// 上报地理位置事件（LOCATION）
    /// 事件类型：LOCATION
    /// </summary>
    [XmlRoot( "xml" )]
    public class MessageLocationEvent : MessageEventEntity
    {
        /// <summary>
        /// 地理位置纬度
        /// </summary>
        public string Latitude { get; set; }
        /// <summary>
        /// 地理位置经度
        /// </summary>
        public string Longitude { get; set; }
        /// <summary>
        /// 地理位置精度
        /// </summary>
        public string Precision { get; set; }
    }

    /// <summary>
    /// 点击菜单拉取消息的事件推送（CLICK）/点击菜单跳转链接的事件推送（VIEW）/成员进入应用的事件推送（enter_agent）
    /// 事件类型：点击菜单拉取消息的事件推送（CLICK）
    ///                点击菜单跳转链接的事件推送（VIEW）
    ///                成员进入应用的事件推送（enter_agent）
    /// </summary>
    [XmlRoot( "xml" )]
    public class MessageMenuPushEvent : MessageEventEntity
    {
        /// <summary>
        /// 事件KEY值，与自定义菜单接口中KEY值对应
        /// </summary>
        public string EventKey { get; set; }
    }

    #region 扫码推事件的事件推送（scancode_push）/扫码推事件且弹出“消息接收中”提示框的事件推送（scancode_waitmsg）
    /// <summary>
    /// 扫码推事件的事件推送/扫码推事件且弹出“消息接收中”提示框的事件推送
    /// 事件类型：扫码推事件的事件推送（scancode_push）
    ///                 扫码推事件且弹出“消息接收中”提示框的事件推送（scancode_waitmsg）
    /// </summary>
    [XmlRoot( "xml" )]
    public class MessageScancodePushEvent : MessageEventEntity
    {
        /// <summary>
        /// 事件KEY值，由开发者在创建菜单时设定
        /// </summary>
        public string EventKey { get; set; }
        /// <summary>
        /// 扫描信息
        /// </summary>
        public ScanInfo ScanCodeInfo { get; set; }
    }
    /// <summary>
    /// 扫描信息
    /// </summary>
    public class ScanInfo
    {
        /// <summary>
        /// 扫描类型，一般是qrcode
        /// </summary>
        public string ScanType { get; set; }
        /// <summary>
        /// 扫描结果，即二维码对应的字符串信息
        /// </summary>
        public string ScanResult { get; set; }
    }
    #endregion
    #region 弹出系统拍照发图的事件推送（pic_sysphoto）/弹出拍照或者相册发图的事件推送（pic_photo_or_album）/弹出微信相册发图器的事件推送（pic_weixin）
    /// <summary>
    /// 弹出系统拍照发图的事件推送/弹出拍照或者相册发图的事件推送/弹出微信相册发图器的事件推送
    /// 事件类型：弹出系统拍照发图的事件推送（pic_sysphoto）
    ///                 弹出拍照或者相册发图的事件推送（pic_photo_or_album）
    ///                 弹出微信相册发图器的事件推送（pic_weixin）
    /// </summary>
    [XmlRoot( "xml" )]
    public class MessagePicSysPhotoEvent : MessageEventEntity
    {
        /// <summary>
        /// 事件KEY值，由开发者在创建菜单时设定
        /// </summary>
        public string EventKey { get; set; }
        /// <summary>
        /// 发送的图片信息
        /// </summary>
        public SendPicsInfo SendPicsInfo { get; set; }
    }
    /// <summary>
    /// 发送的图片信息
    /// </summary>
    public class SendPicsInfo
    {
        /// <summary>
        /// 发送的图片数量
        /// </summary>
        public string Count { get; set; }
        /// <summary>
        /// 图片列表
        /// </summary>
        [XmlArray( "PicList" ), XmlArrayItem( "item" )]
        public PicListItem[] PicList { get; set; }
    }
    public class PicListItem
    {
        /// <summary>
        /// 图片的MD5值，开发者若需要，可用于验证接收到图片
        /// </summary>
        public string PicMd5Sum { get; set; }
    }
    #endregion
    #region 弹出地理位置选择器的事件推送（location_select）
    /// <summary>
    /// 弹出地理位置选择器的事件推送
    /// 事件类型：location_select
    /// </summary>
    [XmlRoot( "xml" )]
    public class MessageLocationSelectEvent : MessageEventEntity
    {
        /// <summary>
        /// 事件KEY值，由开发者在创建菜单时设定
        /// </summary>
        public string EventKey { get; set; }
        /// <summary>
        /// 发送的位置信息
        /// </summary>
        public SendLocationInfo SendLocationInfo { get; set; }
    }
    /// <summary>
    /// 发送的位置信息
    /// </summary>
    public class SendLocationInfo
    {
        /// <summary>
        /// X坐标信息
        /// </summary>
        public string Location_X { get; set; }
        /// <summary>
        /// Y坐标信息
        /// </summary>
        public string Location_Y { get; set; }
        /// <summary>
        /// 精度，可理解为精度或者比例尺、越精细的话 scale越高
        /// </summary>
        public string Scale { get; set; }
        /// <summary>
        /// 地理位置的字符串信息
        /// </summary>
        public string Label { get; set; }
        /// <summary>
        /// 朋友圈POI的名字，可能为空
        /// </summary>
        public string Poiname { get; set; }
    }
    #endregion

    #region 异步任务完成事件推送（batch_job_result）
    /// <summary>
    /// 异步任务完成事件推送
    /// 事件类型：batch_job_result
    /// </summary>
    [XmlRoot( "xml" )]
    public class MessageBatchJobResultEvent : MessageEventEntity
    {
        /// <summary>
        /// 异步任务
        /// </summary>
        public BatchJob BatchJob { get; set; }
    }
    /// <summary>
    /// 异步任务
    /// </summary>
    public class BatchJob
    {
        /// <summary>
        /// 异步任务id，最大长度为64字符
        /// </summary>
        public string JobId { get; set; }
        /// <summary>
        /// 操作类型，字符串，目前分别有：
        /// 1. sync_user(增量更新成员)
        /// 2. replace_user(全量覆盖成员)
        /// 3. invite_user(邀请成员关注)
        /// 4. replace_party(全量覆盖部门)
        /// </summary>
        public string JobType { get; set; }
        /// <summary>
        /// 返回码
        /// </summary>
        public string ErrCode { get; set; }
        /// <summary>
        /// 对返回码的文本描述内容
        /// </summary>
        public string ErrMsg { get; set; }
    }

    #endregion

    #endregion
}
