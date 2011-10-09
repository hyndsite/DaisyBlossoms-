using System;
using System.Configuration;
using System.Web.Mvc;
using DTOS;
using NHibernate;
using NHibernateLayer;
using Ninject;
using Ninject.Modules;
using RepoInfrastructure;

namespace WebUI.Infrastructure
{
	public class NinjectControllerFactory : DefaultControllerFactory
	{
		private IKernel _kernel =  new StandardKernel(new ModuleRepository());

		protected override IController GetControllerInstance(System.Web.Routing.RequestContext requestContext, Type controllerType)
		{
			if (controllerType == null)
				return null;
			return (IController)_kernel.Get(controllerType);
		}

	}	
}