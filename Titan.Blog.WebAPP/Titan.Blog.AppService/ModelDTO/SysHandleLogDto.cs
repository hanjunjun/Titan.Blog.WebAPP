using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Titan.AppService.ModelDTO
{
    public class SysHandleLogDto
    {

    }

    public class SysHandleLogAddorUpdateDto
    {
        ///<summary>
        /// 操作记录主键Id
        ///</summary>
        [Description("操作记录主键Id")]
        public System.Guid SysHandleLogId { get; set; } // SysHandleLogId (Primary key)

        ///<summary>
        /// 用户主键Id
        ///</summary>
        [Description("用户主键Id")]
        public System.Guid? SysEmployeeId { get; set; } // SysEmployeeId

        ///<summary>
        /// 系统模块主键Id
        ///</summary>
        [Description("系统模块主键Id")]
        public System.Guid? SysTitleId { get; set; } // SysTitleId

        ///<summary>
        /// 操作时间
        ///</summary>
        [Description("操作时间")]
        public System.DateTime? HandleTime { get; set; } // HandleTime

        ///<summary>
        /// 操作动作
        ///</summary>
        [Description("操作动作")]
        public int? HandleAction { get; set; } // HandleAction

        ///<summary>
        /// 业务Id
        ///</summary>
        [Description("业务Id")]
        public System.Guid? HandleDataId { get; set; } // HandleDataId

        ///<summary>
        /// IP地址
        ///</summary>
        [Description("IP地址")]
        public string HandleLogIP { get; set; } // HandleLogIP (length: 100)

        ///<summary>
        /// 日志所属机构Id
        ///</summary>
        [Description("日志所属机构Id")]
        public System.Guid? HandleActionCID { get; set; } // HandleActionCID

        ///<summary>
        /// 备注
        ///</summary>
        [Description("备注")]
        public string HandleLogDesc { get; set; } // HandleLogDesc (length: 500)

        ///<summary>
        /// 是否删除
        ///</summary>
        [Description("是否删除")]
        public bool? Isdelete { get; set; } // Isdelete
    }
}
