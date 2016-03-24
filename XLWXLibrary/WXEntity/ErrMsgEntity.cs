using System;
using System.Collections.Generic;
using System.Text;

namespace XLWXLibrary.WXEntity
{
    /// <summary>
    /// 作者：Arvin
    /// 日期：2016/2/29 16:18:39
    /// 描述：微信返回消息基类
    /// </summary>
    public class ErrMsgEntity
    {
        /// <summary>
        /// 返回结果编码
        /// </summary>
        public string errcode { get; set; }
        /// <summary>
        /// 返回结果描述
        /// </summary>
        public string errmsg { get; set; }
    }
}
