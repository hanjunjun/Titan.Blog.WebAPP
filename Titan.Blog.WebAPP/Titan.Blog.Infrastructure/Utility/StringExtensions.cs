using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Titan.Blog.Infrastructure.Utility
{
    /// <summary>
    /// 字符串扩展
    /// </summary>
    public static class StringExtensions
    {
        /// <summary>
        /// 将<see cref="byte"/>[]数组转换为Base64字符串
        /// </summary>
        public static string ToBase64String(this byte[] bytes)
        {
            return Convert.ToBase64String(bytes);
        }

        /// <summary>
        /// 将字符串转换为Base64字符串，默认编码为<see cref="Encoding.UTF8"/>
        /// </summary>
        /// <param name="source">正常的字符串</param>
        /// <param name="encoding">编码</param>
        /// <returns>Base64字符串</returns>
        public static string ToBase64String(this string source, Encoding encoding = null)
        {
            if (encoding == null)
            {
                encoding = Encoding.UTF8;
            }
            return Convert.ToBase64String(encoding.GetBytes(source));
        }

        /// <summary>
        /// 将Base64字符串转换为正常字符串，默认编码为<see cref="Encoding.UTF8"/>
        /// </summary>
        /// <param name="base64String">Base64字符串</param>
        /// <param name="encoding">编码</param>
        /// <returns>正常字符串</returns>
        public static string FromBase64String(this string base64String, Encoding encoding = null)
        {
            if (encoding == null)
            {
                encoding = Encoding.UTF8;
            }
            byte[] bytes = Convert.FromBase64String(base64String);
            return encoding.GetString(bytes);
        }
        /// <summary>
        /// 将string转换为GUID
        /// </summary>
        /// <param name="strGuid">string字符串</param>
        /// <returns></returns>
        public static Guid GetGuid(this string strGuid)
        {
            Guid newId = Guid.Empty;
            Guid.TryParse(strGuid, out newId);
            return newId;
        }

        /// <summary>
        /// 指示指定的字符串是 null 还是 System.String.Empty 字符串。
        /// </summary>
        /// <param name="str">要测试的字符串。</param>
        /// <returns>如果 value 参数为 null 或空字符串 ("")，则为 true；否则为 false。</returns>
        public static bool IsNullOrEmpty(this string str)
        {
            return string.IsNullOrEmpty(str);
        }

        /// <summary>
        /// 指示指定的字符串是 null、空还是仅由空白字符组成。
        /// </summary>
        /// <param name="str">要测试的字符串。</param>
        /// <returns>如果 value 参数为 null 或 System.String.Empty，或者如果 value 仅由空白字符组成，则为 true。</returns>
        public static bool IsNullOrWhiteSpace(this string str)
        {
            return string.IsNullOrWhiteSpace(str);
        }

        /// <summary>
        /// <para>遮挡部分字符串</para>
        /// <para>例1：("123456789").ToCover(2,3)=="12***6789" (return true)</para>
        /// <para>例2：("123456789").ToCover(2,3,"@")=="12@@@6789" (return true)</para>
        /// <para>例3：("123456789").ToCover(2,3,"$",true)=="12$6789" (return true)</para>
        /// <para>例4：("123456789").ToCover(2,3,"####",true)=="12####6789" (return true)</para>
        /// </summary>
        /// <param name="str">原始字符串</param>
        /// <param name="notToCoverLengthOfHeader">字符串从头部开始，保持不变的字符串长度(头部[notToCoverLengthOfHeader]个字符串保持不变)</param>
        /// <param name="coverLength">要遮挡的字符串长度</param>
        /// <param name="coverStr">用于遮挡的字符串</param>
        /// <param name="isCoverStrShowOnce">遮挡字符串是否仅显示一次</param>
        /// <returns>
        /// 替换遮挡字符串后的新字符串。
        /// 如果传入参数错误，则返回string.Empty
        /// </returns>
        public static string ToCover(this string str, int notToCoverLengthOfHeader, int coverLength, string coverStr = "*", bool isCoverStrShowOnce = false)
        {
            //省略的字符串长度为0时,相当于不处理
            if (coverLength <= 0) return str;

            //参数检查
            if (str.IsNullOrEmpty()) return string.Empty;
            if (notToCoverLengthOfHeader < 0) return string.Empty;
            if (notToCoverLengthOfHeader + coverLength > str.Length) return string.Empty;
            if (notToCoverLengthOfHeader >= str.Length) return string.Empty;
            if (coverLength > str.Length) return string.Empty;

            //如果用于遮挡的字符串为空字符串,则不处理,直接返回
            if (coverStr.IsNullOrEmpty()) return str;

            //开始计算结果字符串
            //构建中间省略部分字符串
            var middle = string.Empty;
            if (isCoverStrShowOnce)
            {
                middle = coverStr;
            }
            else
            {
                StringBuilder replaceMiddle = new StringBuilder(coverLength * coverStr.Length);
                for (int i = 0; i < coverLength; i++)
                {
                    replaceMiddle.Append(coverStr);
                }
                middle = replaceMiddle.ToString();
            }

            //头部未省略显示的字符串
            string header = str.Substring(0, notToCoverLengthOfHeader);
            //尾部未省略显示的字符串
            string footer = str.Substring(notToCoverLengthOfHeader + coverLength);

            return string.Format("{0}{1}{2}", header, middle, footer);
        }

        /// <summary>
        /// <para>遮挡部分字符串</para>
        /// <para>例1：("123456789").ToCoverMiddle(2,3)=="12****789" (return true)</para>
        /// <para>例2：("123456789").ToCoverMiddle(2,3,"@")=="12@@@@789" (return true)</para>
        /// <para>例3：("123456789").ToCoverMiddle(2,3,"$",true)=="12$789" (return true)</para>
        /// <para>例4：("123456789").ToCoverMiddle(2,3,"###",true)=="12###789" (return true)</para>
        /// </summary>
        /// <param name="str">原始字符串</param>
        /// <param name="notToCoverLengthOfHeader">字符串从头部开始，保持不变的字符串长度(头部[notToCoverLengthOfHeader]个字符串保持不变)</param>
        /// <param name="notToCoverLengthOfFooter">字符串从尾部开始，保持不变的字符串长度(尾部[notToCoverLengthOfFooter]个字符串保持不变)</param>
        /// <param name="coverStr">用于遮挡的字符串</param>
        /// <param name="isCoverStrShowOnce">遮挡字符串是否仅显示一次</param>
        /// <returns>
        /// 替换遮挡字符串后的新字符串。
        /// 如果传入参数错误，则返回string.Empty
        /// </returns>
        public static string ToCoverMiddle(this string str, int notToCoverLengthOfHeader, int notToCoverLengthOfFooter, string coverStr = "*", bool isCoverStrShowOnce = false)
        {
            //参数检查
            if (str.IsNullOrEmpty()) return string.Empty;
            if (notToCoverLengthOfHeader < 0 || notToCoverLengthOfFooter < 0) return string.Empty;
            if (notToCoverLengthOfHeader + notToCoverLengthOfFooter > str.Length) return string.Empty;
            if (notToCoverLengthOfHeader >= str.Length) return string.Empty;
            if (notToCoverLengthOfFooter > str.Length) return string.Empty;

            //如果替代字符串为空字符串,则不处理,直接返回
            if (coverStr.IsNullOrEmpty()) return str;

            //前后不省略的字符串长度等于原始字符串长度时,相当于不处理
            if (notToCoverLengthOfHeader + notToCoverLengthOfFooter == str.Length) return str;

            //开始计算结果字符串
            //中间省略部分长度
            var middle_length = str.Substring(notToCoverLengthOfHeader, str.Length - notToCoverLengthOfFooter - notToCoverLengthOfHeader).Length;

            return str.ToCover(notToCoverLengthOfHeader, middle_length, coverStr, isCoverStrShowOnce);
        }
    }
}
