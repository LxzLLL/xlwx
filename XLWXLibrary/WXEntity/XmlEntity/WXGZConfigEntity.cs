using System;
using System.Xml.Serialization;

namespace XLWXLibrary.WXEntity.XmlEntity
{
    /// <summary>
    /// 作者：Arvin
    /// 日期：2016/2/19 9:32:58
    /// 描述：公众号的token等配置实体
    /// </summary>
    [XmlRoot( "GZConfig" )]
    public class WXGZConfigEntity
    {
        [XmlElement( "Token" )]
        public string Token { get; set; }
        [XmlElement( "AppID" )]
        public string AppID { get; set; }
        [XmlElement( "EncodingAESKey" )]
        public string EncodingAESKey { get; set; }

        public override string ToString()
        {
            return this.Token + "," + this.AppID+"，"+this.EncodingAESKey;
        }
    }
}
