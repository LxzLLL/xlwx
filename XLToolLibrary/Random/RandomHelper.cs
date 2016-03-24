using System;

namespace XLToolLibrary.Utilities
{
    /// <summary>
    /// 作者：Arvin
    /// 日期：2016/3/2 15:57:18
    /// 描述：随机数的生成
    /// </summary>
    public class RandomHelper
    {
        /// <summary>
        /// 数字、字母列表
        /// </summary>
        private static char[] constant =   {   
            '0','1','2','3','4','5','6','7','8','9',  
            'a','b','c','d','e','f','g','h','i','j','k','l','m','n','o','p','q','r','s','t','u','v','w','x','y','z',   
            'A','B','C','D','E','F','G','H','I','J','K','L','M','N','O','P','Q','R','S','T','U','V','W','X','Y','Z'   
          };
        /// <summary>
        /// 生成指定长度的随机数
        /// </summary>
        /// <param name="Length"></param>
        /// <returns></returns>
        public static string GenerateRandomNumber( int Length )
        {
            System.Text.StringBuilder newRandom = new System.Text.StringBuilder( 62 );
            Random rd = new Random();
            for ( int i = 0 ; i < Length ; i++ )
            {
                newRandom.Append( constant[ rd.Next( 62 ) ] );
            }
            return newRandom.ToString();
        }
    }
}
