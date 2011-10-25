// Type: System.Web.Mvc.ActionFilterAttribute
// Assembly: System.Web.Mvc, Version=3.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35
// Assembly location: c:\Program Files\Microsoft ASP.NET\ASP.NET MVC 3\Assemblies\System.Web.Mvc.dll

using System;

namespace System.Web.Mvc {
    [AttributeUsage(AttributeTargets.Class | AttributeTargets.Method, AllowMultiple = false, Inherited = true)]
    public abstract class ActionFilterAttribute : FilterAttribute, IActionFilter, IResultFilter {
        #region IActionFilter Members

        public virtual void OnActionExecuting(ActionExecutingContext filterContext);
        public virtual void OnActionExecuted(ActionExecutedContext filterContext);

        #endregion

        #region IResultFilter Members

        public virtual void OnResultExecuting(ResultExecutingContext filterContext);
        public virtual void OnResultExecuted(ResultExecutedContext filterContext);

        #endregion
    }
}
