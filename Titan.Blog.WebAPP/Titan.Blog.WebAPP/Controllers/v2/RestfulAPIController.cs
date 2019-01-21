using System.Collections.Generic;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Titan.Blog.AppService.DomainService;
using Titan.Blog.AppService.ModelDTO;
using Titan.Blog.AppService.ModelService;
using Titan.Blog.Infrastructure.Data;
using Titan.Blog.Model.CommonModel;
using Titan.Blog.WebAPP.Extensions;
using Titan.Blog.WebAPP.Swagger;

namespace Titan.Blog.WebAPP.Controllers.v2
{
    /// <summary>
    /// 符合Restful规范的API示例
    /// </summary>
    [Produces("application/json")]
    [CustomRoute(CustomApiVersion.ApiVersions.v2,"user")]
    [Authorize("Permission")]
    public class RestfulAPIController : ApiControllerBase
    {
        #region 成员、构造函数注入

        private readonly AuthorDomainSvc _authorDomainSvc;
        public RestfulAPIController(AuthorDomainSvc authorDomainSvc)
        {
            _authorDomainSvc = authorDomainSvc;
        }
        #endregion

        #region Restful API
        /// <summary>
        /// 新增用户
        /// </summary>
        /// <param name="userModel">用户模型</param>
        /// <returns></returns>
        /// <remarks>
        /// # HTTP动词
        /// [RESTful 架构详解](http://www.runoob.com/w3cnote/restful-architecture.html)
        /// * GET ： 从服务器获取资源
        /// * POST ：在服务器新建一个资源
        /// * PUT：在服务器更新资源（客户端提供改变后的完整资源，服务端返回完整的更新字段）
        /// * PATCH：在服务器更新资源（客户端提供改变的属性，服务端返回只发生了更新的字段）
        /// * DELETE：从服务器删除资源
        /// </remarks>
        [HttpPost(Name = "AddUser")]
        public OpResult<string> AddUser(UserModel userModel)
        {
            return new OpResult<string>(OpResultType.Success,$"新增用户：{userModel.UserName}成功！");
        }

        /// <summary>
        /// 删除用户
        /// </summary>
        /// <param name="id"></param>
        /// <returns></returns>
        [HttpDelete("{id}", Name = "DeleteUser")]
        public OpResult<string> DeleteUser(string id)
        {
            return new OpResult<string>(OpResultType.Success, $"删除用户：{id}成功！");
        }

        /// <summary>
        /// 修改用户
        /// </summary>
        /// <param name="userModel">用户模型</param>
        /// <returns></returns>
        [HttpPut(Name = "UpdateUser")]
        public OpResult<string> UpdateUser(UserModel userModel)
        {
            return new OpResult<string>(OpResultType.Success, $"修改用户：{userModel.UserName}成功！");
        }

        /// <summary>
        /// 查询所有用户
        /// </summary>
        /// <returns></returns>
        [HttpGet(Name = "GetUser")]
        public OpResult<List<SysUserDto>> GetUser()
        {
            var data = _authorDomainSvc.GetSysUserListDto();
            return new OpResult<List<SysUserDto>>(OpResultType.Success, "获取数据成功！", data);
        }

        /// <summary>
        /// 查询指定用户
        /// </summary>
        /// <param name="id">用户Id</param>
        /// <returns></returns>
        [HttpGet("{id}",Name = "GetUserById")]
        public OpResult<string> GetUserById(string id)
        {
            var list = new Dictionary<string, string>();
            list.Add("1", "张三");
            list.Add("2", "李四");
            list.Add("3", "王二");
            string value;
            var data = list.TryGetValue(id, out value);
            return new OpResult<string>(OpResultType.Success, $"获取到用户：{value}");
        }
        #endregion
    }

    /// <summary>
    /// 用户模型
    /// </summary>
    public class UserModel
    {
        /// <summary>
        /// 用户Id
        /// </summary>
        public string UserId { get; set; }

        /// <summary>
        /// 姓名
        /// </summary>
        public string UserName { get; set; }

        /// <summary>
        /// 性别
        /// </summary>
        public string Sex { get; set; }

        /// <summary>
        /// 出生日期
        /// </summary>
        public string Age { get; set; }

        /// <summary>
        /// 出生日期
        /// </summary>
        public string Birthday { get; set; }
    }
}
