using System;

namespace Titan.Blog.Model.DataModel
{
    public partial class SysButton : AggregateRoot
    {
        public Guid SysButtonId { get; set; }
        public Guid? SysModuleId { get; set; }
        public int? ButtonCode { get; set; }
        public string ButtonName { get; set; }
    }
}
