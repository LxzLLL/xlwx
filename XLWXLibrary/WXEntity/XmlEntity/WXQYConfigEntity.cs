using System;
using System.Xml.Serialization;

namespace XLWXLibrary.WXEntity.XmlEntity
{
    /// <summary>
    /// 作者：Arvin
    /// 日期：2016/2/19 9:35:19
    /// 描述：
    /// </summary>
    [XmlRoot( "QYConfig" )]
    public class WXQYConfigEntity
    {
        [XmlElement( "Token" )]
        public string Token { get; set; }
        [XmlElement( "CorpID" )]
        public string CorpID { get; set; }
        [XmlElement( "AgentID" )]
        public string AgentID { get; set; }
        [XmlElement( "EncodingAESKey" )]
        public string EncodingAESKey { get; set; }

        public override string ToString()
        {
            return this.Token + "," + this.CorpID +"，"+this.AgentID+ "，" + this.EncodingAESKey;
        }
    }
}
