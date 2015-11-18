
using System;
using System.ComponentModel.Composition;
using System.ComponentModel.Composition.Hosting;
using System.IO;
using System.Web.Hosting;
using System.Web.Http;
using System.Web.Http.Dispatcher;
using System.Web.Mvc;
using System.Web.Optimization;
using System.Web.Routing;
using Microsoft.Owin;
using NServiceBus;
using NServiceBus.Persistence.NHibernate;
using Owin;

[assembly: OwinStartup(typeof(TaiJi.Framework.Startup))]

namespace TaiJi.Framework
{
    public class WebApiApplication : System.Web.HttpApplication
    {
        public static IBus Bus { get; set; }

        protected void Application_Start()
        {
            Configure.ScaleOut(s => s.UseSingleBrokerQueue());

            Bus = Configure.With()
                           .DefaultBuilder()
                           .UseTransport<SqlServer>()
                           .PurgeOnStartup(true)
                           .UnicastBus()
                           .RunHandlersUnderIncomingPrincipal(false)
                           .CreateBus()
                           .Start(() => Configure.Instance.ForInstallationOn<NServiceBus.Installation.Environments.Windows>().Install());

            RouteConfig.RegisterRoutes(RouteTable.Routes);
            FilterConfig.RegisterGlobalFilters(GlobalFilters.Filters);
            GlobalConfiguration.Configure(WebApiConfig.Register);
            BundleConfig.RegisterBundles(BundleTable.Bundles);
        }
    }

    public class CustomInit : INeedInitialization
    {
        public void Init()
        {
            NHibernatePersistence.UseAsDefault();
        }
    }

    public class Startup
    {
        public void Configuration(IAppBuilder app)
        {
            app.MapSignalR();
        }
    }
}
