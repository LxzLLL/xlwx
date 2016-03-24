using System;
using System.Xml.Serialization;

namespace XLWXLibrary.WXEntity.XmlEntity
{
    /// <summary>
    /// 作者：Arvin
    /// 日期：2016/1/26 12:52:10
    /// 描述：配置路由与处理Handler的映射实体
    /// </summary>
    [XmlRoot( "RouteItem" )]
    public class RouteItemEntity
    {
        [XmlElement( "Controller" )]
        public string Controller { get; set; }
        [XmlElement( "ClassName" )]
        public string ClassName { get; set; }
        [XmlElement( "AssemblyName" )]
        public string AssemblyName { get; set; }
        [XmlElement( "WxPlatFormType" )]
        public string WxPlatFormType { get; set; }

        public override string ToString()
        {
            return this.Controller + "," + this.ClassName;
        }
    } 
}
