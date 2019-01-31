using System;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using System.Collections.Generic;
using System.Threading.Tasks;
using Titan.Blog.IAppService;
using Titan.Blog.Infrastructure.Serializable;
using Titan.Blog.Model.DataModel;
using Titan.Blog.Model.ResultModel;
using Titan.Blog.WebAPP.Auth.Policys;
using Titan.Blog.WebAPP.Extensions;
using Titan.Blog.WebAPP.Swagger;

namespace Titan.Blog.WebAPP.Controllers.v2
{
    /// <summary>
    /// 各种用法示例
    /// </summary>
    [CustomRoute(CustomApiVersion.ApiVersions.v2)]
    [Authorize("Permission")]
    public class EFCoreTestController : ApiControllerBase
    {
        #region 成员、构造函数注入
        private readonly PermissionRequirement _permissionRequirement;
        //private readonly AuthorDomainSvc _authorDomainSvc;
        private readonly IMainServices _iMainServices;
        private readonly IChildrenServices _iChildrenServices;
        public EFCoreTestController(PermissionRequirement permissionRequirement, IMainServices iMainServices/*, AuthorDomainSvc authorDomainSvc*/
            , IChildrenServices iChildrenServices)
        {
            _permissionRequirement = permissionRequirement;
            //_authorDomainSvc = authorDomainSvc;
            _iMainServices = iMainServices;
            _iChildrenServices = iChildrenServices;
        }
        #endregion

        /// <summary>
        /// EF 查询测试
        /// </summary>
        /// <returns></returns>
        [HttpGet("EFQuery", Name = "EFQuery")]
        [AllowAnonymous]
        public async Task<OpResult<string>> PostForm()
        {
            var sqrt = Math.Sqrt(25);
            var userId = UserInfo.UserName;
            //0 非跟踪分页查询--ef性能测试
            var test = await _iMainServices.QueryAsNotraking();

            //1
            Random rd = new Random();
            var data = await _iMainServices.GetList();
            var model = new Main();
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
    }
}
