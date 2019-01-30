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
	public class SysButtonRepository : BaseRepository<SysButton, Guid>, ISysButtonRepository
    {
        //private ModelBaseContext _context;
        public SysButtonRepository(ModelBaseContext context) : base(context)
        {
            //_context = context;
        }
    }
}

	