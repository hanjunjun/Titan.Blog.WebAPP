using System;

namespace Titan.Blog.Model.DataModel
{
    public partial class SysOperateLog : AggregateRoot
    {
        public Guid SysOperateLogId { get; set; }
        public string Controller { get; set; }
        public string Action { get; set; }
        public string LinkUrl { get; set; }
        public string Ipaddress { get; set; }
        public DateTime? OperateTime { get; set; }
        public Guid? SysUserId { get; set; }
        public string UserName { get; set; }
        public string OperateDesc { get; set; }
        public int? OperateType { get; set; }
        public Guid? BusinessId { get; set; }
        public bool? IsDelete { get; set; }
    }
}
