using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using System.Web.Routing;
using NServiceBus;
using StructureMap;

namespace EventAggAtLarge.WebClient
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

            routes.MapRoute(
                "Default", // Route name
                "{controller}/{action}/{id}", // URL with parameters
                new { controller = "Home", action = "Index", id = UrlParameter.Optional } // Parameter defaults
            );
        }

        private void InitializeNServiceBus()
        {
            NServiceBus.Configure
                .WithWeb()                      // scan the /bin folder of the web app
                .Log4Net()                      // wire up log4net 
                .StructureMapBuilder(           // use StructureMap for IoC
                    ObjectFactory.Container     // ...with the given Container 
                 )
                .XmlSerializer()                // serialize messages as XML
                .MsmqTransport()                // use MSMQ as transactional transport
                .UnicastBus()                   // use unicast messaging
                .CreateBus()
                .Start();
        }

        protected void Application_Start()
        {
            AreaRegistration.RegisterAllAreas();

            RegisterGlobalFilters(GlobalFilters.Filters);
            RegisterRoutes(RouteTable.Routes);

            InitializeNServiceBus();
        }
    }
}