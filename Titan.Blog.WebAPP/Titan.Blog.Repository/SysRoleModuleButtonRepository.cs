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
    public class SysRoleModuleButtonRepository : BaseRepository<SysRoleModuleButton, Guid>, ISysRoleModuleButtonRepository
    {
        //private ModelBaseContext _context;
        public SysRoleModuleButtonRepository(ModelBaseContext context) : base(context)
        {
            //_context = context;
        }
    }
}

	