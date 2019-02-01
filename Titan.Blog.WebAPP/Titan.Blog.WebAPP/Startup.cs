using Autofac;
using Autofac.Extensions.DependencyInjection;
using Autofac.Extras.DynamicProxy;
using AutoMapper;
using log4net;
using log4net.Config;
using Microsoft.AspNetCore.Authentication.JwtBearer;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Caching.Memory;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.IdentityModel.Tokens;
using RazorEngine;
using RazorEngine.Configuration;
using RazorEngine.Templating;
using RazorEngine.Text;
using Swashbuckle.AspNetCore.Swagger;
using Swashbuckle.AspNetCore.SwaggerGen;
using Swashbuckle.AspNetCore.SwaggerUI;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Reflection;
using System.Security.Claims;
using StackExchange.Redis;
using Titan.Blog.Infrastructure.Cache;
using Titan.Blog.Infrastructure.Log;
using Titan.Blog.Infrastructure.Utility;
using Titan.Blog.Model.CommonModel.Enums;
using Titan.Blog.WebAPP.AOP;
using Titan.Blog.WebAPP.Auth.Policys;
using Titan.Blog.WebAPP.AutoMapper;
using Titan.Blog.WebAPP.Extensions;
using Titan.Blog.WebAPP.Filter;
using Titan.Blog.WebAPP.Swagger;

namespace Titan.Blog.WebAPP
{
    public class Startup
    {
        #region 仓储 --Log4Net、.Net Core Configuration

        /// <summary>
        /// log4net 仓储库
        /// </summary>
        //public static ILoggerRepository Repository { get; set; }
        private readonly IConfiguration _configuration;

        #endregion

        #region .Net Core 启动
        public Startup(IConfiguration configuration)
        {
            _configuration = configuration;
            //log4net
            LogHelper.Repository = LogManager.CreateRepository("Titan.Blog.WebAPP");//创建log4net仓储，并丢给公共库
            //指定配置文件
            XmlConfigurator.Configure(LogHelper.Repository, new FileInfo("log4net.config"));//重定向log4net仓储配置文件
        }
        #endregion

        #region .Net Core 配置服务注入
        // This method gets called by the runtime. Use this method to add services to the container.
        public IServiceProvider ConfigureServices(IServiceCollection services)
        {
            return services.AddTitanServiceProvider(_configuration);
        }
        #endregion

        #region .Net Core 配置
        // This method gets called by the runtime. Use this method to configure the HTTP request pipeline.
        public void Configure(IApplicationBuilder app, IHostingEnvironment env, IServiceProvider svp)
        {
            app.AddTitanConfigureProvider(env, svp, _configuration);
        }
        #endregion
    }
}
