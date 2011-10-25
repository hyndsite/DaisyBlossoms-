using System.Web.Mvc;
using System.Web.Routing;
using NHibernate;
using RepoInfrastructure;
using StructureMap.Configuration.DSL;
using WebUI.Filters;

namespace WebUI.Infrastructure.Registries {
    public class FilterRegistry : Registry {
        public FilterRegistry() {
            For<IActionInvoker>().Use<InjectingActionInvoker>();

            SetAllProperties(x => {
                                 x.OfType<IActionInvoker>();
                                 x.OfType<InjectingActionInvoker>();
                                 x.WithAnyTypeFromNamespaceContainingType<UnitOfWorkAttribute>();
                             });
        }
    }
}