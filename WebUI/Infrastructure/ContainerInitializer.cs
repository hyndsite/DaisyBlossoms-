using System;
using System.Configuration;
using DTOS;
using NHibernate;
using NHibernateLayer;
using RepoInfrastructure;
using StructureMap;

namespace WebUI.Infrastructure {
    public class ContainerInitializer {
        public IContainer Intialize() {
            var helper = new NHibernateHelper(ConfigurationManager.ConnectionStrings[Environment.MachineName].ConnectionString);
            ObjectFactory.Initialize(x => {
                                         x.For<ISessionFactory>()
                                             .Singleton()
                                             .Use(helper.SessionFactory);

                                         x.For<IUnitOfWork>()
                                             .HttpContextScoped()
                                             .Use(context => new UnitOfWork(context.GetInstance<ISessionFactory>()));

                                         x.For<ISession>()
                                             .HttpContextScoped()
                                             .Use(context => context.GetInstance<IUnitOfWork>().Session);

                                         x.For<IRepository<Product>>()
                                             .Use<Repository<Product>>();

                                         x.For<IRepository<Category>>()
                                             .Use<Repository<Category>>();

                                     });

            return ObjectFactory.Container;
        }
    }
}