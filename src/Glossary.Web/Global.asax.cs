using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Http;
using System.Web.Mvc;
using System.Web.Optimization;
using System.Web.Routing;
using Company.Glossary.Entities.Repositories;
using Company.Glossary.Web.Infrastructure;
using Microsoft.Practices.Unity;
using Company.Glossary.Data.EF.Infrastructure;
using System.Data.Entity;
using Company.Glossary.Web.Controllers;
using System.Data.Entity.Validation;

namespace Glossary.Web
{
    // Note: For instructions on enabling IIS6 or IIS7 classic mode, 
    // visit http://go.microsoft.com/?LinkId=9394801

    public class MvcApplication : System.Web.HttpApplication
    {
        public static void RegisterGlobalFilters(GlobalFilterCollection filters)
        {
            filters.Add(new HandleErrorAttribute());
        }

        public static void RegisterRoutes(RouteCollection routes)
        {
            routes.IgnoreRoute("{resource}.axd/{*pathInfo}");

            routes.MapHttpRoute(
                name: "DefaultApi",
                routeTemplate: "api/{controller}/{action}/{id}",
                defaults: new { id = RouteParameter.Optional }
            );

            routes.MapRoute(
                name: "Default",
                url: "{controller}/{action}/{id}",
                defaults: new { controller = "Home", action = "Index", id = UrlParameter.Optional }
            );
        }

        protected void Application_Start()
        {
            RegisterDependencies();

            AreaRegistration.RegisterAllAreas();

            var exceptionHandlerFilter = new ExceptionHandlerFilter();
            exceptionHandlerFilter.Mappings.Add(typeof(DbEntityValidationException), System.Net.HttpStatusCode.BadRequest);

            //GlobalFilters.Filters.Add(exceptionHandlerFilter, 0);

            GlobalConfiguration.Configuration.Filters.Add(exceptionHandlerFilter);

            RegisterGlobalFilters(GlobalFilters.Filters);
            RegisterRoutes(RouteTable.Routes);

            BundleTable.Bundles.EnableDefaultBundles();

            Database.SetInitializer(new GlossaryDbInitizilizer());
        }

        public static void RegisterDependencies()
        {
            var container = new UnityContainer();
            container.RegisterType<ICatalog, Catalog>();

            var resolver = new UnityDependencyResolver(container);
            GlobalConfiguration.Configuration.ServiceResolver.SetResolver(resolver);

            DependencyResolver.SetResolver(resolver);
        }

        protected void Application_Error()
        {
            Exception exception = Server.GetLastError();

            if (exception != null &&
                exception.Message == "Maximum request length exceeded.")
            {
                Server.ClearError();
                Response.StatusCode = 500;
                Response.Write("<La imagen no puede superar los 2MB!>");
                Response.End();
            }
        }
    }
}