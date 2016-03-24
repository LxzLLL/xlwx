using System;
using System.Reflection;
using System.ComponentModel;

namespace XLToolLibrary.Utilities
{
    /// <summary>
    /// 作者：Arvin
    /// 日期：2016/2/16 10:09:58
    /// 描述：枚举的扩展
    /// </summary>
    public static class EnumHelper
    {
        /// <summary>
        /// Enum的扩展方法，获取枚举的“特性（Attribute）”；
        /// 枚举中的成员需要使用[Description( "***" )]特性
        /// </summary>
        /// <param name="en"></param>
        /// <returns>返回特性Description的文本， 如果没有Description特性值，则返回此枚举的字符串</returns>
        public static string GetDescription(this Enum en)
        {
            string strDescription  = en.ToString();
            Type t = en.GetType();
            MemberInfo[] memInfo = t.GetMember( strDescription );
            if ( memInfo != null && memInfo.Length > 0 )
            {
                object[] attrs= memInfo[ 0 ].GetCustomAttributes( typeof( DescriptionAttribute ), false );
                if ( attrs != null && attrs.Length > 0 )
                {
                    strDescription = ( ( DescriptionAttribute )attrs[ 0 ] ).Description;
                }
            }
            return strDescription;
        }
    }
}
