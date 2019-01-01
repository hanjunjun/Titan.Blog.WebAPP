using System;
using System.Collections.Generic;
using Titan.Model;

namespace Titan.Blog.Model.DataModel
{
    public partial class SysButton : IAggregateRoot
    {
        public Guid SysButtonId { get; set; }
        public Guid? SysModuleId { get; set; }
        public int? ButtonCode { get; set; }
        public string ButtonName { get; set; }
    }
}
