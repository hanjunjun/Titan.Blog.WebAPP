using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Claims;
using Microsoft.AspNetCore.Authorization;
using Titan.Blog.Infrastructure.Auth.Policys;
using Titan.Blog.Infrastructure.Data;
using Titan.Blog.WebAPP.Extensions;
using Titan.Blog.WebAPP.Swagger;

namespace Titan.Blog.WebAPP.Controllers.v2
{
    /// <summary>
    /// 版本2的认证模块
    /// </summary>
    [Produces("application/json")]//Swagger可以根据这个来自动选择请求类型
    [CustomRoute(CustomApiVersion.ApiVersions.v2)]
    public class LoginController : ApiControllerBase
    {
        #region 成员、构造函数注入
        private readonly PermissionRequirement _permissionRequirement;
        public LoginController(PermissionRequirement permissionRequirement)
        {
            _permissionRequirement = permissionRequirement;
        }
        #endregion

        #region 授权登录版本2
        /// <summary>
        /// 获取token
        /// </summary>
        /// <param name="userId">账号</param>
        /// <param name="userPassword">密码</param>
        /// <returns></returns>
        [HttpGet("LoginV2", Name = "LoginV2")]
        public OpResult<object> GetJwtToken(string userId, string userPassword)
        {
            var user = "Admin,Client,System";
            if (userId == "1" && userPassword == "1")
            {
                var userName = "李逍遥";
                var cid = Guid.NewGuid();
                //如果是基于用户的授权策略，这里要添加用户;如果是基于角色的授权策略，这里要添加角色
                var claims = new List<Claim> {
                    new Claim(ClaimTypes.Name, userName),
                    new Claim(ClaimTypes.Expiration, DateTime.Now.AddSeconds(_permissionRequirement.Expiration.TotalSeconds).ToString()) };
                claims.AddRange(user.Split(',').Select(s => new Claim(ClaimTypes.Role, s)));//数据库中查出来的当前用户的所有角色,号分开，拼接到list里。后面拦截器会根据这个值来筛选他有误权限来访问url。每个接口上有特性标识。

                //用户标识
                //var identity = new ClaimsIdentity(JwtBearerDefaults.AuthenticationScheme);
                //identity.AddClaims(claims);
                //_permissionRequirement这是个配置，启动的时候注入进来的
                _permissionRequirement.Audience = userName;
                return JwtToken.BuildJwtToken(claims.ToArray(), _permissionRequirement);
            }
            else
            {
                return new OpResult<object>(OpResultType.AuthInvalid, "帐号或密码不正确！", null);
            }
        }
        #endregion

        #region 测试
        /// <summary>
        /// 获取人列表
        /// </summary>
        /// <returns></returns>
        [HttpGet("Fuck", Name = "Fuck")]
        public OpResult<List<object>> BlogList()
        {
            var userInfo = UserInfo;
            var data = new List<object>();
            data.Add(new
            {
                BlogName = "1",
                BlogContent = "ioc容器教程"
            });
            data.Add(new
            {
                BlogName = "1",
                BlogContent = "aop"
            });
            data.Add(new
            {
                BlogName = "1",
                BlogContent = "依赖注入"
            });
            return new OpResult<List<object>>(OpResultType.Success, "", data);
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
