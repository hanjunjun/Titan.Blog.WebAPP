namespace Titan.Blog.Model.ResultModel
{
    /// <summary>
    /// 可选项目
    /// </summary>
    public class OptionItem : IOptionItem<string, string>
    {
        /// <summary>
        /// 标签
        /// </summary>
        public string Text { get; set; }

        /// <summary>
        /// 值
        /// </summary>
        public string Value { get; set; }

        /// <summary>
        /// 是否禁用
        /// </summary>
        public bool Disabled { get; set; }

        /// <summary>
        /// 是否已选
        /// </summary>
        public bool Selected { get; set; }

        /// <summary>
        /// Initializes a new instance of the <see cref="OptionItem"/> class.
        /// </summary>
        public OptionItem() :
            this(string.Empty, string.Empty)
        { }
        /// <summary>
        /// Initializes a new instance of the <see cref="OptionItem"/> class.
        /// </summary>
        /// <param name="_text">The text.</param>
        /// <param name="_value">The value.</param>
        public OptionItem(string _text, string _value)
            : this(_text, _value, false, false)
        { }

        /// <summary>
        /// Initializes a new instance of the <see cref="OptionItem"/> class.
        /// </summary>
        /// <param name="_text">The text.</param>
        /// <param name="_value">The value.</param>
        /// <param name="_selected">if set to <c>true</c> [selected].</param>
        /// <param name="_disabled">if set to <c>true</c> [disabled].</param>
        public OptionItem(string _text, string _value, bool _selected = false, bool _disabled = false)
        {
            Text = _text;
            Value = _value;
            Disabled = _disabled;
            Selected = _selected;
        }
    }

    /// <summary>
    /// 可选项目
    /// </summary>
    /// <typeparam name="TValue">值数据的类型</typeparam>
    public class OptionItem<TValue> : IOptionItem<string, TValue>
    {
        /// <summary>
        /// 标签
        /// </summary>
        public string Text { get; set; }

        /// <summary>
        /// 值
        /// </summary>
        public TValue Value { get; set; }

        /// <summary>
        /// 是否禁用
        /// </summary>
        public bool Disabled { get; set; }

        /// <summary>
        /// 是否已选
        /// </summary>
        public bool Selected { get; set; }

        /// <summary>
        /// 无参构造函数
        /// </summary>
        public OptionItem() :
            this(string.Empty, default(TValue))
        { }

        /// <summary>
        /// 构造函数
        /// </summary>
        /// <param name="_text"></param>
        /// <param name="_value"></param>
        public OptionItem(string _text, TValue _value)
            : this(_text, _value, false, false)
        { }

        /// <summary>
        /// 构造函数
        /// </summary>
        /// <param name="_text"></param>
        /// <param name="_value"></param>
        /// <param name="_selected"></param>
        /// <param name="_disabled"></param>
        public OptionItem(string _text, TValue _value, bool _selected = false, bool _disabled = false)
        {
            Text = _text;
            Value = _value;
            Disabled = _disabled;
            Selected = _selected;
        }
    }
}