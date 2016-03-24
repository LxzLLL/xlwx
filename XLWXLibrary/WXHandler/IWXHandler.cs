using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace XLWXLibrary.WXHandler
{
    /// <summary>
    /// 微信handler接口
    /// </summary>
    interface IWXHandler
    {
        /// <summary>
        /// 处理请求
        /// </summary>
        void ProcessRequest();
    }
}
