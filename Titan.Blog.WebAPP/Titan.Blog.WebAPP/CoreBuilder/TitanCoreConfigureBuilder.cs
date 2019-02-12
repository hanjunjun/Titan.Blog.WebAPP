using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.Extensions.Configuration;
using RazorEngine;
using RazorEngine.Configuration;
using RazorEngine.Templating;
using RazorEngine.Text;
using Swashbuckle.AspNetCore.SwaggerUI;
using Titan.Blog.WebAPP.Filter;
using Titan.Blog.WebAPP.Swagger;

namespace Titan.Blog.WebAPP.CoreBuilder
{
    public class TitanCoreConfigureBuilder : ICoreConfigurationBuilder
    {
        private readonly IApplicationBuilder _app;
        private readonly IHostingEnvironment _env;
        private readonly IServiceProvider _svp;
        private readonly IConfiguration _configuration;
        public TitanCoreConfigureBuilder(IApplicationBuilder app, IHostingEnvironment env, IServiceProvider svp, IConfiguration configuration)
        {
            _app = app;
            _env = env;
            _svp = svp;
            _configuration = configuration;
        }
        public void UseRazorEngine()
        {
            var config = new TemplateServiceConfiguration();
            var service = RazorEngineService.Create(config);
            Engine.Razor = service;
            config.Language = Language.CSharp; // VB.NET as template language.
            config.EncodedStringFactory = new RawStringFactory(); // Raw string encoding.
            config.EncodedStringFactory = new HtmlEncodedStringFactory(); // Html encoding.
            config.Debug = true;
        }

        public void UseErrorHanle()
        {
            if (_env.IsDevelopment())
            {
                _app.UseDeveloperExceptionPage();
            }
            else
            {
                // The default HSTS value is 30 days. You may want to change this for production scenarios, see https://aka.ms/aspnetcore-hsts.
                //app.UseHsts();//hsts是http转https过程中用到的一种技术，防止劫持HTTP请求
            }
            _app.UseErrorHandling();
        }

        public void UseSwagger()
        {
            _app.UseSwagger();
            _app.UseSwaggerUI(c =>
            {
                //之前是写死的
                //c.SwaggerEndpoint("/swagger/v1/swagger.json", "ApiHelp V1");
                //c.RoutePrefix = "";//路径配置，设置为空，表示直接在根域名（localhost:8001）访问该文件,注意localhost:8001/swagger是访问不到的，去launchSettings.json把launchUrl去掉

                //根据版本名称倒序 遍历展示
                typeof(CustomApiVersion.ApiVersions).GetEnumNames().OrderByDescending(e => e).ToList().ForEach(version =>
                {
                    c.SwaggerEndpoint($"/swagger/{version}/swagger.json", $"{(_configuration.GetSection("Swagger"))["" + "ProjectName" + ""]} {version}");
                });
                // Display
                c.DefaultModelExpandDepth(2);//接口列表折叠配置
                c.DefaultModelRendering(ModelRendering.Model);
                c.DefaultModelsExpandDepth(-1);//不显示model
                c.DisplayOperationId();
                c.DisplayRequestDuration();
                c.DocExpansion(DocExpansion.None);
                //c.EnableDeepLinking();
                //c.EnableFilter();
                c.ShowExtensions();

                // Network
                //c.EnableValidator(null);//会导致页面右下角Error
                //c.SupportedSubmitMethods(SubmitMethod.Get);

                // Other
                c.DocumentTitle = "Titan.Blog.API 在线文档调试";
                //css注入
                c.InjectStylesheet("/swagger-common.css");//自定义样式
                c.InjectStylesheet("/buzyload/app.min.css");//等待load遮罩层样式
                //js注入
                c.InjectJavascript("/jquery/jquery.js");//jquery 插件
                c.InjectJavascript("/buzyload/app.min.js");//loading 遮罩层js
                c.InjectJavascript("/swagger-lang.js");//我们自定义的js


            });
        }

        public void UseAuth()
        {
            _app.UseAuthentication();
        }

        public void UseCors()
        {
            //跨域第二种方法，使用策略，详细策略信息在ConfigureService中
            _app.UseCors("LimitRequests");//将 CORS 中间件添加到 web 应用程序管线中, 以允许跨域请求。


            //跨域第一种版本，请要ConfigureService中配置服务 services.AddCors();
            //    app.UseCors(options => options.WithOrigins("http://localhost:8021").AllowAnyHeader()
            //.AllowAnyMethod()); 
        }

        public void UseOther()
        {
            //设置首页
            DefaultFilesOptions defaultFilesOptions = new DefaultFilesOptions();
            defaultFilesOptions.DefaultFileNames.Clear();
            defaultFilesOptions.DefaultFileNames.Add("index.html");
            _app.UseDefaultFiles(defaultFilesOptions);
            //设置默认路由
            //_app.UseMvc(routes =>
            //{
            //    routes.MapRoute(
            //        name: "default",
            //        template: "{controller=Home}/{action=Index}/{id?}");
            //});
            // 跳转https
            _app.UseHttpsRedirection();
            // 使用静态文件
            _app.UseStaticFiles();
            // 使用cookie
            _app.UseCookiePolicy();
            _app.UseStatusCodePages();//把错误码返回前台，比如是404
            //app.UseHttpsRedirection();//将Http重定向Https
            _app.UseMvc();
        }
    }
}
