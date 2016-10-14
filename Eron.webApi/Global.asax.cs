using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection;
using System.Web;
using System.Web.Http;
using System.Web.Mvc;
using System.Web.Optimization;
using System.Web.Routing;
using Autofac;
using Autofac.Integration.WebApi;
using Eron.core.DataAccess;
using Eron.core.Encode;
using Eron.core.Models.FileHelper;
using Eron.core.Services;

namespace Eron.webApi
{
    public class WebApiApplication : System.Web.HttpApplication
    {
        protected void Application_Start()
        {
            GlobalConfiguration.Configure(WebApiConfig.Register);
            AreaRegistration.RegisterAllAreas();
            FilterConfig.RegisterGlobalFilters(GlobalFilters.Filters);
            RouteConfig.RegisterRoutes(RouteTable.Routes);
            BundleConfig.RegisterBundles(BundleTable.Bundles);

            var builder = new ContainerBuilder();

            builder.RegisterApiControllers(typeof(WebApiApplication).Assembly);
            builder.RegisterApiControllers(Assembly.GetExecutingAssembly());
            builder.RegisterType<RepositoryService>().As<IRepositoryService>();
            builder.RegisterType<Encode>().AsSelf().As<IEncode>();
            //builder.RegisterType<ApplicationUserManager>().AsSelf();
            //builder.RegisterType<UserStore<ApplicationUser>>().As<IUserStore<Eron.core.DataAccess.ApplicationUser>>();
            builder.RegisterType<FileHelper>().As<IFileHelper>();
            //builder.RegisterType<ModelFactory>().As<IModelFactory>();
            //builder.RegisterType<HttpContext>().InstancePerRequest().AsSelf();

            var container = builder.Build();
            GlobalConfiguration.Configuration.DependencyResolver =
                 new AutofacWebApiDependencyResolver(container);
        }
    }
}
