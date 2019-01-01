using System;
using System.Collections.Generic;
using Titan.Model;

namespace Titan.Blog.Model.DataModel
{
    public partial class SysUser : IAggregateRoot
    {
        public Guid SysUserId { get; set; }
        public string UserId { get; set; }
        public string UserPwd { get; set; }
        public int? UserType { get; set; }
        public int? UserStatus { get; set; }
        public string Telphone { get; set; }
    }
}
