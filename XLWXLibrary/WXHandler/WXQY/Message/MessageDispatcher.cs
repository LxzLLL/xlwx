using System;
using System.Collections.Generic;
using System.Text;
using System.IO;

using XLWXLibrary.WXEntity;
using XLToolLibrary.Utilities;
namespace XLWXLibrary.WXHandler.WXQY.Message
{
    /// <summary>
    /// 作者：Arvin
    /// 日期：2016/2/19 14:15:20
    /// 描述：消息分发器
    /// </summary>
    public class MessageDispatcher
    {
        /// <summary>
        /// 消息分发、处理
        /// </summary>
        /// <param name="strContent">消息内容</param>
        /// <returns></returns>
        public string Dispatcher( string strContent )
        {
            string strResponse = string.Empty;
            if(string.IsNullOrEmpty(strContent))
            {
                return strResponse;
            }
            //解析微信请求的消息内容，并找出MsgType
            Stream stream = ConvertDataType.String2Stream( strContent, Encoding.UTF8 );
            XmlHelper<Stream> xo = new XmlHelper<Stream>( stream );
            string sMsgType = xo.GetXElementContent( "xml.MsgType" );
            //根据消息内容的类型，使用不同的类进行处理
            switch(sMsgType.ToLower())
            {
                case "text":
                    strResponse = new MsgText( xo.GetObj<MessageTextEntity>( "xml" ) ).MsgResponse();
                    break;
                case "event":
                    strResponse = new MsgEvent( strContent ).MsgResponse();
                    break;
                default:
                    break;
            }
            
            return strResponse;
        }
    }
}
