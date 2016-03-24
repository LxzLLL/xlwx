using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace XLToolLibrary.Utilities
{
    /// <summary>
    /// 作者：Arvin
    /// 日期：2016/1/27 10:41:40
    /// 描述：
    /// </summary>
    public class ConvertDateTime
    {
        /// <summary>
        /// 指示转换是否成功
        /// </summary>
        public bool IsSuccess { get; private set; }
        /// <summary>
        /// 转换失败时提示的错误信息
        /// </summary>
        public string ConvertError { get; private set; }


        /// <summary>
        /// 统一字符串转日期格式“yyyy-mm-dd HH:MM:ss”
        /// </summary>
        /// <param name="strDt"></param>
        /// <returns>如果转换失败，则返回default(DateTime)</returns>
        public DateTime String2DataTime(string strDt)
        {
            DateTime dt = default(DateTime);
            this.IsSuccess = DateTime.TryParse( strDt, out dt );
            if(!this.IsSuccess)
            {
                this.ConvertError = "字符串转换日期格式失败！";
            }
            return dt;
        }

        /// <summary>  
        /// 获取时间戳  
        /// </summary>  
        /// <returns></returns>  
        public static string GetTimeStamp()
        {
            TimeSpan ts = DateTime.UtcNow - new DateTime( 1970, 1, 1, 0, 0, 0, 0 );
            return Convert.ToInt64( ts.TotalSeconds ).ToString();
        } 

    }
}
