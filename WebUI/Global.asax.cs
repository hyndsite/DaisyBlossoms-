using System;
using System.Configuration;
using System.Web;
using System.Web.Mvc;
using System.Web.Routing;

using NHibernate;
using NHibernate.Context;
using NHibernateLayer;
using RepoInfrastructure;
using WebUI.Infrastructure;
using StructureMap;


namespace WebUI {
    // Note: For instructions on enabling IIS6 or IIS7 classic mode, 
    // visit http://go.microsoft.com/?LinkId=9394801

    public class MvcApplication : System.Web.HttpApplication {

        public static readonly ISessionFactory SessionFactory = BuildSessionFactory();
        private IContainer container;

        public static ISession Session {
            get { return HttpContext.Current.Items["NhibernateCurrentSession"] as ISession; }
            set { HttpContext.Current.Items["NhibernateCurrentSession"] = value; }
        }

        public MvcApplication() {
            BeginRequest += OnBeginRequest;
            EndRequest += OnEndRequest;
        }

        public static void RegisterRoutes(RouteCollection routes) {
            
            routes.IgnoreRoute("{resource}.axd/{*pathInfo}");

            routes.MapRoute(
                "", // Route name
                "admin/{action}/{id}", // URL with parameters
                new { controller = "Admin", action = "List", id = UrlParameter.Optional } // Parameter defaults
            );

            routes.MapRoute(
                "Default", // Route name
                "{controller}/{action}/{id}", // URL with parameters
                new { controller = "Home", action = "Index", id = UrlParameter.Optional } // Parameter defaults
            );

        }

        protected void Application_Start() {
            AreaRegistration.RegisterAllAreas();

            RegisterRoutes(RouteTable.Routes);
            container = new IoC().Intialize();
            DependencyResolver.SetResolver(new StructureMapDependencyResolver(container));
        }

        

        private void OnBeginRequest(object sender, EventArgs args) {
            HttpContext.Current.Items["NhibernateCurrentSession"] = SessionFactory.OpenSession();//container.GetInstance<ISession>();
            ManagedWebSessionContext.Bind(HttpContext.Current, Session);

            
        }

        private void OnEndRequest(object sender, EventArgs args) {
            HttpContext.Current.Items["NhibernateCurrentSession"] = "";
            ManagedWebSessionContext.Unbind(HttpContext.Current, SessionFactory);
        }

        private static ISessionFactory BuildSessionFactory() {
            return new NHibernateHelper(ConfigurationManager.ConnectionStrings[Environment.MachineName].ConnectionString).SessionFactory;
        }
       
    }
}