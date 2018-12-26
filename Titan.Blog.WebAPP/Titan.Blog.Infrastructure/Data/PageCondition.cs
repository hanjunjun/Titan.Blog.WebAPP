namespace Titan.Blog.Infrastructure.Data
{
    /// <summary>
    /// 分页条件
    /// </summary>
    public class PageCondition
    {
        /// <summary>
        /// 页码(从1开始)
        /// </summary>
        public int PageIndex { get; set; }

        /// <summary>
        /// 单页数据量
        /// </summary>
        public int PageSize { get; set; }

        /// <summary>
        /// 排序条件组
        /// </summary>
        public SortCondition[] SortConditions { get; set; }

        /// <summary>
        /// 无参构造函数
        /// </summary>
        public PageCondition()
            : this(1, 10)
        { }

        /// <summary>
        /// 构造函数
        /// </summary>
        /// <param name="_pageindex"></param>
        /// <param name="_pagesize"></param>
        public PageCondition(int _pageindex, int _pagesize)
        {
            PageIndex = _pageindex > 0 ? _pageindex : 1;
            PageSize = _pagesize > 0 ? _pagesize : 10;
            SortConditions = new SortCondition[] { };
        }
    }
}