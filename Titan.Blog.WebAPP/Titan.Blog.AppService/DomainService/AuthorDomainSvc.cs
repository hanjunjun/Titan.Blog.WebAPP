using Microsoft.AspNetCore.Hosting;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Microsoft.EntityFrameworkCore;
using Titan.Blog.AppService.ModelService;
using Titan.Model.DataModel;
using Titan.RepositoryCode;

namespace Titan.Blog.AppService.DomainService
{
    public class AuthorDomainSvc
    {
        private readonly AuthorSvc _authorSvc;
        private ModelRespositoryFactory<Author, Guid> _modelSvc;
        public AuthorDomainSvc(AuthorSvc authorSvc, ModelRespositoryFactory<Author, Guid> modelSvc)
        {
            _authorSvc = authorSvc;
            _modelSvc = modelSvc;
        }

        public List<Author> GetList()
        {
            return _authorSvc.FindModelByValue(x => true);
            //return new List<Author>();
        }

        public List<Author> SqlTest()
        {
            return _modelSvc.context.Set<Author>().FromSql("select * from Author").ToList();

        }

        public int CommandSql()
        {
            return _modelSvc.context.Database.ExecuteSqlCommand("INSERT INTO [TestDB].[dbo].[Author] ([Id], [AuthorName], [PKId]) VALUES ('1', '管理员', newid());");
        }
    }
}
