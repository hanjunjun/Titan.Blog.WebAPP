using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Titan.Blog.WebAPP.CoreBuilder
{
    public interface ICoreServiceBuilder
    {
        /// <summary>
        /// 添加EF数据库上下文
        /// </summary>
        void AddDbcontext();

        /// <summary>
        /// 添加Mvc
        /// </summary>
        void AddMvcExtensions();

        /// <summary>
        /// 添加缓存
        /// </summary>
        void AddCache();

        /// <summary>
        /// 添加日志
        /// </summary>
        void AddLog();

        /// <summary>
        /// 添加AutoMapper自动对象映射组件
        /// </summary>
        void AddAutoMapper();

        /// <summary>
        /// 添加Cors跨域
        /// </summary>
        void AddCors();

        /// <summary>
        /// 添加Swagger生成器
        /// </summary>
        void AddSwaggerGenerator();

        /// <summary>
        /// 添加Jwt授权
        /// </summary>
        void AddJwtAuth();

        /// <summary>
        /// 添加自定义Http上下文
        /// </summary>
        void AddHttpContext();

        /// <summary>
        /// 添加IOC容器
        /// </summary>
        IServiceProvider AddIocContainer();
    }
}
