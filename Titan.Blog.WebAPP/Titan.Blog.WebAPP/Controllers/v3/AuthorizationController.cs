using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Claims;
using System.Threading.Tasks;
using Titan.Blog.IAppService;
using Titan.Blog.Infrastructure.AutoMapper;
using Titan.Blog.Infrastructure.Serializable;
using Titan.Blog.Model.CommonModel;
using Titan.Blog.Model.CommonModel.ResultModel;
using Titan.Blog.WebAPP.Auth.Policys;
using Titan.Blog.WebAPP.Extensions;
using Titan.Blog.WebAPP.Swagger;

namespace Titan.Blog.WebAPP.Controllers.v3
{
    /// <summary>
    /// 授权模块
    /// </summary>
    [Produces("application/json")]
    [CustomRoute(CustomApiVersion.ApiVersions.v3)]
    public class AuthorizationController : ApiControllerBase
    {
        #region 成员、构造函数注入
        private readonly PermissionRequirement _permissionRequirement;
        private readonly IMainServices _iMainServices;
        public AuthorizationController(PermissionRequirement permissionRequirement, IMainServices iMainServices)
        {
            _permissionRequirement = permissionRequirement;
            _iMainServices = iMainServices;
        }
        #endregion

        #region 登录授权获取Token
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
        [HttpGet("LoginV3", Name = "LoginV3")]
        public async Task<OpResult<string>> GetJwtToken(string userId, string userPassword)
        {
            var ops = await _iMainServices.VerifyPassword(userId, userPassword);
            var op = ops.Item1;
            if (!op.Successed)
            {
                return op;
            }
            var user = op.Message;
            var userName = ops.Item2.UserName;
            var userDto = ops.Item2.MapTo(new UserInfo());
            //如果是基于用户的授权策略，这里要添加用户;如果是基于角色的授权策略，这里要添加角色
            var claims = new List<Claim> {
                new Claim(ClaimTypes.Name, userName),//用户名称
                new Claim(ClaimTypes.MobilePhone, ops.Item2.Telphone),//用户手机号
                new Claim(ClaimTypes.UserData, JsonHelper.ModelToStr(userDto)),//用户手机号
                new Claim(ClaimTypes.Expiration, DateTime.Now.AddSeconds(_permissionRequirement.Expiration.TotalSeconds).ToString())
            };
            claims.AddRange(user.Split(',').Select(s => new Claim(ClaimTypes.Role, s)));
            return JwtToken.BuildJwtToken(claims.ToArray(), _permissionRequirement);
        }
        #endregion
    }
}