using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Http;
using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Net;
using System.Threading.Tasks;
using System.Xml.Serialization;
using Microsoft.AspNetCore.Hosting;
using Titan.Blog.Infrastructure.Log;
using Titan.Blog.Model.ResultModel;

namespace Titan.Blog.WebAPP.Filter
{
    /// <summary>
    /// 全局异常拦截器
    /// </summary>
    public class ErrorHandlingMiddleware
    {
        private readonly RequestDelegate next;
        private readonly ILoggerHelper _loggerHelper;
        private readonly IHostingEnvironment _env;

        public ErrorHandlingMiddleware(RequestDelegate next, ILoggerHelper loggerHelper, IHostingEnvironment env)
        {
            this.next = next;
            _loggerHelper = loggerHelper;
            _env = env;
        }
        public async Task Invoke(HttpContext context)
        {
            try
            {
                await next(context);
            }
            catch (Exception ex)
            {
                await HandleExceptionAsync(context, ex, _env.IsDevelopment());
                //记录日志
                _loggerHelper.Error(ex.Message, FormatMessage(ex.Message, ex));
            }
        }

        private static async Task HandleExceptionAsync(HttpContext context, Exception exception,bool isDevelopment)
        {
            if (exception == null) return;
            await WriteExceptionAsync(context, exception, isDevelopment).ConfigureAwait(false);
        }

        private static async Task WriteExceptionAsync(HttpContext context, Exception exception,bool isDevelopment)
        {
            var result = JsonConvert.SerializeObject(new OpResult(OpResultType.Error, (isDevelopment ? exception.ToString():exception.Message)));

            //返回友好的提示
            var response = context.Response;

            //状态码
            if (exception is UnauthorizedAccessException)
                response.StatusCode = (int)HttpStatusCode.Unauthorized;
            else if (exception is Exception)
                response.StatusCode = (int)HttpStatusCode.InternalServerError;

            response.ContentType = context.Request.Headers["Accept"];

            if (response.ContentType.ToLower() == "application/xml")
            {
                await response.WriteAsync(result).ConfigureAwait(false);
            }
            else
            {
                response.ContentType = "application/json";
                await response.WriteAsync(result).ConfigureAwait(false);
            }
        }


        /// <summary>
        /// 自定义返回格式
        /// </summary>
        /// <param name="throwMsg"></param>
        /// <param name="ex"></param>
        /// <returns></returns>
        public static string FormatMessage(string throwMsg, Exception ex)
        {
            return string.Format("【自定义错误】：{0} \r\n【异常类型】：{1} \r\n【异常信息】：{2} \r\n【堆栈调用】：{3}", new object[] { throwMsg,
                ex.GetType().Name, ex.Message, ex.StackTrace });
        }


        /// <summary>
        /// 对象转为Xml
        /// </summary>
        /// <param name="o"></param>
        /// <returns></returns>
        private static string Object2XmlString(object o)
        {
            StringWriter sw = new StringWriter();
            try
            {
                XmlSerializer serializer = new XmlSerializer(o.GetType());
                serializer.Serialize(sw, o);
            }
            catch
            {
                //Handle Exception Code
            }
            finally
            {
                sw.Dispose();
            }
            return sw.ToString();
        }
    }
    
    /// <summary>
    /// 自定义拦截器
    /// </summary>
    public static class ErrorHandlingExtensions
    {
        /// <summary>
        /// 错误拦截
        /// </summary>
        /// <param name="builder"></param>
        /// <returns></returns>
        public static IApplicationBuilder UseErrorHandling(this IApplicationBuilder builder)
        {
            return builder.UseMiddleware<ErrorHandlingMiddleware>();
        }
    }
}