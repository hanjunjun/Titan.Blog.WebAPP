using System.Collections.Generic;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Titan.Blog.Infrastructure.Data;
using Titan.Blog.Model.CommonModel;
using Titan.Blog.WebAPP.Extensions;
using Titan.Blog.WebAPP.Swagger;

namespace Titan.Blog.WebAPP.Controllers.v2
{
    /// <summary>
    /// Restful API 示例 
    /// </summary>
    [Produces("application/json")]//Swagger可以根据这个来自动选择请求类型
    [CustomRoute(CustomApiVersion.ApiVersions.v2)]
    [Authorize("Permission")]
    public class TestController : ApiControllerBase
    {
        #region 成员、构造函数注入
        public TestController()
        {

        }
        #endregion

        #region 增删改查
        /// <summary>
        /// 数组参数
        /// </summary>
        /// <param name="arrayStr"></param>
        /// <returns></returns>
        /// <remarks>
        /// <h2>Testing html table</h2>
        /// <table border="1">
        ///     <tr>
        ///         <td colspan="3"><span class="method">ONE</span></td>
        ///     </tr>
        ///     <tr>
        ///         <td>ABC11</td>
        ///         <td>ABC22</td>
        ///         <td>ABC33</td>
        ///     </tr>
        /// </table>
        /// <img src="https://yuml.me/diagram/class/%5BSupplier%7Bbg:orange%7D%5D,%5BSupplier%5D-0..1%3E%5BAddress%5D,%5BSupplier%5D" />
        /// <img src="data:image/png;base64, iVBORw0KGgoAAAANSUhEUgAAAAUAAAAFCAYAAACNbyblAAAAHElEQVQI12P4//8/w38GIAXDIBKE0DHxgljNBAAO9TXL0Y4OHwAAAABJRU5ErkJggg==" alt="Red dot" />
        /// </remarks>
        [HttpPost("ZArrayTest")]
        public OpResult<List<object>> BlogList([FromBody]List<string> arrayStr)
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

        ///<summary>获取博客列表</summary>
        /// <remarks>
        /// Testing Markdown
        /// *Italic*
        /// **Bold**
        /// # Heading 1
        /// ## Heading 2
        /// [Link](https://www.qq.com/)
        /// * 列表1
        /// * 列表2
        /// * 列表3
        ///
        /// > Blockquote
        /// `Inline code` with backticks
        /// 接口需要授权
        /// ---
        /// Block1 Line1
        /// Block1 Line2
        ///
        /// Block2 Line1
        /// Block2 Line2
        /// </remarks>
        [HttpGet("BlogList",Name = "BlogList")]
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
        [HttpGet("BlogList/{id}",Name = "BlogListById")]
        public OpResult<List<object>> BlogList(string id)
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

        /// <summary>
        /// 根据Id获取博客详情
        /// </summary>
        /// <param name="id">博客Id</param>
        /// <returns>博客详情</returns>
        [AllowAnonymous]
        [HttpPost("BlogList/{id}", Name = "BlogListByIds")]
        public OpResult<List<object>> BlogLists(string id)
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

        /// <summary>
        /// 新增博客
        /// </summary>
        /// <param name="value"></param>
        /// <returns></returns>
        [HttpPost("AddBlog",Name = "AddBlog")]
        public OpResult<string> Post([FromBody] XmlModel value)
        {
            var userInfo = UserInfo;
            return new OpResult<string>(OpResultType.Success, $"保存{value}成功！");
        }

        /// <summary>
        /// 根据Id更新博客
        /// </summary>
        /// <param name="id">博客Id</param>
        /// <param name="value">博客内容</param>
        /// <returns></returns>
        [HttpPut("UpdateBlog/{id}", Name = "UpdateBlog")]
        public OpResult<string> Put(int id, XmlModel value)
        {
            var userInfo = UserInfo;
            return new OpResult<string>(OpResultType.Success, $"更新{id}成功！");
        }

        /// <summary>
        /// 根据Id删除博客
        /// </summary>
        /// <param name="id">博客Id</param>
        //[CustomRoute("DeleteBlog")]
        [HttpDelete("DeleteBlog/{id}", Name = "DeleteBlog")]
        public OpResult<string> Delete(int id)
        {
            var userInfo = UserInfo;
            return new OpResult<string>(OpResultType.Success, $"删除{id}成功！");
        }

        /// <summary>
        /// Hidden测试
        /// </summary>
        /// <param name="id"></param>
        /// <param name="name"></param>
        /// <returns></returns>
        /// <remarks>
        /// ## TESTING MARKDOWN TABLES
        /// ### start table
        ///
        /// | Tables        | Are           | Cool  |
        /// | ------------- |:-------------:| -----:|
        /// | col 3 is      | right-aligned | $1600 |
        /// | col 2 is      | centered      |   $12 |
        /// | zebra stripes | are neat      |    $1 |
        ///
        /// ### end table
        /// </remarks>
        [AllowAnonymous]
        [HttpGet("HiddenTest/{id}/{name}", Name = "HiddenTest1")]
        public OpResult<string> HiddenFunc1(string id,string name)
        {
            return new OpResult<string>(OpResultType.Success, $"获取{id}, {name}");
        }

        /// <summary>
        /// Hidden2测试
        /// </summary>
        /// <param name="id"></param>
        /// <param name="name"></param>
        /// <returns></returns>
        /// <remarks>
        /// ## TESTING MARKDOWN TABLES
        /// ### start table
        ///
        /// | Tables        | Are           | Cool  |
        /// | ------------- |:-------------:| -----:|
        /// | col 3 is      | right-aligned | $1600 |
        /// | col 2 is      | centered      |   $12 |
        /// | zebra stripes | are neat      |    $1 |
        ///
        /// ### end table
        /// </remarks>
        [AllowAnonymous]
        [HttpPut("HiddenTest/{id}/{name}", Name = "HiddenTest2")]
        public OpResult<string> HiddenFunc2(string id, string name)
        {
            return new OpResult<string>(OpResultType.Success, $"获取{id}, {name}");
        }

        /// <summary>
        /// ApiExplorerSettings隐藏测试
        /// </summary>
        /// <param name="a"></param>
        /// <param name="b"></param>
        /// <returns></returns>
        /// <remarks>
        /// ## [ApiExplorerSettings(IgnoreApi = true)]
        /// ### 使用这个特性可以隐藏该接口不在Swagger文档中显示，但接口依然可以调用
        /// </remarks>
        //[ApiExplorerSettings(IgnoreApi = true)]
        [HttpGet("FormHeader", Name = "FormHeader")]
        public OpResult<string> HiddenFunc([FromHeader]string a,[FromHeader]string b)
        {
            return new OpResult<string>(OpResultType.Success, $"获取{a}, {b}");
        }
        #endregion
    }
}
