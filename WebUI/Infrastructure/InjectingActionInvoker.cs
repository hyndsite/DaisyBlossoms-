using System.Web.Mvc;
using StructureMap;
using System.Linq;

namespace WebUI.Infrastructure {
    public class InjectingActionInvoker : ControllerActionInvoker {
        private readonly IContainer _container;

        public InjectingActionInvoker(IContainer container) {
            _container = container;
        }

        protected override FilterInfo GetFilters(ControllerContext controllerContext, ActionDescriptor actionDescriptor) {
            var filterInfo = base.GetFilters(controllerContext, actionDescriptor);

            filterInfo.ActionFilters.ForEach(_container.BuildUp);


            return filterInfo;
        }
    }
}