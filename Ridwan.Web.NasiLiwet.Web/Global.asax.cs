using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection;
using System.Web;
using System.Web.Mvc;
using System.Web.Optimization;
using System.Web.Routing;
using Microsoft.AspNet.Identity;
using Ridwan.Web.NasiLiwet.Web.repository;
using SimpleInjector;
using SimpleInjector.Integration.Web.Mvc;

namespace Ridwan.Web.NasiLiwet.Web
{
    public class MvcApplication : System.Web.HttpApplication
    {
        protected void Application_Start()
        {
            AreaRegistration.RegisterAllAreas();
            FilterConfig.RegisterGlobalFilters(GlobalFilters.Filters);
            RouteConfig.RegisterRoutes(RouteTable.Routes);
            BundleConfig.RegisterBundles(BundleTable.Bundles);
            Bootstrap();
            ValueProviderFactories.Factories.Add(new JsonValueProviderFactory());
        }

        private static void Bootstrap()
        {
            // Create the container as usual.
            var container = new Container();

            // Register your types, for instance using the RegisterWebApiRequest
            // extension from the integration package:
            container.Register<IProductRepository, ProductRepository>();
            // This is an extension method from the integration package.
            container.RegisterMvcControllers(Assembly.GetExecutingAssembly());

            // This is an extension method from the integration package as well.
            container.RegisterMvcIntegratedFilterProvider();

           // container.Verify();

            DependencyResolver.SetResolver(new SimpleInjectorDependencyResolver(container));

        }
    }
}
