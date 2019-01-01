using System;
using System.Collections.Generic;
using Titan.Model;

namespace Titan.Blog.Model.DataModel
{
    public partial class SysUserRole : IAggregateRoot
    {
        public Guid SysUserRoleId { get; set; }
        public Guid? SysUserId { get; set; }
        public Guid? SysRoleId { get; set; }
    }
}
