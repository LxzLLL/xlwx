using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Xml.Linq;
using System.IO;
using System.Xml;

namespace XLToolLibrary.Utilities
{
    /// <summary>
    /// 作者：Arvin
    /// 日期：2016/1/22 14:23:33
    /// 描述：xml操作
    ///          T:string、stream、TextReader、XmlReader
    /// </summary>
    public class XmlHelper<T>
    {

        #region 字段
        /// <summary>
        /// XElement对象
        /// </summary>
        private XElement _xele = null;
        #endregion

        #region 属性

        /// <summary>
        /// xml来源属性，string、stream、TextReader、XmlReader
        /// </summary>
        public T XmlSource { get; private set; }

        /// <summary>
        /// xml处理错误信息
        /// </summary>
        public string XmlError { get; private set; }
        /// <summary>
        /// XmlElement对象
        /// </summary>
        public XElement XElement
        {
            get
            {
                return this._xele;
            }
        }
        #endregion

        #region 初始化

        /// <summary>
        /// 不需要无参构造函数
        /// </summary>
        private XmlHelper()
        {

        }

        /// <summary>
        /// 初始化
        /// </summary>
        /// <param name="strPath"></param>
        public XmlHelper(T xmlSource)
        {
            this.XmlSource = xmlSource;
            this.XmlSourceLoad();
        }

        #endregion

        #region 读取
        //----获取节点
        /// <summary>
        /// 根据提供的格式化字符串获取对象列表
        /// 格式必须为："x.y.z"，以点号分隔
        /// </summary>
        /// <typeparam name="C">类型</typeparam>
        /// <param name="strFormat">格式化字符串</param>
        /// <param name="types">xml反序列化包含的额外的类型</param>
        /// <returns>List<T>，如果未找到则返回默认的T列表</returns>
        public List<C> GetObject<C>( string strFormat, Type[ ] extraTypes = null )
        {
            List<C> tlist = new List<C>();
            List<XElement> listXEle = GetXEleFromStrFormat( strFormat );
            if ( listXEle == null || listXEle.Count<=0 )
                return tlist;
            System.Xml.Serialization.XmlSerializer xs = null;
            if ( extraTypes == null )
            {
                xs = new System.Xml.Serialization.XmlSerializer( typeof( C ) );
            }
            else
            {
                xs = new System.Xml.Serialization.XmlSerializer( typeof( C ), extraTypes );
            }
            try
            {
                foreach ( XElement xe in listXEle )
                {
                    C t = ( C )xs.Deserialize( xe.CreateReader());
                    tlist.Add( t );
                }
            }
            catch(Exception ex)
            {
                this.XmlError = ex.Message;
            }
            return tlist;
        }

        /// <summary>
        /// 根据提供的格式化字符串获取对象（如果多个，则取第一个）
        /// 格式必须为："x.y.z"，以点号分隔
        /// </summary>
        /// <typeparam name="C"></typeparam>
        /// <param name="strFormat"></param>
        /// <param name="extraTypes"></param>
        /// <returns></returns>
        public C GetObj<C>(string strFormat,Type[] extraTypes=null)
        {
            C c = default( C );
            List<C> cs = this.GetObject<C>(strFormat,extraTypes);
            if(cs.Count>0)
            {
                c = cs[ 0 ];
            }
            return c;
        }

        /// <summary>
        /// 通过格式化的字符串获取XElement对象列表
        /// </summary>
        /// <param name="strFormat">格式化字符串，格式必须为："x.y.z"，以点号分隔</param>
        /// <returns>未找到返回null</returns>
        public List<XElement> GetXEleFromStrFormat( string strFormat )
        {
            List<XElement> listEleRtn = null;
            if ( string.IsNullOrEmpty( strFormat ) )
                return listEleRtn;
            string[] arrNode = strFormat.Split( '.' );
            if ( this.XElement == null )
            {
                return listEleRtn;
            }
            var varEle = from el in this.XElement.DescendantsAndSelf( arrNode[ 0 ] )
                         select el;
            if ( varEle.Count() <= 0 )
            {
                return listEleRtn;
            }
            List<XElement> listvarEle = varEle.ToList<XElement>();
            //如果只有一个层级，则返回listvarEle
            if ( arrNode.Length == 1 )
            {
                return listvarEle;
            }
            List<XElement> listxeleTemp = listvarEle;
            int arrNodeLength = arrNode.Length;
            for ( int i=1 ; i < arrNodeLength ; i++ )
            {
                listxeleTemp = new List<XElement>();
                foreach ( XElement xe in listvarEle )
                {
                    var varel = from el in xe.DescendantsAndSelf( arrNode[ i ] ) select el;
                    if ( varel.Count() > 0 )
                    {
                        listxeleTemp.AddRange( varel.ToList<XElement>() );
                    }
                }
                if ( listxeleTemp.Count > 0 )
                {
                    listvarEle = listxeleTemp;
                    //如果遍历到最后一个名称，则将XElement对象列表返回，否则返回null
                    if ( i == arrNodeLength - 1 )
                    {
                        listEleRtn = listvarEle;
                    }
                }
                else
                    break;
            }
            return listEleRtn;
        }

        /// <summary>
        /// 通过格式化的字符串获取XElement对象（如果多个，则取第一个）
        /// </summary>
        /// <param name="strFormat">格式化字符串，格式必须为："x.y.z"，以点号分隔</param>
        /// <returns></returns>
        public XElement GetXElement(string strFormat)
        {
            XElement xe=null;
            List<XElement> xes = this.GetXEleFromStrFormat( strFormat );
            if ( xes!=null && xes.Count > 0 )
            {
                xe = xes[ 0 ];
            }
            return xe;
        }
        /// <summary>
        /// 通过格式化的字符串获取XElement对象的内容（如果多个，则取第一个）
        /// </summary>
        /// <param name="strFormat">格式化字符串，格式必须为："x.y.z"，以点号分隔</param>
        /// <returns></returns>
        public string GetXElementContent(string strFormat)
        {
            string strResult = string.Empty;
            XElement xe = this.GetXElement( strFormat );
            if(xe==null)
            {
                return strResult;
            }
            strResult = xe.Value;
            return strResult;
        }

        //-----获取内容
        #endregion

        #region 写入
        /// <summary>
        /// 写入XElement节点内容
        /// </summary>
        /// <param name="strFormat">格式化字符串</param>
        /// <param name="strContent">写入的内容</param>
        public void WriteXmlByElement( XElement xele, string strContent )
        {
            xele.SetValue( strContent );
        }

        #endregion


        #region 私有方法

        /// <summary>
        /// xml加载
        /// xml来源类型验证是否有效，如果不为string、stream、TextReader、XmlReader，则返回false
        /// </summary>
        /// <returns></returns>
        private bool XmlSourceLoad()
        {
            bool isValid = false;
            if(this.XmlSource != null)
            {
                try
                {
                    if ( this.XmlSource is String )
                    {
                        this._xele = XElement.Load( this.XmlSource as string );
                    }
                    else if ( this.XmlSource is Stream )
                    {
                        //流用完关闭
                        using ( Stream stream  = this.XmlSource as Stream )
                        {
                            this._xele = XElement.Load( stream );
                        }
                    }
                    else if ( this.XmlSource is TextReader )
                    {
                        this._xele = XElement.Load( this.XmlSource as TextReader );
                    }
                    else if ( this.XmlSource is System.Xml.XmlReader )
                    {
                        this._xele = XElement.Load( this.XmlSource as System.Xml.XmlReader );
                    }
                    else
                    {
                        throw new Exception( "不是指定的xml源类型" );
                    }
                    isValid = true;
                }
                catch(Exception ex)
                {
                    this.XmlError = ex.Message;
                    isValid = false;
                }
            }
            else
            {
                this.XmlError = "指定的xml源为null";
            }
            return isValid;
        }

        
        #endregion
    }
}
