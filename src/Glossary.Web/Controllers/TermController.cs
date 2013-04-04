using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http;
using System.Web.Http;
using Company.Glossary.Entities;
using Company.Glossary.Entities.Repositories;
using Company.Glossary.Web.Infrastructure;
using System.Net;
using System.Security.Principal;

namespace Company.Glossary.Web.Controllers
{
    public class TermController : BaseApiController
    {
        public TermController(ICatalog catalog)
            : base(catalog)
        {
        }

        [HttpGet]
        public IEnumerable<Term> Get(bool asc)
        {
            IEnumerable<Term> result;
            if (asc)
                result = Catalog.TermRepository.AllActive().OrderBy(x => x.Name);
            else
                result = Catalog.TermRepository.AllActive().OrderByDescending(x => x.Name);

            return result;
        }

        [HttpGet]
        public Term Get(int id)
        {
            var term = Catalog.TermRepository.GetById(id);
            if (term == null)
            {
                throw new NotFoundException();
            }
            return term;
        }

        [HttpPost]
        public Term Create(Term param)
        {
            var term = Catalog.TermRepository.Create(param);
            term.CreatedBy = GetContextUser().Name;
            Catalog.SaveChanges();
            return term;
        }

        [HttpPost]
        public void Update(Term param)
        {
            var term = Catalog.TermRepository.GetById(param.Id);
            if (term == null)
            {
                throw new NotFoundException();
            }

            term.Name = param.Name;
            term.Definition = param.Definition;
            term.Active = param.Active;
            term.ModifiedOn = DateTime.Now;
            term.ModifiedBy = GetContextUser().Name;

            Catalog.SaveChanges();
        }

        [HttpPost]
        public void Delete(int id)
        {
            var term = Catalog.TermRepository.GetById(id);
            if (term == null)
            {
                throw new NotFoundException();
            }

            Catalog.TermRepository.Delete(id);
            Catalog.SaveChanges();
        }
    }
}
