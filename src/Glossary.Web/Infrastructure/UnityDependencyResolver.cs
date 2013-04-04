using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Http.Services;
using Microsoft.Practices.Unity;

namespace Company.Glossary.Web.Infrastructure
{
    public class UnityDependencyResolver : IDependencyResolver, System.Web.Mvc.IDependencyResolver
    {
        readonly IUnityContainer container;

        public UnityDependencyResolver(IUnityContainer container)
        {
            this.container = container;
        }

        public object GetService(Type serviceType)
        {
            if (!container.IsRegistered(serviceType))
            {
                if (serviceType.IsAbstract || serviceType.IsInterface)
                {
                    return null;
                }
            }

            return container.Resolve(serviceType);
        }

        public IEnumerable<object> GetServices(Type serviceType)
        {
            return container.ResolveAll(serviceType);
        }
    }
}