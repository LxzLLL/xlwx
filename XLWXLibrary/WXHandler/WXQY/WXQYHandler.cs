using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

using XLWXLibrary.WXHandler.PassiveResponseProcess;
using XLWXLibrary.WXHandler.WXQY.Message;
namespace XLWXLibrary.WXHandler.WXQY
{
    /// <summary>
    /// 作者：Arvin
    /// 日期：2016/2/16 8:59:03
    /// 描述：微信企业号处理
    /// </summary>
    public class WXQYHandler:WXHandlerBase
    {
        public WXQYHandler()
        {
            //定义平台类型
            base._wxPlatFormTypeEnum = WxPlatFormTypeEnum.QY;
        }

        /// <summary>
        /// 处理消息请求
        /// </summary>
        public override void ProcessRequest()
        {
            base.ProcessRequest();
            PassiveProcess pp = new PassiveProcess( this._wxPlatFormTypeEnum );
            MessageDispatcher md = new MessageDispatcher();
            string strResponse = md.Dispatcher( pp.GetDecryptContent() );
            //加密
            string strEncryptionResponse = string.Empty;
            pp.SetEncryptionContent( strResponse, ref strEncryptionResponse );
            //发送
            pp.MsgResponse( strEncryptionResponse );
        }
    }
}
