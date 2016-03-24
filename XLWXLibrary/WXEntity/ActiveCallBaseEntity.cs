using System;
using System.Collections.Generic;
using System.Text;

namespace XLWXLibrary.WXEntity
{
    /// <summary>
    /// 作者：Arvin
    /// 日期：2016/2/17 11:35:49
    /// 描述：主动调用对象的基类
    /// </summary>
    public class ActiveCallBaseEntity
    {
        /// <summary>
        /// 不带action和参数的URL，例如https://qyapi.weixin.qq.com/cgi-bin/department；
        /// action在各自类的方法中定义
        /// </summary>
        public string Url { get; set; }
        private string _protocol = "https";
        /// <summary>
        /// 访问协议，http或https，默认为https
        /// </summary>
        public string Protocol
        {
            get
            {
                return this._protocol;
            }
            set
            {
                this._protocol = value;
            }
        }
        private string _method = "post";
        /// <summary>
        /// 请求方式get或post，默认为post
        /// </summary>
        public string Method
        {
            get
            {
                return this._method;
            }
            set
            {
                this._method = value;
            }
        }
        /// <summary>
        /// 令牌，用于参数
        /// </summary>
        public string AccessToken { get; set; }
        /// <summary>
        /// 除access_token外的参数集合
        /// </summary>
        public Dictionary<string, string> Params { get; set; }

        private string _content = string.Empty;
        /// <summary>
        /// post要发送的内容
        /// </summary>
        public string Content
        {
            get
            {
                return this._content;
            }
            set
            {
                this._content = value;
            }
        }

        private Encoding _postEncoding = Encoding.UTF8;
        /// <summary>
        /// 要发送内容的编码
        /// </summary>
        public Encoding PostEncoding
        {
            get
            {
                return this._postEncoding;
            }
            set
            {
                this._postEncoding = value;
            }
        }
    }
}
