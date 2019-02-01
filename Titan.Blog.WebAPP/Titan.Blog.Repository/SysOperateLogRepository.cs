using System;
using Titan.Blog.IRepository;
using Titan.Blog.Model.DataModel;
using Titan.Blog.Model.DbContext;
using Titan.Blog.Repository.Base;

namespace Titan.Blog.Repository
{
    /// <summary>
    /// RoleModulePermissionRepository
    /// </summary>	
    public class SysOperateLogRepository : BaseRepository<SysOperateLog, Guid>, ISysOperateLogRepository
    {
        //private ModelBaseContext _context;
        public SysOperateLogRepository(ModelBaseContext context) : base(context)
        {
            //_context = context;
        }
    }
}

	