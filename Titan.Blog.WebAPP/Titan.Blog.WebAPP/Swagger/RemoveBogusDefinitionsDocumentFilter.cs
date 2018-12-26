using Swashbuckle.AspNetCore.Swagger;
using Swashbuckle.AspNetCore.SwaggerGen;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Titan.Blog.WebAPP.Swagger
{
    /// <summary>
    /// 文档过滤
    /// </summary>
    public class RemoveBogusDefinitionsDocumentFilter : IDocumentFilter
    {
        public void Apply(SwaggerDocument swaggerDoc, DocumentFilterContext context)
        {
            //swaggerDoc.Definitions.Remove("IFormFile");
            swaggerDoc.Definitions = null;//清空所有类型
        }
    }
}
