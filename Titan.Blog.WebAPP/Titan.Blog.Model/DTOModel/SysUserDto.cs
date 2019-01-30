/************************************************************************
 * 文件名：SysUserDto
 * 文件功能描述：xx控制层
 * 作    者：  韩俊俊
 * 创建日期：2019/1/19 15:48:00
 * 修 改 人：
 * 修改日期：
 * 修改原因：
 * Copyright (c) 2017 . All Rights Reserved. 
 * ***********************************************************************/

using System;

namespace Titan.Blog.Model.DTOModel
{
    public class SysUserDto
    {
        public Guid SysUserId { get; set; }
        public string UserId { get; set; }
        public string UserName { get; set; }
        public string UserPwd { get; set; }
        public int? UserType { get; set; }
        public int? UserStatus { get; set; }
        public string Telphone { get; set; }
    }
}
