using System;

namespace XLWXLibrary.JSSDK
{
    /// <summary>
    /// 作者：Arvin
    /// 日期：2016/3/2 16:53:21
    /// 描述：JSAPI 的枚举类型
    /// </summary>

    /// <summary>
    /// 企业JSAPI 的枚举类型
    /// </summary>
    [Flags]
    public enum QyJsApiEnum : ulong
    {
        /// <summary>
        /// 创建企业会话
        /// </summary>
        openEnterpriseChat = 0x1,
        /// <summary>
        /// 打开企业通讯录选人
        /// </summary>
        openEnterpriseContact = 0x2,
        /// <summary>
        /// 获取“分享到朋友圈”按钮点击状态及自定义分享内容接口
        /// </summary>
        onMenuShareTimeline = 0x4,
        /// <summary>
        /// 获取“分享给朋友”按钮点击状态及自定义分享内容接口
        /// </summary>
        onMenuShareAppMessage = 0x8,
        /// <summary>
        /// 获取“分享到QQ”按钮点击状态及自定义分享内容接口
        /// </summary>
        onMenuShareQQ = 0x10,
        /// <summary>
        /// 获取“分享到腾讯微博”按钮点击状态及自定义分享内容接口
        /// </summary>
        onMenuShareWeibo = 0x20,
        /// <summary>
        /// 获取“分享到QQ空间”按钮点击状态及自定义分享内容接口
        /// </summary>
        onMenuShareQZone = 0x40,
        /// <summary>
        /// 开始录音接口
        /// </summary>
        startRecord = 0x80,
        /// <summary>
        /// 停止录音接口
        /// </summary>
        stopRecord = 0x100,
        /// <summary>
        /// 监听录音自动停止接口
        /// </summary>
        onVoiceRecordEnd = 0x200,
        /// <summary>
        /// 播放语音接口
        /// </summary>
        playVoice = 0x400,
        /// <summary>
        /// 暂停播放接口
        /// </summary>
        pauseVoice = 0x800,
        /// <summary>
        /// 停止播放接口
        /// </summary>
        stopVoice = 0x1000,
        /// <summary>
        /// 监听语音播放完毕接口
        /// </summary>
        onVoicePlayEnd = 0x2000,
        /// <summary>
        /// 上传语音接口
        /// </summary>
        uploadVoice = 0x4000,
        /// <summary>
        /// 下载语音接口
        /// </summary>
        downloadVoice = 0x8000,
        /// <summary>
        /// 拍照或从手机相册中选图接口
        /// </summary>
        chooseImage = 0x10000,
        /// <summary>
        /// 预览图片接口
        /// </summary>
        previewImage = 0x20000,
        /// <summary>
        /// 上传图片接口
        /// </summary>
        uploadImage = 0x40000,
        /// <summary>
        /// 下载图片接口
        /// </summary>
        downloadImage = 0x80000,
        /// <summary>
        /// 识别音频并返回识别结果接口
        /// </summary>
        translateVoice = 0x100000,
        /// <summary>
        /// 获取网络状态接口
        /// </summary>
        getNetworkType = 0x200000,
        /// <summary>
        /// 使用微信内置地图查看位置接口
        /// </summary>
        openLocation = 0x400000,
        /// <summary>
        /// 获取地理位置接口
        /// </summary>
        getLocation = 0x800000,
        /// <summary>
        /// 隐藏右上角菜单接口
        /// </summary>
        hideOptionMenu = 0x1000000,
        /// <summary>
        /// 显示右上角菜单接口
        /// </summary>
        showOptionMenu = 0x2000000,
        /// <summary>
        /// 批量隐藏功能按钮接口
        /// </summary>
        hideMenuItems = 0x4000000,
        /// <summary>
        /// 批量显示功能按钮接口
        /// </summary>
        showMenuItems = 0x8000000,
        /// <summary>
        /// 隐藏所有非基础按钮接口
        /// </summary>
        hideAllNonBaseMenuItem = 0x10000000,
        /// <summary>
        /// 显示所有功能按钮接口
        /// </summary>
        showAllNonBaseMenuItem = 0x20000000,
        /// <summary>
        /// 关闭当前网页窗口接口
        /// </summary>
        closeWindow = 0x40000000,
        /// <summary>
        /// 调起微信扫一扫接口
        /// </summary>
        scanQRCode = 0x80000000
    }

    
    /// <summary>
    /// 公众号JSAPI 的枚举类型
    /// </summary>
    [Flags]
    public enum GzJsApiEnum : ulong
    {
        onMenuShareTimeline = 0x1,
        onMenuShareAppMessage = 0x2,
        onMenuShareQQ = 0x4,
        onMenuShareWeibo = 0x8,
        startRecord = 0x10,
        stopRecord = 0x20,
        onVoiceRecordEnd = 0x40,
        playVoice = 0x80,
        pauseVoice = 0x100,
        stopVoice = 0x200,
        onVoicePlayEnd = 0x400,
        uploadVoice = 0x800,
        downloadVoice = 0x1000,
        chooseImage = 0x2000,
        previewImage = 0x4000,
        uploadImage = 0x8000,
        downloadImage = 0x10000,
        translateVoice = 0x20000,
        getNetworkType = 0x40000,
        openLocation = 0x80000,
        getLocation = 0x100000,
        hideOptionMenu = 0x200000,
        showOptionMenu = 0x400000,
        hideMenuItems = 0x800000,
        showMenuItems = 0x1000000,
        hideAllNonBaseMenuItem = 0x2000000,
        showAllNonBaseMenuItem = 0x4000000,
        closeWindow = 0x8000000,
        scanQRCode = 0x10000000,
        chooseWXPay = 0x20000000,
        openProductSpecificView = 0x40000000,
        addCard = 0x80000000,
        chooseCard = 0x100000000,
        openCard = 0x200000000
    }
}
