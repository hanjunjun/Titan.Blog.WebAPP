using System;
using System.Collections.Generic;
using Titan.Model;

namespace Titan.Blog.Model.DataModel
{
    public partial class SysRoleModuleButton : IAggregateRoot
    {
        public Guid SysRoleModuleButtonId { get; set; }
        public Guid? SysRoleId { get; set; }
        public Guid? SysModuleId { get; set; }
        public string AvailableButtonJson { get; set; }
        public int? ModuleType { get; set; }
    }
}
