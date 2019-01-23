namespace Titan.Blog.Model.DataModel
{
    public partial class Children : AggregateRoot
    {
        public int Id { get; set; }
        public int? MainId { get; set; }
        public string Name { get; set; }
        public string Sex { get; set; }

        public virtual Main Main { get; set; }
    }
}
