using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Titan.AppService.ModelDTO
{
    public class SysTitleDto
    {
        ///<summary>
        /// 系统模块主键Id
        ///</summary>
        [Description("系统模块主键Id")]
        public System.Guid SysTitleId { get; set; } // SysTitleId (Primary key)

        ///<summary>
        /// 模块名称
        ///</summary>
        [Description("模块名称")]
        public string TitleName { get; set; } // TitleName (length: 40)

        ///<summary>
        /// 模块地址
        ///</summary>
        [Description("模块地址")]
        public string TitleUrl { get; set; } // TitleUrl (length: 200)

        ///<summary>
        /// 是否显示
        ///</summary>
        [Description("是否显示")]
        public int? IsDisplay { get; set; } // IsDisplay

        ///<summary>
        /// 排序
        ///</summary>
        [Description("排序")]
        public int? TitleOrderIndex { get; set; } // TitleOrderIndex

        ///<summary>
        /// 父Id
        ///</summary>
        [Description("父Id")]
        public System.Guid? TitleFatherId { get; set; } // TitleFatherId

        ///<summary>
        /// 模块图标地址
        ///</summary>
        [Description("模块图标地址")]
        public string TitleImgUrl { get; set; } // TitleImgUrl (length: 200)

        ///<summary>
        /// 是否删除
        ///</summary>
        [Description("是否删除")]
        public bool? Isdelete { get; set; } // Isdelete

        ///<summary>
        /// 备注
        ///</summary>
        [Description("备注")]
        public string TitleDesc { get; set; } // TitleDesc (length: 500)

    }
}
