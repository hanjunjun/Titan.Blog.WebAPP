using System;
using System.Collections.Generic;
using System.Text;
using Titan.AppService.ModelService;
using Titan.Model.DataModel;

namespace Titan.Blog.AppService.DomainService
{
    public class AuthorDomainSvc
    {
        private readonly AuthorSvc _authorSvc;
        public AuthorDomainSvc(AuthorSvc authorSvc)
        {
            _authorSvc = authorSvc;
        }

        public List<Author> GetList()
        {
           return _authorSvc.FindModelByValue(x => true);
        }
    }
}
