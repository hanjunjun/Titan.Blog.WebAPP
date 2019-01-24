using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Claims;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Authentication.JwtBearer;
using Microsoft.AspNetCore.Authorization;
//using Titan.Blog.AppService.DomainService;
using Titan.Blog.IAppService;
using Titan.Blog.Model.DataModel;
using Titan.Blog.Model.ResultModel;
using Titan.Blog.WebAPP.Auth.Policys;
using Titan.Blog.WebAPP.Extensions;
using Titan.Blog.WebAPP.Swagger;

namespace Titan.Blog.WebAPP.Controllers.v2
{
    /// <summary>
    /// 版本2-认证授权模块
    /// </summary>
    [Produces("application/json")]//Swagger可以根据这个来自动选择请求类型
    [CustomRoute(CustomApiVersion.ApiVersions.v2)]
    public class AuthorizationController : ApiControllerBase
    {
        #region 成员、构造函数注入
        private readonly PermissionRequirement _permissionRequirement;
        //private readonly AuthorDomainSvc _authorDomainSvc;
        private readonly IMainServices _iMainServices;
        private readonly IChildrenServices _iChildrenServices;
        public AuthorizationController(PermissionRequirement permissionRequirement, IMainServices iMainServices/*, AuthorDomainSvc authorDomainSvc*/
            , IChildrenServices iChildrenServices)
        {
            _permissionRequirement = permissionRequirement;
            //_authorDomainSvc = authorDomainSvc;
            _iMainServices = iMainServices;
            _iChildrenServices = iChildrenServices;
        }
        #endregion

        #region 授权登录版本2
        /// <summary>
        /// 获取token授权密钥
        /// </summary>
        /// <param name="userId">账号</param>
        /// <param name="userPassword">密码</param>
        /// <returns></returns>
        /// <remarks>
        /// <h2>权限系统</h2>
        /// <table border="1">
        ///     <tr>
        ///         <td>普通用户角色：帐号0 密码0 可访问的接口：/api/Test/AddBlog</td>
        ///         <td>普通管理员角色：帐号1 密码1 可访问的接口：/api/Test/ArrayTest</td>
        ///         <td>超级管理员角色：帐号2 密码2 可访问的接口：/api/ImageTest/EFCoreTest /api/FileTest/UploadFile</td>
        ///     </tr>
        /// </table>
        /// <img src="https://raw.githubusercontent.com/HanJunJun/Titan.Blog.WebAPP/master/Titan.Blog.WebAPP/Titan.Blog.WebAPP/wwwroot/%E6%9D%83%E9%99%90%E7%B3%BB%E7%BB%9F%E8%AE%BE%E8%AE%A1%E5%9B%BE.png" />
        /// </remarks>
        //[HttpGet("LoginV2", Name = "LoginV2")]
        //public OpResult<string> GetJwtToken(string userId, string userPassword)
        //{
        //    SysUser sysUser;
        //    var op = _authorDomainSvc.VerifyUserInfo(userId, userPassword,out sysUser);
        //    if (!op.Successed)
        //    {
        //        return op;
        //    }
        //    var user = op.Message;
        //    var userName = sysUser.UserId;
        //    //如果是基于用户的授权策略，这里要添加用户;如果是基于角色的授权策略，这里要添加角色
        //    var claims = new List<Claim> {
        //        new Claim(ClaimTypes.Name, userName),
        //        new Claim(ClaimTypes.Expiration, DateTime.Now.AddSeconds(_permissionRequirement.Expiration.TotalSeconds).ToString()) };
        //    claims.AddRange(user.Split(',').Select(s => new Claim(ClaimTypes.Role, s)));//数据库中查出来的当前用户的所有角色,号分开，拼接到list里。后面拦截器会根据这个值来筛选他有误权限来访问url。每个接口上有特性标识。

        //    //用户标识
        //    //用户标识
        //    //var identity = new ClaimsIdentity(JwtBearerDefaults.AuthenticationScheme);
        //    //identity.AddClaims(claims);
        //    //_permissionRequirement这是个配置，启动的时候注入进来的
        //    //_permissionRequirement.Audience = userName;//这个不能加，加了会报错
        //    return JwtToken.BuildJwtToken(claims.ToArray(), _permissionRequirement);
        //}
        #endregion

        #region 测试
        /// <summary>
        /// 获取人列表
        /// </summary>
        /// <returns></returns>
        [HttpGet("Fuck", Name = "Fuck")]
        public async Task<OpResult<string>> BlogList()
        {
            //0 非跟踪分页查询--ef性能测试
            var test = await _iMainServices.QueryAsNotraking();

            //1
            Random rd=new Random();
            var data= await _iMainServices.GetList();
            var model=new Main();
            model.Id = rd.Next();
            model.Name = "面向对象";
            model.Telphone = "11112312";
            await _iMainServices.AddModel(model);

            //2
            Random rd1 = new Random();
            var data1 = await _iChildrenServices.GetList();
            var model1 = new Children();
            model1.Id = rd1.Next();
            model1.Name = "面向对象";
            model1.MainId = 1111;
            await _iChildrenServices.AddModel(model1);
            
            return new OpResult<string>(OpResultType.Success, "操作成功！");
        }

        /// <summary>
        /// 根据Id获取人详情
        /// </summary>
        /// <param name="id">博客Id</param>
        /// <returns>博客详情</returns>
        [AllowAnonymous]
        [HttpGet("Fuck/{id}", Name = "FuckById")]
        public OpResult<List<object>> BlogList(Guid id)
        {
            var userInfo = UserInfo;
            var data = new List<object>();
            data.Add(new
            {
                BlogName = "1",
                BlogContent = "ioc容器教程"
            });
            return new OpResult<List<object>>(OpResultType.Success, "", data);
        }
        #endregion
    }
}
