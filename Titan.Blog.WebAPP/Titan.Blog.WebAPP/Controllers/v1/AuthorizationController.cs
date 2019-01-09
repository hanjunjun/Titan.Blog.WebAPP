using System;
using System.Collections.Generic;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Titan.Blog.Infrastructure.Data;
using Titan.Blog.WebAPP.Extensions;
using Titan.Blog.WebAPP.Swagger;

namespace Titan.Blog.WebAPP.Controllers.v1
{
    /// <summary>
    /// 版本1-认证授权模块
    /// </summary>
    [Produces("application/json")]//Swagger可以根据这个来自动选择请求类型
    [CustomRoute(CustomApiVersion.ApiVersions.v1)]
    [Authorize("Permission")]
    public class AuthorizationController : ApiControllerBase
    {
        #region 授权登录版本1
        /// <summary>
        /// 获取token
        /// </summary>
        /// <param name="userId">账号</param>
        /// <param name="userPassword">密码</param>
        /// <returns></returns>
        [HttpGet("LoginV1", Name = "LoginV1")]
        [AllowAnonymous]
        public OpResult<string> GetJwtToken(string userId, string userPassword)
        {
            return new OpResult<string>(OpResultType.Success, "", $"登录版本1成功");
        }
        #endregion

        #region 测试
        /// <summary>
        /// 获取博客列表
        /// </summary>
        /// <returns></returns>
        [HttpGet("ZArrayTest")]
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
        /// 根据Id获取博客详情
        /// </summary>
        /// <param name="id">博客Id</param>
        /// <returns>博客详情</returns>
        [AllowAnonymous]
        [HttpGet("Test/{id}", Name = "TestById")]
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
