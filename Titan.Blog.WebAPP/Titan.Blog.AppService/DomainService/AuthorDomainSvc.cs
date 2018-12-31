using Microsoft.AspNetCore.Hosting;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;
using Titan.Blog.AppService.ModelDTO;
using Titan.Blog.AppService.ModelService;
using Titan.Blog.Infrastructure.Data;
using Titan.Blog.Model.DataModel;
using Titan.Infrastructure.Domain;
using Titan.Model.DataModel;
using Titan.RepositoryCode;

namespace Titan.Blog.AppService.DomainService
{
    public class AuthorDomainSvc
    {
        private ModelRespositoryFactory<SysRoleModuleButton, Guid> _modelSvc;
        private ModelRespositoryFactory<SysRole, Guid> _modelRole;
        public AuthorDomainSvc( ModelRespositoryFactory<SysRoleModuleButton, Guid> modelSvc, ModelRespositoryFactory<SysRole, Guid> modelRole)
        {
            _modelSvc = modelSvc;
            _modelRole = modelRole;
        }

        //public List<Author> GetList()
        //{
        //    return _authorSvc.FindModelByValue(x => true);
        //    //return new List<Author>();
        //}

        public List<Author> SqlTest()
        {
            return _modelSvc.context.Set<Author>().FromSql("select * from Author").ToList();

        }

        public int CommandSql()
        {
            return _modelSvc.context.Database.ExecuteSqlCommand("INSERT INTO [TestDB].[dbo].[Author] ([Id], [AuthorName], [PKId]) VALUES ('1', '管理员', newid());");
        }

        /// <summary>
        /// 获取系统中所有的权限
        /// </summary>
        /// <returns></returns>
        public List<SysRoleModuleButtonDto> GeRoleModule()
        {

            var roleModuleButton = _modelSvc.GetDatasNoTracking(x => x.ModuleType == 0).ToList().MapToList<SysRoleModuleButton, SysRoleModuleButtonDto>();//
            if (roleModuleButton.Count > 0)
            {
                foreach (var item in roleModuleButton)
                {
                    item.SysRole = _modelSvc.context.Set<SysRole>().FromSql("select * from SysRole where SysRoleId={0} and IsDelete!=1 and RoleStatus=1", item.SysRoleId).FirstOrDefault();
                    item.SysModule = _modelSvc.context.Set<SysModule>().FromSql("select * from SysModule where SysModuleId={0} and ModuleStatus=1 and IsDelete!=1", item.SysModuleId).FirstOrDefault();
                }

            }
            return roleModuleButton;
        }

        public OpResult<string> VerifyUserInfo(string userId,string userPwd,out SysUser sysUser)
        {
            var userInfo = _modelSvc.context.Set<SysUser>().FromSql("select * from SysUser where UserId={0} and UserPwd={1} and UserStatus=1", userId,userPwd).FirstOrDefault();//验证用户id和密码
            sysUser = userInfo;
            if (userInfo != null)
            {
                var roleList= _modelSvc.context.Set<SysUserRole>().FromSql("SELECT * from SysUserRole where SysUserId={0}", userInfo.SysUserId).ToList().Select(x=>x.SysRoleId).ToList();//获取用户角色
                var roleNameList = _modelRole.GetDatasNoTracking(x=> roleList.Contains(x.SysRoleId) && x.IsDelete!=true && x.RoleStatus==true).Select(x=>x.RoleName).ToList();//获取用户角色名称
                var roleName = string.Join(',', roleNameList);
                return new OpResult<string>(OpResultType.Success, roleName);
            }
            return new OpResult<string>(OpResultType.AuthInvalid, "帐号或密码不正确！");
        }
    }
}
