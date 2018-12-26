using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Titan.Blog.Infrastructure.Data
{
    /// <summary>
    /// 可选项目(分组)
    /// </summary>
    public class OptionGroupItem<TItem>
    {
        /// <summary>
        /// 分组名称
        /// </summary>
        public string Name { get; set; }

        /// <summary>
        /// 分组包含的可选项目
        /// </summary>
        public List<TItem> Options { get; set; }

        /// <summary>
        /// 分组是否禁用
        /// </summary>
        public bool Disabled { get; set; }

        /// <summary>
        /// 无参构造函数
        /// </summary>
        public OptionGroupItem()
            : this(string.Empty, null)
        { }

        /// <summary>
        /// 构造函数
        /// </summary>
        /// <param name="_name"></param>
        /// <param name="_optinos"></param>
        /// <param name="_disabled"></param>
        public OptionGroupItem(string _name, List<TItem> _optinos, bool _disabled = false)
        {
            Name = _name;
            Options = _optinos ?? new List<TItem>();
            Disabled = _disabled;
        }
    }
}
