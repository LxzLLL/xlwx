using System;
using System.Security.Cryptography;

namespace XLToolLibrary.Utilities
{
    /// <summary>
    /// 作者：Arvin
    /// 日期：2016/3/2 15:38:34
    /// 描述：sha加密
    /// </summary>
    public class ShaHelper
    {
        /// <summary>
        /// sha1加密字符串，并返回圈小写
        /// </summary>
        /// <param name="strEncryption"></param>
        /// <returns></returns>
        public static string StrSha1Lower( string strEncryption )
        {
            Byte[] bytes = System.Text.Encoding.UTF8.GetBytes( strEncryption );
            SHA1CryptoServiceProvider scsp = new SHA1CryptoServiceProvider();
            Byte[] byteTemp =  scsp.ComputeHash( bytes );
            scsp.Clear();
            string strRtn = BitConverter.ToString( byteTemp ).Replace( "-", "" ).ToLower();
            return strRtn;
        }
    }
}
