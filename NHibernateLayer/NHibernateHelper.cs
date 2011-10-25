using FluentNHibernate.Cfg.Db;
using FluentNHibernate.Conventions.Helpers;
using NHibernate;
using FluentNHibernate.Cfg;
using System.Reflection;
using HibernatingRhinos.Profiler.Appender.NHibernate;
using NHibernate.Cfg;
using NHibernate.Context;

namespace NHibernateLayer
{
    public class NHibernateHelper {
        private readonly string _connectionString;
        private ISessionFactory _sessionFactory;

        public NHibernateHelper(string connectionString) {
            _connectionString = connectionString;
        }

        public ISessionFactory SessionFactory {
            get { return _sessionFactory ?? (_sessionFactory = CreateSessionFactory()); }
        }

        private ISessionFactory CreateSessionFactory() {
            NHibernateProfiler.Initialize();

            return Fluently.Configure()
                           .Database(MySQLConfiguration.Standard.ConnectionString(_connectionString))
                           .Mappings(m => m.FluentMappings.AddFromAssembly(Assembly.GetExecutingAssembly())
                               .Conventions.Add(ForeignKey.EndsWith("id")))
                            .ExposeConfiguration(config => config.SetProperty(Environment.CurrentSessionContextClass,
                                typeof(ManagedWebSessionContext).AssemblyQualifiedName))
                           .BuildSessionFactory();
        }
    }
}
