using System;
using System.Collections.Generic;
using Titan.Model;

namespace Titan.Blog.Model.DataModel
{
    public partial class SysRole : IAggregateRoot
    {
        public Guid SysRoleId { get; set; }
        public string RoleName { get; set; }
        public string RoleDesc { get; set; }
        public bool? RoleStatus { get; set; }
        public bool? IsDelete { get; set; }
        public Guid? SysUserId { get; set; }
        public string UserName { get; set; }
        public DateTime? CreateTime { get; set; }
        public Guid? ModifyId { get; set; }
        public string ModifyByName { get; set; }
        public DateTime? ModifyTime { get; set; }
    }
}
