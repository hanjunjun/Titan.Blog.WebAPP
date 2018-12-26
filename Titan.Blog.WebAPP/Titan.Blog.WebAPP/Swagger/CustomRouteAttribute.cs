using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.ApiExplorer;
using System;

namespace Titan.Blog.WebAPP.Swagger
{
    /// <summary>
    /// 自定义路由 分为带版本和通用的路由
    /// </summary>
    [AttributeUsage(AttributeTargets.Class | AttributeTargets.Method, AllowMultiple = true, Inherited = true)]
    public class CustomRouteAttribute : RouteAttribute, IApiDescriptionGroupNameProvider
    {

        /// <summary>
        /// 分组名称,是来实现接口 IApiDescriptionGroupNameProvider
        /// </summary>
        public string GroupName { get; set; }

        /// <summary>
        /// 不带版本通用的路由
        /// </summary>
        /// <param name="controllerName"></param>
        public CustomRouteAttribute(string controllerName = "[controller]") : base($"/api/{controllerName}")
        {

        }

        /// <summary>
        /// 带版本的路由
        /// </summary>
        /// <param name="version"></param>
        /// <param name="controllerName"></param>
        public CustomRouteAttribute(CustomApiVersion.ApiVersions version, string controllerName = "[controller]") : base($"/api/{version}/{controllerName}")
        {
            GroupName = version.ToString();
        }
    }
}
