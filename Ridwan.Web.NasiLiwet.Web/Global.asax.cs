using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection;
using System.Web;
using System.Web.Http;
using System.Web.Http.Dispatcher;
using System.Web.Mvc;
using System.Web.Optimization;
using System.Web.Routing;
using Microsoft.AspNet.Identity;
using Ridwan.Web.NasiLiwet.Web.repository;
using SimpleInjector;
using SimpleInjector.Integration.Web.Mvc;
using SimpleInjector.Integration.WebApi;

namespace Ridwan.Web.NasiLiwet.Web
{
    public class MvcApplication : System.Web.HttpApplication
    {
        protected void Application_Start()
        {
            AreaRegistration.RegisterAllAreas();
            WebApiConfig.Register(GlobalConfiguration.Configuration);

            FilterConfig.RegisterGlobalFilters(GlobalFilters.Filters);
            RouteConfig.RegisterRoutes(RouteTable.Routes);
            BundleConfig.RegisterBundles(BundleTable.Bundles);
            Bootstrap();
            ValueProviderFactories.Factories.Add(new JsonValueProviderFactory());
            GlobalConfiguration.Configuration.EnsureInitialized();


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
            container.RegisterWebApiControllers(GlobalConfiguration.Configuration);
            
            // This is an extension method from the integration package as well.
            container.RegisterMvcIntegratedFilterProvider();
            
            // container.Verify();

            DependencyResolver.SetResolver(new SimpleInjectorDependencyResolver(container));
            GlobalConfiguration.Configuration.DependencyResolver =
       new SimpleInjectorWebApiDependencyResolver(container);
        }
//        public static void RegisterApiControllers(
//   Container container, IHttpControllerTypeResolver typeResolver = null)
//{
//    if (container == null)
//    {
//        throw new ArgumentNullException("container");
//    }

//    typeResolver = typeResolver ?? GlobalConfiguration
//        .Configuration.Services.GetHttpControllerTypeResolver();

//    foreach (var controllerType in typeResolver.GetCo‌​ntrollerTypes())
//    {
//        container.Register(controllerType);
//    }
//}

    }
}
