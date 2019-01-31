namespace Titan.Blog.Model.CommonModel.ResultModel
{
    /// <summary>
    /// 列表信息的列头设置
    /// </summary>
    public class TableColumnItem
    {
        /// <summary>
        /// 列名称
        /// </summary>
        public string ColumnName { get; set; }

        /// <summary>
        /// 列字段
        /// </summary>
        public string DataField { get; set; }

        /// <summary>
        /// 表示数据类型的字符串
        /// </summary>
        public string DataType { get; set; }

        /// <summary>
        /// 宽度
        /// </summary>
        public string ColWidth { get; set; }

        /// <summary>
        /// 对齐方式
        /// </summary>
        public string TextAlign { get; set; }

        /// <summary>
        /// 是否显示
        /// </summary>
        public int IsShow { get; set; }

        /// <summary>
        /// 无参构造函数
        /// </summary>
        public TableColumnItem()
            : this(string.Empty, string.Empty, string.Empty, string.Empty, string.Empty, 0)
        { }

        /// <summary>
        /// 构造函数
        /// </summary>
        /// <param name="_columnName"></param>
        /// <param name="_dataField"></param>
        /// <param name="_dataType"></param>
        /// <param name="_colWidth"></param>
        /// <param name="_textAlign"></param>
        /// <param name="_isShow"></param>
        public TableColumnItem(string _columnName, string _dataField, string _dataType, string _colWidth, string _textAlign, int _isShow)
        {
            ColumnName = _columnName;
            DataField = _dataField;
            DataType = _dataType;
            ColWidth = _colWidth;
            TextAlign = _textAlign;
            IsShow = _isShow;
        }
    }
}
