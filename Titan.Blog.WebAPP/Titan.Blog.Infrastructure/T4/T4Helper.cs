using RazorEngine;
using RazorEngine.Templating;
using Swashbuckle.AspNetCore.Swagger;
using System;

namespace Titan.Blog.Infrastructure.T4
{
    public class T4Helper
    {
        public static string GeneritorSwaggerHtml(string templatePath, SwaggerDocument model)
        {
            var template = System.IO.File.ReadAllText(templatePath);
            var result = Engine.Razor.RunCompile(template, "Titan", typeof(SwaggerDocument), model);
            //var result = Engine.Razor.RunCompile(new LoadedTemplateSource(template, templatePath), typeof(SwaggerDocument), null, model);
            return result;
        }
    }
}
