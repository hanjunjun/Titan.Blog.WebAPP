using System;

namespace Titan.Blog.Model.DataModel
{
    public partial class SysModule : AggregateRoot
    {
        public Guid SysModuleId { get; set; }
        public string ModuleName { get; set; }
        public string LinkUrl { get; set; }
        public string Controller { get; set; }
        public string Action { get; set; }
        public bool? ModuleStatus { get; set; }
        public int? Sort { get; set; }
        public Guid? ParentId { get; set; }
        public string ModuleIcon { get; set; }
        public bool? IsDelete { get; set; }
        public string ModuleDesc { get; set; }
        public int? ModuleType { get; set; }
        public Guid? SysUserId { get; set; }
        public string UserName { get; set; }
        public DateTime? CreateTime { get; set; }
        public Guid? ModifyId { get; set; }
        public string ModifyByName { get; set; }
        public DateTime? ModifyTime { get; set; }
    }
}
