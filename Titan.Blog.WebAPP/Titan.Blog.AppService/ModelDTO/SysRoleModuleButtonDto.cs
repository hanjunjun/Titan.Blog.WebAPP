/************************************************************************
 * 文件名：SysRoleModuleButtonDto
 * 文件功能描述：xx控制层
 * 作    者：  韩俊俊
 * 创建日期：2018/12/31 15:26:46
 * 修 改 人：
 * 修改日期：
 * 修改原因：
 * Copyright (c) 2017 . All Rights Reserved. 
 * ***********************************************************************/
using System;
using System.Collections.Generic;
using System.Text;
using Titan.Blog.Model.DataModel;

namespace Titan.Blog.AppService.ModelDTO
{
    public class SysRoleModuleButtonDto
    {
        public Guid SysRoleModuleButtonId { get; set; }
        public Guid? SysRoleId { get; set; }
        public Guid? SysModuleId { get; set; }
        public string AvailableButtonJson { get; set; }
        public int? ModuleType { get; set; }

        public SysRole SysRole { get; set; }

        public SysModule SysModule { get; set; }
    }
}
