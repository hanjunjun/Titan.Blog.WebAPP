using System.Collections.Generic;

namespace Titan.Blog.Model.DataModel
{
    public partial class Main : AggregateRoot
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
