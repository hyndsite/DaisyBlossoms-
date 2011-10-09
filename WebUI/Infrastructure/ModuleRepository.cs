using System;
using DTOS;
using Ninject.Modules;
using System.Configuration;
using NHibernateLayer;
using NHibernate;
using RepoInfrastructure;

namespace WebUI.Infrastructure
{
	public class ModuleRepository : NinjectModule
	{
		public override void Load()
		{
			var helper = new NHibernateHelper(ConfigurationManager.ConnectionStrings[Environment.MachineName].ConnectionString);

			Bind<ISessionFactory>().ToConstant(helper.SessionFactory)
				.InSingletonScope();

			Bind<IUnitOfWork>().To<UnitOfWork>()
				.InRequestScope();
			Bind<ISession>().ToProvider<SessionProvider>()
				.InRequestScope();
			Bind<IRepository<Product>>().To<Repository<Product>>();
			Bind<IRepository<Category>>().To<Repository<Category>>();
		}
	}
}