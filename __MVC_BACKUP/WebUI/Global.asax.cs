using System.Web.Mvc;
using System.Web.Routing;
using WebUI.Infrastructure;

namespace WebUI
{
	// Note: For instructions on enabling IIS6 or IIS7 classic mode, 
	// visit http://go.microsoft.com/?LinkId=9394801

	public class MvcApplication : System.Web.HttpApplication
	{
		public static void RegisterRoutes(RouteCollection routes)
		{
			routes.IgnoreRoute("{resource}.axd/{*pathInfo}");

			routes.MapRoute(
				"", // Route name
				"{controller}/{action}/{id}", // URL with parameters
				new { controller = "Admin", action = "List", id = UrlParameter.Optional } // Parameter defaults
			);

			routes.MapRoute(
				"Default", // Route name
				"{controller}/{action}/{id}", // URL with parameters
				new { controller = "Home", action = "Index", id = UrlParameter.Optional } // Parameter defaults
			);

		}

		protected void Application_Start()
		{
			AreaRegistration.RegisterAllAreas();

			RegisterRoutes(RouteTable.Routes);
			ControllerBuilder.Current.SetControllerFactory(new NinjectControllerFactory());
		}
	}
}