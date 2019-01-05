using Swashbuckle.AspNetCore.Swagger;
using Swashbuckle.AspNetCore.SwaggerGen;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Titan.Blog.WebAPP.Swagger
{
    /// <summary>
    /// 过滤model返回值
    /// </summary>
    public class RemoveBogusDefinitionsDocumentFilter : IDocumentFilter
    {
        public void Apply(SwaggerDocument swaggerDoc, DocumentFilterContext context)
        {
            //swaggerDoc.Definitions.Remove("IFormFile");
            //swaggerDoc.Definitions = new Dictionary<string, Schema>{};// null;//清空所有类型
        }
    }
}
