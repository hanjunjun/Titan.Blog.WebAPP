/************************************************************************
 * 文件名：UserInfo
 * 文件功能描述：xx控制层
 * 作    者：  韩俊俊
 * 创建日期：2019/1/30 16:35:57
 * 修 改 人：
 * 修改日期：
 * 修改原因：
 * Copyright (c) 2017 . All Rights Reserved. 
 * ***********************************************************************/
using System;
using System.Collections.Generic;
using System.Text;

namespace Titan.Blog.Model.CommonModel
{
    public class UserInfo
    {
        public Guid SysUserId { get; set; }
        public string UserName { get; set; }
        public string UserId { get; set; }
        public int? UserType { get; set; }
        public string Telphone { get; set; }
    }
}
