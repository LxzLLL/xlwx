using System;
using System.Text;
using System.Web;
using System.Collections.Generic;

using XLWXLibrary.WXEntity.XmlEntity;
using XLWXLibrary.WXHandler.Cryptography;
using XLToolLibrary.Utilities;

namespace XLWXLibrary.WXHandler.PassiveResponseProcess
{
    /// <summary>
    /// 作者：Arvin
    /// 日期：2016/2/18 17:43:31
    /// 描述：被动处理
    ///          1、包含公众号和企业号的处理
    ///          2、公众号中设置是否加密处理
    /// </summary>
    public class PassiveProcess
    {
        /// <summary>
        /// 平台类型
        /// </summary>
        private WxPlatFormTypeEnum _wxPlatType = WxPlatFormTypeEnum.None;
        /// <summary>
        /// 加解密类
        /// </summary>
        private WXBizMsgCrypt _wxcpt =null;

        /// <summary>
        /// 不能使用默认构造函数
        /// </summary>
        private PassiveProcess()
        {

        }

        /// <summary>
        /// 类初始化
        /// </summary>
        /// <param name="wxPlatType"></param>
        public PassiveProcess(WxPlatFormTypeEnum wxPlatType)
        {
            this._wxPlatType = wxPlatType;
            //根据平台构造加解密实例，目前将qy与gz使用同一加解密实例
            if(this._wxPlatType==WxPlatFormTypeEnum.QY)
            {
                WXQYConfigEntity qyConfig = XmlToEntity.GetQYConfig();
                this._wxcpt = new WXBizMsgCrypt( qyConfig.Token, qyConfig.EncodingAESKey, qyConfig.CorpID );
            }
            else
            {
                WXGZConfigEntity gzConfig = XmlToEntity.GetGZConfig();
                this._wxcpt = new WXBizMsgCrypt( gzConfig.Token, gzConfig.EncodingAESKey, gzConfig.AppID );
            }
        }
        //针对企业号
        //1、签名校验
        //2、校验成功后解密
        //3、针对不同的回调进行处理
        //4、加密response

        //针对公众号
        //1、判断是否加密
        //2、对签名校验
        //3、校验成功后解密
        //4、针对不同的回调进行处理
        //5、response

        public string GetDecryptContent( )
        {
            string strContent = string.Empty;
            //如果为公众平台且未使用加密
            if(this._wxPlatType == WxPlatFormTypeEnum.GZ)
            {
                strContent = GZProcess();
            }
            else if ( this._wxPlatType == WxPlatFormTypeEnum.QY )
            {
                strContent = QYProcess();
            }

            //判断平台
            //如果为企业或配置加密的公众号  签名校验
            //返回解密内容
            return strContent;
        }

        /// <summary>
        /// 公众号处理
        /// </summary>
        /// <returns></returns>
        private string GZProcess()
        {
            string strGzContent = string.Empty;
            WXGZConfigEntity gzConfig = XmlToEntity.GetGZConfig();
            //如果为公众平台且未使用加密，直接返回文本
            if(string.IsNullOrEmpty(gzConfig.EncodingAESKey))
            {
                strGzContent = ConvertDataType.Strem2String( HttpContext.Current.Request.InputStream, Encoding.UTF8 );
                return strGzContent;
            }
            //校验签名及返回解析后的content
            CheckMsgSignature( ref strGzContent );
            return strGzContent;
        }


        /// <summary>
        /// 企业号处理
        /// </summary>
        /// <returns></returns>
        private string QYProcess()
        {
            WXQYConfigEntity qyConfig = XmlToEntity.GetQYConfig();
            string strMsg = string.Empty;
            //校验签名及返回解析后的content
            CheckMsgSignature( ref strMsg );
            return strMsg;
        }
       
        /// <summary>
        /// 校验签名
        /// </summary>
        /// <param name="sToken">token</param>
        /// <param name="sEncodingAESKey">配置的加密字符串</param>
        /// <param name="sID">CropID或AppID</param>
        /// <returns></returns>
        private bool CheckMsgSignature( ref string sMsg )
        {
            string sReqMsgSig = HttpContext.Current.Request.Params[ "msg_signature" ];
            string sReqTimeStamp = HttpContext.Current.Request.Params[ "timestamp" ];
            string sReqNonce = HttpContext.Current.Request.Params[ "nonce" ];
			// Post请求的密文数据
            string sReqData = ConvertDataType.Strem2String( HttpContext.Current.Request.InputStream, Encoding.UTF8 );

            int ret = this._wxcpt.DecryptMsg(sReqMsgSig, sReqTimeStamp, sReqNonce, sReqData, ref sMsg);
            if (ret != 0)
            {
                //System.Console.WriteLine("ERR: Decrypt Fail, ret: " + ret);
                return false;
            }
            return true;
        }

        //加密
        public bool SetEncryptionContent( string sRespData, ref string sEncryptMsg )
        {
            //如果为公众平台且未使用加密
            if(this._wxPlatType==WxPlatFormTypeEnum.GZ)
            {
                WXGZConfigEntity gzConfig = XmlToEntity.GetGZConfig();
                if ( string.IsNullOrEmpty( gzConfig.EncodingAESKey ) )
                {
                    sEncryptMsg = sRespData;
                    return true;
                }
            }
            int ret = this._wxcpt.EncryptMsg( sRespData, ConvertDateTime.GetTimeStamp(), new Random().Next(100000000,999999999).ToString(), ref sEncryptMsg );
            if ( ret != 0 )
            {
                //System.Console.WriteLine( "ERR: EncryptMsg Fail, ret: " + ret );
                return false;
            }
            return true;
        }
        //发送
        public void MsgResponse(string sMsgResponse)
        {
            HttpServerHelper.ResponseWrite( sMsgResponse );
        }
    }
}
