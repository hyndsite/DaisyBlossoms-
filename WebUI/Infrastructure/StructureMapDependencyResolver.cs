using System;
using System.Collections.Generic;
using System.Web.Mvc;
using StructureMap;
using System.Linq;

namespace WebUI.Infrastructure {
    public class StructureMapDependencyResolver : IDependencyResolver {
        private IContainer _container;

        public StructureMapDependencyResolver(IContainer container) {
            _container = container;
        }
        public object GetService(Type serviceType) {
            if (serviceType.IsAbstract || serviceType.IsInterface) {
                return _container.TryGetInstance(serviceType);
            } else {
                return _container.GetInstance(serviceType);
            }
        }

        public IEnumerable<object> GetServices(Type serviceType) {
            return _container.GetAllInstances<object>()
                .Where(x => x.GetType() == serviceType);
        }
    }
}