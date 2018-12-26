using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace Titan.Blog.Infrastructure.Utility
{
    public class ListHelper<T> : List<T>
    {
        public int DataCount { get; set; } //总记录数
        public int PageCount { get; set; } //总页数
        public int PageNo { get; set; } //当前页码
        public int PageSize { get; set; } //每页显示记录数
        //是否有上一页
        public bool HasPreviousPage
        {
            get { return PageNo > 1; }
        }

        //是否有下一页
        public bool HasNextPage
        {
            get { return PageNo < this.PageCount; }
        }

        /// <summary>
        /// 构造方法
        /// </summary>
        /// <param name="dataList"></param>
        /// <param name="pageSize"></param>
        /// <param name="pageNo"></param>
        public ListHelper(List<T> dataList, int pageSize, int pageNo)
        {
            this.PageSize = pageSize;
            this.PageNo = pageNo;
            this.DataCount = dataList.Count;
            this.PageCount = (int)Math.Ceiling((decimal)this.DataCount / pageSize);
            this.AddRange(dataList.Skip((pageNo - 1) * pageSize).Take(pageSize));
        }
    }
}
