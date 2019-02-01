using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Titan.Blog.WebAPP.CoreBuilder;

namespace Titan.Blog.WebAPP.Extensions
{
    public static class TitanBuilderCollectionExtensions
    {
        /// <summary>
        /// 添加中间件
        /// </summary>
        /// <param name="services"></param>
        /// <param name="configuration"></param>
        /// <returns></returns>
        public static IServiceProvider AddTitanServiceProvider(this IServiceCollection services, IConfiguration configuration)
        {
            ICoreServiceBuilder servicebuilder = new TitanCoreServiceBuilder(services, configuration);
            servicebuilder.AddMvcExtensions();
            servicebuilder.AddCache();
            servicebuilder.AddLog();
            servicebuilder.AddAutoMapper();
            servicebuilder.AddCors();
            servicebuilder.AddSwaggerGenerator();
            servicebuilder.AddJwtAuth();
            servicebuilder.AddHttpContext();
            return servicebuilder.AddIocContainer();
        }

        /// <summary>
        /// 添加配置
        /// </summary>
        /// <param name="app"></param>
        /// <param name="env"></param>
        /// <param name="svp"></param>
        /// <param name="configuration"></param>
        public static void AddTitanConfigureProvider(this IApplicationBuilder app, IHostingEnvironment env,
            IServiceProvider svp, IConfiguration configuration)
        {
            ICoreConfigurationBuilder configurationBuilder = new TitanCoreConfigureBuilder(app, env, svp, configuration);
            configurationBuilder.UseRazorEngine();
            configurationBuilder.UseErrorHanle();
            configurationBuilder.UseSwagger();
            configurationBuilder.UseAuth();
            configurationBuilder.UseCors();
            configurationBuilder.UseOther();
        }
    }
}
