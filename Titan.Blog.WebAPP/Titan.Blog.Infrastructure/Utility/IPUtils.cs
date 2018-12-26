/************************************************************************
 * 文件名：CheckIP
 * 文件功能描述：xx控制层
 * 作    者：  韩俊俊
 * 创建日期：2018/11/27 16:05:26
 * 修 改 人：
 * 修改日期：
 * 修改原因：
 * Copyright (c) 2017 Titan.Han . All Rights Reserved. 
 * ***********************************************************************/
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Text.RegularExpressions;
using System.Threading.Tasks;
using System.Web;
using Microsoft.AspNetCore.Http;
using Newtonsoft.Json;

namespace Titan.Blog.Infrastructure.Utility
{
    public class IPUtils
    {
        #region 获取浏览器版本号

        #endregion

        #region 获取操作系统版本号
        
        #endregion

        #region 获取客户端IP地址
        
        #endregion

        #region 取客户端真实IP

        #endregion

        #region  判断是否是IP格式
        ///  <summary>
        ///  判断是否是IP地址格式  0.0.0.0
        ///  </summary>
        ///  <param  name="str1">待判断的IP地址</param>
        ///  <returns>true  or  false</returns>
        public static bool IsIPAddress(string str1)
        {
            if (string.IsNullOrEmpty(str1) || str1.Length < 7 || str1.Length > 15) return false;

            const string regFormat = @"^d{1,3}[.]d{1,3}[.]d{1,3}[.]d{1,3}$";

            var regex = new Regex(regFormat, RegexOptions.IgnoreCase);
            return regex.IsMatch(str1);
        }
        #endregion

        #region 获取当前程序公网IP
        
        #endregion
    }
}
