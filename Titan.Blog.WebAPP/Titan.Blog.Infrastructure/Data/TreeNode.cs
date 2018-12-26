using System.Collections.Generic;

namespace Titan.Blog.Infrastructure.Data
{
    /// <summary>
    /// 树形节点
    /// </summary>
    public class TreeNode
    {
        /// <summary>
        /// id
        /// </summary>
        public string id { get; set; }

        /// <summary>
        /// 编号
        /// </summary>
        public string code { get; set; }

        /// <summary>
        /// 标签
        /// </summary>
        public string label { get; set; }

        /// <summary>
        /// 是否禁用
        /// </summary>
        public bool disabled { get; set; }

        /// <summary>
        /// 是否选择
        /// </summary>
        public bool selected { get; set; }

        /// <summary>
        /// 图标
        /// </summary>
        public string icon { get; set; }

        /// <summary>
        /// 是否是叶子节点
        /// </summary>
        public bool isLeaf { get; set; }

        /// <summary>
        /// 排序
        /// </summary>
        public int? sort { get; set; }

        /// <summary>
        /// 链接地址
        /// </summary>
        public string url { get; set; }

        /// <summary>
        /// 是否全选
        /// </summary>
        public bool isIndeterminate { get; set; }

        /// <summary>
        /// 子节点
        /// </summary>
        public List<TreeNode> children { get; set; }

        /// <summary>
        /// 无参构造函数
        /// </summary>
        public TreeNode()
            : this(string.Empty)
        { }

        /// <summary>
        /// 构造函数
        /// </summary>
        /// <param name="_label"></param>
        /// <param name="_children"></param>
        /// <param name="_disabled"></param>
        /// <param name="_isLeaf"></param>
        public TreeNode(string _label, List<TreeNode> _children = null, bool _disabled = false, bool _isLeaf = false)
        {
            label = _label;
            children = _children ?? new List<TreeNode>();
            disabled = _disabled;
            isLeaf = _isLeaf;
        }
    }
}