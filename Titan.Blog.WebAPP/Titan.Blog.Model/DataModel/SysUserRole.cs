using System;

namespace Titan.Blog.Model.DataModel
{
    public partial class SysUserRole : AggregateRoot
    {
        public Guid SysUserRoleId { get; set; }
        public Guid? SysUserId { get; set; }
        public Guid? SysRoleId { get; set; }
    }
}
