// Type: System.Web.Mvc.FilterAttributeFilterProvider
// Assembly: System.Web.Mvc, Version=3.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35
// Assembly location: c:\Program Files\Microsoft ASP.NET\ASP.NET MVC 3\Assemblies\System.Web.Mvc.dll

using System.Collections.Generic;

namespace System.Web.Mvc {
    public class FilterAttributeFilterProvider : IFilterProvider {
        public FilterAttributeFilterProvider();
        public FilterAttributeFilterProvider(bool cacheAttributeInstances);

        #region IFilterProvider Members

        public virtual IEnumerable<Filter> GetFilters(ControllerContext controllerContext,
                                                      ActionDescriptor actionDescriptor);

        #endregion

        protected virtual IEnumerable<FilterAttribute> GetActionAttributes(ControllerContext controllerContext,
                                                                           ActionDescriptor actionDescriptor);

        protected virtual IEnumerable<FilterAttribute> GetControllerAttributes(ControllerContext controllerContext,
                                                                               ActionDescriptor actionDescriptor);
    }
}
