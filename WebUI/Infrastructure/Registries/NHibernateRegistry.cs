using System;
using System.Configuration;
using NHibernate;
using NHibernateLayer;
using RepoInfrastructure;
using StructureMap;
using StructureMap.Configuration.DSL;
using WebUI.Controllers;
using WebUI.Filters;

namespace WebUI.Infrastructure.Registries {
    public class NHibernateRegistry : Registry {
        private static ISessionFactory _sessionFactory;
        public NHibernateRegistry() {
            var helper = new NHibernateHelper(ConfigurationManager.ConnectionStrings[Environment.MachineName].ConnectionString);

            For<ISessionFactory>()
                .Singleton()
                .Use(helper.SessionFactory);

            For<ISession>()
                .HybridHttpOrThreadLocalScoped()
                .Use(context => MvcApplication.SessionFactory.GetCurrentSession());
        }
    }
}