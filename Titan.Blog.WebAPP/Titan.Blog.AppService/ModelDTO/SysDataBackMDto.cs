using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Titan.AppService.ModelDTO
{
    public class SysDataBackMDto
    {
        ///<summary>
        /// 数据库备份管理主键Id
        ///</summary>
        [Description("数据库备份管理主键Id")]
        public System.Guid DataBackMId { get; set; } // DataBackMId (Primary key)

        ///<summary>
        /// 用户主键Id
        ///</summary>
        [Description("用户主键Id")]
        public System.Guid? SysEmployeeId { get; set; } // SysEmployeeId

        ///<summary>
        /// 数据库备份文件名
        ///</summary>
        [Description("数据库备份文件名")]
        public string DataBackMFileName { get; set; } // DataBackMFileName (length: 100)

        ///<summary>
        /// 数据库备份开始时间
        ///</summary>
        [Description("数据库备份开始时间")]
        public System.DateTime? DataBackMStartTime { get; set; } // DataBackMStartTime

        ///<summary>
        /// 数据库备份结束时间
        ///</summary>
        [Description("数据库备份结束时间")]
        public System.DateTime? DataBackMEndTime { get; set; } // DataBackMEndTime

        ///<summary>
        /// 数据库文件大小
        ///</summary>
        [Description("数据库文件大小")]
        public string DataBackMFileSize { get; set; } // DataBackMFileSize (length: 40)

        ///<summary>
        /// 数据库文件路径
        ///</summary>
        [Description("数据库文件路径")]
        public string DataBackMFilePath { get; set; } // DataBackMFilePath (length: 500)
    }

    public class SysDataBackMAddorUpdateDto
    {
        ///<summary>
        /// 数据库备份管理主键Id
        ///</summary>
        [Description("数据库备份管理主键Id")]
        public System.Guid DataBackMId { get; set; } // DataBackMId (Primary key)

        ///<summary>
        /// 用户主键Id
        ///</summary>
        [Description("用户主键Id")]
        public System.Guid? SysEmployeeId { get; set; } // SysEmployeeId

        ///<summary>
        /// 数据库备份文件名
        ///</summary>
        [Description("数据库备份文件名")]
        public string DataBackMFileName { get; set; } // DataBackMFileName (length: 100)

        ///<summary>
        /// 数据库备份开始时间
        ///</summary>
        [Description("数据库备份开始时间")]
        public System.DateTime? DataBackMStartTime { get; set; } // DataBackMStartTime

        ///<summary>
        /// 数据库备份结束时间
        ///</summary>
        [Description("数据库备份结束时间")]
        public System.DateTime? DataBackMEndTime { get; set; } // DataBackMEndTime

        ///<summary>
        /// 数据库文件大小
        ///</summary>
        [Description("数据库文件大小")]
        public string DataBackMFileSize { get; set; } // DataBackMFileSize (length: 40)

        ///<summary>
        /// 数据库文件路径
        ///</summary>
        [Description("数据库文件路径")]
        public string DataBackMFilePath { get; set; } // DataBackMFilePath (length: 500)
    }

    public class SysDataBackMLookDto
    {
        ///<summary>
        /// 数据库备份管理主键Id
        ///</summary>
        [Description("数据库备份管理主键Id")]
        public System.Guid DataBackMId { get; set; } // DataBackMId (Primary key)

        ///<summary>
        /// 用户主键Id
        ///</summary>
        [Description("用户主键Id")]
        public System.Guid? SysEmployeeId { get; set; } // SysEmployeeId

        ///<summary>
        /// 数据库备份文件名
        ///</summary>
        [Description("数据库备份文件名")]
        public string DataBackMFileName { get; set; } // DataBackMFileName (length: 100)

        ///<summary>
        /// 数据库备份开始时间
        ///</summary>
        [Description("数据库备份开始时间")]
        public System.DateTime? DataBackMStartTime { get; set; } // DataBackMStartTime

        ///<summary>
        /// 数据库备份结束时间
        ///</summary>
        [Description("数据库备份结束时间")]
        public System.DateTime? DataBackMEndTime { get; set; } // DataBackMEndTime

        ///<summary>
        /// 数据库文件大小
        ///</summary>
        [Description("数据库文件大小")]
        public string DataBackMFileSize { get; set; } // DataBackMFileSize (length: 40)

        ///<summary>
        /// 数据库文件路径
        ///</summary>
        [Description("数据库文件路径")]
        public string DataBackMFilePath { get; set; } // DataBackMFilePath (length: 500)
    }
}
