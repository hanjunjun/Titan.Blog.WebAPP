using System;
using System.Collections.Generic;
using Titan.Model;

namespace Titan.Blog.Model.DataModel
{
    public partial class Main : IAggregateRoot
    {
        public Main()
        {
            Children = new HashSet<Children>();
        }

        public int Id { get; set; }
        public string Name { get; set; }
        public string Telphone { get; set; }

        public virtual ICollection<Children> Children { get; set; }
    }
}
