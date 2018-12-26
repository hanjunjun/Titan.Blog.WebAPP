using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Titan.Blog.Infrastructure.Data
{
    /// <summary>
    /// 级联可选项目
    /// </summary>
    public class OptionCascaderItem : IOptionItem<string, string>
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
        /// 子选项
        /// </summary>
        public List<OptionCascaderItem> Children { get; set; }

        /// <summary>
        /// 无参构造函数
        /// </summary>
        public OptionCascaderItem()
            : this(string.Empty, string.Empty)
        { }

        /// <summary>
        /// 构造函数
        /// </summary>
        /// <param name="_text"></param>
        /// <param name="_value"></param>
        /// <param name="_children"></param>
        /// <param name="_disabled"></param>
        public OptionCascaderItem(string _text, string _value, List<OptionCascaderItem> _children = null, bool _disabled = false)
        {
            Text = _text;
            Value = _value;
            Children = _children ?? new List<OptionCascaderItem>();
            Disabled = _disabled;
        }
    }
}
