using System;
using System.Collections.Generic;
using System.IdentityModel.Tokens.Jwt;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Routing;

namespace Titan.Blog.WebAPP.Extensions
{
    [ApiController]
    public class ApiControllerBase : ControllerBase
    {
        /// <summary>
        /// 用户信息
        /// </summary>
        protected string UserInfo
        {
            get
            {
                var routeData= HttpContext.GetRouteData();
                //var data = new JwtSecurityTokenHandler().ReadJwtToken();
                return "";
            }
        }
    }
}
