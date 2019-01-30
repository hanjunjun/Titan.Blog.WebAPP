using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Linq;
using System.Security.Claims;
using Titan.Blog.Infrastructure.Serializable;
using Titan.Blog.Model.CommonModel;

namespace Titan.Blog.WebAPP.Extensions
{
    [ApiController]
    public class ApiControllerBase : ControllerBase
    {
        /// <summary>
        /// 用户信息
        /// </summary>
        protected UserInfo UserInfo
        {
            get
            {
                var routeData = (from item in HttpContext.User.Claims
                    where item.Type == ClaimTypes.UserData
                    select item.Value).ToList().FirstOrDefault();
                if (routeData == null)
                    throw new Exception("获取用户信息异常！");
                return JsonHelper.StrToModel<UserInfo>(routeData);
            }
        }
    }
}
