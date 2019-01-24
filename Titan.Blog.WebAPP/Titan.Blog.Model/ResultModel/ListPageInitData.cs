using System.Collections.Generic;

namespace Titan.Blog.Model.ResultModel
{
    /// <summary>
    /// 列表初始化信息
    /// </summary>
    /// <typeparam name="TInitData"></typeparam>
    public class ListPageInitData<TInitData>
    {
        /// <summary>
        /// 权限列表
        /// </summary>
        public IList<PermissionFuncItem> PermBtnsInfo { get; set; }

        /// <summary>
        /// 列头设置
        /// </summary>
        public IList<TableColumnItem> ColsInfo { get; set; }

        /// <summary>
        /// 列表初始化数据对象(包含查询条件默认值,页面值等)
        /// </summary>
        public TInitData InitData { get; set; }

        /// <summary>
        /// 构造函数
        /// </summary>
        public ListPageInitData()
        {
            //todo 变量名调整
            PermBtnsInfo = new List<PermissionFuncItem>();
            ColsInfo = new List<TableColumnItem>();
        }
    }
}
