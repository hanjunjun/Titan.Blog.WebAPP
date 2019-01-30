using System;
using Titan.Blog.IRepository;
using Titan.Blog.Model.DataModel;
using Titan.Blog.Repository.Base;
using Titan.Blog.Repository.EFCore;

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

	