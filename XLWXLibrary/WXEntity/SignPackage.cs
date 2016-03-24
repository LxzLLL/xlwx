using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using XLToolLibrary.Utilities;
namespace XLWXLibrary.WXEntity
{
    /// <summary>
    /// 作者：Arvin
    /// 日期：2016/3/2 16:35:09
    /// 描述：JSSDK中使用的配置类（wx.config）
    /// </summary>
    public class SignPackage
    {
        /// <summary>
        ///  调试模式，默认为false
        /// </summary>
        public string debug
        {
            get
            {
                return this._debug;
            }
            set
            {
                this._debug = value;
            }
        }
        private string _debug  = "false";
        /// <summary>
        /// 企业号的唯一标识，此处填写企业号corpid
        /// </summary>
        public string appId { get; set; }
        /// <summary>
        /// 生成签名的时间戳
        /// </summary>
        public string timestamp { get; set; }
        /// <summary>
        /// 生成签名的随机串
        /// </summary>
        public string nonceStr { get; set; }
        /// <summary>
        /// 签名
        /// </summary>
        public string signature { get; set; }
        /// <summary>
        /// 生成签名的随机串
        /// </summary>
        public string[] jsApiList { get; set; }
    }
}
