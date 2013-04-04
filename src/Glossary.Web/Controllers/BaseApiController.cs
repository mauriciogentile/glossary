using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http;
using System.Web.Http;
using Company.Glossary.Entities.Repositories;
using System.Web.Mvc;
using System.Security.Principal;

namespace Company.Glossary.Web.Controllers
{
    public abstract class BaseApiController : ApiController
    {
        readonly ICatalog catalog;

        protected BaseApiController(ICatalog catalog)
        {
            this.catalog = catalog;
        }

        protected virtual IIdentity GetContextUser()
        {
            IIdentity user;
            if (ControllerContext != null)
            {
                IPrincipal principal = ControllerContext.Request.GetUserPrincipal();
                if (principal != null)
                {
                    user = principal.Identity;
                    if (user != null && !string.IsNullOrEmpty(user.Name))
                    {
                        return user;
                    }
                }
            }

            user = WindowsIdentity.GetAnonymous();
            if (user != null && !string.IsNullOrEmpty(user.Name))
            {
                return user;
            }

            return WindowsIdentity.GetCurrent();
        }

        public ICatalog Catalog { get { return catalog; } }
    }
}
