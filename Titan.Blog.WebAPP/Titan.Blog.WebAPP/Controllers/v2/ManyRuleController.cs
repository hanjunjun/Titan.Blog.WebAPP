using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Titan.Blog.Infrastructure.Data;
using Titan.Blog.Infrastructure.Serializable;
using Titan.Blog.WebAPP.Extensions;
using Titan.Blog.WebAPP.Swagger;

namespace Titan.Blog.WebAPP.Controllers.v2
{
    /// <summary>
    /// 各种用法示例
    /// </summary>
    [CustomRoute(CustomApiVersion.ApiVersions.v2)]
    [Authorize("Permission")]
    public class ManyRuleController:ApiControllerBase
    {
        [HttpPost("PostForm", Name = "PostForm")]
        public OpResult<string> PostForm([FromForm]RegistrationForm form)
        {
            return new OpResult<string>(OpResultType.Success,JsonHelper.ModelToStr(form));
        }
    }

    public class RegistrationForm
    {
        public string Name { get; set; }

        public IEnumerable<int> PhoneNumbers { get; set; }
    }
}
