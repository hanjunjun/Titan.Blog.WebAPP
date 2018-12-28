/************************************************************************
 * 文件名：MyHttpContext
 * 文件功能描述：xx控制层
 * 作    者：  韩俊俊
 * 创建日期：2018/12/24 17:06:00
 * 修 改 人：
 * 修改日期：
 * 修改原因：
 * Copyright (c) 2017 Titan.Han . All Rights Reserved. 
 * ***********************************************************************/
using Microsoft.AspNetCore.Http;
using System;
using System.Collections.Generic;
using System.Text;

namespace Titan.Blog.Infrastructure.HttpExtenions
{
    public class HttpContext
    {
        private static IHttpContextAccessor _accessor;

        public static Microsoft.AspNetCore.Http.HttpContext Current => _accessor?.HttpContext;

        internal static void Configure(IHttpContextAccessor accessor)
        {
            _accessor = accessor;
        }
    }
}
