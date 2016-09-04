using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection;
using System.Web;
using System.Web.Mvc;
using System.Web.Optimization;
using System.Web.Routing;
using Autofac;
using Autofac.Integration.Mvc;
using Eron.core.DataAccess;
using Eron.core.Encode;
using Eron.core.Services;
using Eron.web.Controllers;
using Eron.web.Models.FileHelper;
using Microsoft.AspNet.Identity;
using Microsoft.AspNet.Identity.EntityFramework;

namespace Eron.web
{
    public class MvcApplication : System.Web.HttpApplication
    {
        protected void Application_Start()
        {
            AreaRegistration.RegisterAllAreas();
            FilterConfig.RegisterGlobalFilters(GlobalFilters.Filters);
            RouteConfig.RegisterRoutes(RouteTable.Routes);
            BundleConfig.RegisterBundles(BundleTable.Bundles);

            var builder = new ContainerBuilder();

            builder.RegisterControllers(typeof(MvcApplication).Assembly);
            builder.RegisterModelBinders(Assembly.GetExecutingAssembly());
            builder.RegisterType<HomeController>().InstancePerRequest();
            builder.RegisterType<RepositoryService>().As<IRepositoryService>();
            builder.RegisterType<Encode>().AsSelf().As<IEncode>();
            builder.RegisterType<ApplicationUserManager>().AsSelf();
            builder.RegisterType<UserStore<ApplicationUser>>().As<IUserStore<Eron.core.DataAccess.ApplicationUser>>();
            builder.RegisterType<FileHelper>().As<IFileHelper>();
            //builder.RegisterType<ModelFactory>().As<IModelFactory>();
            //builder.RegisterType<HttpContext>().InstancePerRequest().AsSelf();

            var container = builder.Build();
            DependencyResolver.SetResolver(new AutofacDependencyResolver(container));
        }
    }
}
