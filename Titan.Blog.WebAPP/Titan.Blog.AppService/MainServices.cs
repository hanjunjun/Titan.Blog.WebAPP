/************************************************************************
 * 文件名：MainServices
 * 文件功能描述：xx控制层
 * 作    者：  韩俊俊
 * 创建日期：2019/1/22 17:25:45
 * 修 改 人：
 * 修改日期：
 * 修改原因：
 * Copyright (c) 2017 . All Rights Reserved. 
 * ***********************************************************************/
using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Text;
using System.Threading.Tasks;
using Titan.Blog.AppService.Base;
using Titan.Blog.IAppService;
using Titan.Blog.IAppService.Base;
using Titan.Blog.Infrastructure.Attribute;
using Titan.Blog.Infrastructure.AutoMapper;
using Titan.Blog.Infrastructure.Utility;
using Titan.Blog.IRepository;
using Titan.Blog.Model.CommonModel.ResultModel;
using Titan.Blog.Model.DataModel;
using Titan.Blog.Model.DTOModel;

namespace Titan.Blog.AppService
{
    public class MainServices:BaseServices<Main,Guid>,IMainServices
    {
        private readonly IMainRepository _iMainRepository;
        private readonly IChildrenRepository _iChildrenRepository;
        private readonly ISysRoleRepository _iSysRoleRepository;
        private readonly ISysRoleModuleButtonRepository _iSysRoleModuleButtonRepository;
        private readonly ISysModuleRepository _iSysModuleRepository;
        private readonly ISysUserRepository _iSysUserRepository;
        private readonly ISysUserRoleRepository _iSysUserRoleRepository;
        public MainServices(IMainRepository iMainRepository, IChildrenRepository iChildrenRepository, ISysRoleRepository iSysRoleRepository,
            ISysRoleModuleButtonRepository iSysRoleModuleButtonRepository, ISysModuleRepository iSysModuleRepository, ISysUserRepository iSysUserRepository,
            ISysUserRoleRepository iSysUserRoleRepository)
        {
            base.BaseRepository = iMainRepository;//如果要用基类封装的方法必须传值
            _iMainRepository = iMainRepository;
            _iChildrenRepository = iChildrenRepository;
            _iSysRoleRepository = iSysRoleRepository;
            _iSysRoleModuleButtonRepository = iSysRoleModuleButtonRepository;
            _iSysModuleRepository = iSysModuleRepository;
            _iSysUserRepository = iSysUserRepository;
            _iSysUserRoleRepository = iSysUserRoleRepository;
        }

        public async Task AddModel(Main model)
        {
            await Add(model);//直接使用基类中的方法
            //await _iMainRepository.Add(model);//使用仓储中的方法
        }

        public async Task<Tuple<List<Main>,int>> GetList()
        {
            //ef 跟踪查询
            Expression<Func<Children, bool>> where1 = x => true;
            Expression<Func<Children, int>> orderby1 = x => x.Id;
            var dt = await _iChildrenRepository.Query(where1, orderby1, true, 1, 10);
            //更新数据
            var put = dt.Item1.FirstOrDefault();
            put.Name = "非跟踪更新";
            await _iChildrenRepository.Update(put);

            Expression<Func<Main, bool>> where = x => true;
            Expression<Func<Main, string>> orderby = x => x.Name;
            var data=await Query(where, orderby, true, 1, 10);
            return data;
        }

        public async Task<Tuple<List<Children>, int>> QueryAsNotraking()
        {
            //string redisConfiguration = Appsettings.app(new string[] { "AppSettings", "RedisCaching", "ConnectionString" });//获取连接字符串
            //ef非跟踪查询
            Expression<Func<Children, bool>> where1 = x => x.Main.Telphone!=null;
            Expression<Func<Children, string>> orderby1 = x => x.Name;
            Expression<Func<Children, string>> orderby2 = x => x.Id.ToString();
            var data= await _iChildrenRepository.QueryAsNoTracking<string>(where1, orderby1, orderby2, true, 1, 10);
            //更新数据
            var put = data.Item1.FirstOrDefault();
            put.Name = "非跟踪更新";
            await _iChildrenRepository.Update(put);
            return data;
        }

        /// <summary>
        /// 获取系统中所有的权限
        /// </summary>
        /// <returns></returns>
        [Caching(AbsoluteExpiration = 10)]
        public async Task<List<SysRoleModuleButtonDto>> GeRoleModule()
        {
            var dto = await _iSysRoleModuleButtonRepository.QueryAsNoTracking(x => x.ModuleType == 0);//
            var roleModuleButton = dto.MapToList<SysRoleModuleButton, SysRoleModuleButtonDto>();
            if (roleModuleButton.Count > 0)
            {
                foreach (var item in roleModuleButton)
                {
                    item.SysRole = _iSysRoleRepository.QueryBySql($"select * from SysRole where SysRoleId='{item.SysRoleId}' and IsDelete!=1 and RoleStatus=1").Result.FirstOrDefault();
                    item.SysModule = _iSysModuleRepository.QueryBySql($"select * from SysModule where SysModuleId='{item.SysModuleId}' and ModuleStatus=1 and IsDelete!=1").Result.FirstOrDefault();
                }

            }
            return roleModuleButton;
        }

        /// <summary>
        /// 登录验证帐号和密码
        /// </summary>
        /// <param name="userId"></param>
        /// <param name="userPwd"></param>
        /// <returns></returns>
        public async Task<Tuple<OpResult<string>, SysUser>> VerifyPassword(string userId, string userPwd)
        {
            var userInfo = await _iSysUserRepository.QueryBySql($"select * from SysUser where UserId='{userId}' and UserPwd='{userPwd}' and UserStatus=1");//验证用户id和密码
            var sysUser = userInfo.FirstOrDefault();
            if (sysUser != null)
            {
                var roleList = _iSysUserRoleRepository.QueryBySql($"SELECT * from SysUserRole where SysUserId='{sysUser.SysUserId}'").Result.Select(x => x.SysRoleId).ToList();//获取用户角色
                var roleNameList = _iSysRoleRepository.QueryAsNoTracking(x => roleList.Contains(x.SysRoleId) && x.IsDelete != true && x.RoleStatus == true).Result.Select(x => x.RoleName).ToList();//获取用户角色名称
                var roleName = string.Join(',', roleNameList);
                return new Tuple<OpResult<string>, SysUser>(new OpResult<string>(OpResultType.Success, roleName),sysUser);
            }
            
            return new Tuple<OpResult<string>, SysUser>(new OpResult<string>(OpResultType.AuthInvalid, "帐号或密码不正确！"), sysUser);
        }

        public async Task EFTransactionTest()
        {
            using (var tran = _iMainRepository._context.Database.BeginTransaction())
            {
                try
                {
                    Random rd = new Random();
                    var main = new Main();
                    main.Id = rd.Next();
                    main.Name = $"{DateTime.Now}";
                    main.Telphone = "1111";
                    await _iMainRepository.Add(main);
                    await _iMainRepository.ExecuteSql($"INSERT INTO [dbo].[Main] ([id], [name], [telphone]) VALUES ('{rd.Next()}', 'test', '21')");
                    await _iMainRepository.ExecuteSql($"INSERT INTO [dbo].[Main] ([id], [name], [telphone]) VALUES ('{rd.Next()}', 'test', '21')");
                    await _iMainRepository.ExecuteSql($"INSERT INTO [dbo].[Main] ([id], [name], [telphone]) VALUES ('{rd.Next()}', 'test', '21')");
                    await _iMainRepository.ExecuteSql($"update [dbo].[Main] set name='事务更新测试'");
                    var data = await _iMainRepository.QueryAsNoTracking();//await必须加，不然commit提交之后，上下文就被释放了，这个时候_context.data.where()xxx就报错。无法访问的资源。
                    //var test = DateTime.Parse("1111");
                    tran.Commit();
                }
                catch (Exception e)
                {
                    tran.Rollback();
                }
            }
        }
    }
}
