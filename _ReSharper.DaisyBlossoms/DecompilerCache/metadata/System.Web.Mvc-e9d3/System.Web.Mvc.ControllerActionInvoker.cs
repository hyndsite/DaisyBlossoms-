// Type: System.Web.Mvc.ControllerActionInvoker
// Assembly: System.Web.Mvc, Version=3.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35
// Assembly location: c:\Program Files\Microsoft ASP.NET\ASP.NET MVC 3\Assemblies\System.Web.Mvc.dll

using System;
using System.Collections.Generic;

namespace System.Web.Mvc {
    public class ControllerActionInvoker : IActionInvoker {
        public ControllerActionInvoker();
        protected internal ModelBinderDictionary Binders { get; set; }

        #region IActionInvoker Members

        public virtual bool InvokeAction(ControllerContext controllerContext, string actionName);

        #endregion

        protected virtual ActionResult CreateActionResult(ControllerContext controllerContext,
                                                          ActionDescriptor actionDescriptor, object actionReturnValue);

        protected virtual ControllerDescriptor GetControllerDescriptor(ControllerContext controllerContext);

        protected virtual ActionDescriptor FindAction(ControllerContext controllerContext,
                                                      ControllerDescriptor controllerDescriptor, string actionName);

        protected virtual FilterInfo GetFilters(ControllerContext controllerContext, ActionDescriptor actionDescriptor);

        protected virtual object GetParameterValue(ControllerContext controllerContext,
                                                   ParameterDescriptor parameterDescriptor);

        protected virtual IDictionary<string, object> GetParameterValues(ControllerContext controllerContext,
                                                                         ActionDescriptor actionDescriptor);

        protected virtual ActionResult InvokeActionMethod(ControllerContext controllerContext,
                                                          ActionDescriptor actionDescriptor,
                                                          IDictionary<string, object> parameters);

        protected virtual ActionExecutedContext InvokeActionMethodWithFilters(ControllerContext controllerContext,
                                                                              IList<IActionFilter> filters,
                                                                              ActionDescriptor actionDescriptor,
                                                                              IDictionary<string, object> parameters);

        protected virtual void InvokeActionResult(ControllerContext controllerContext, ActionResult actionResult);

        protected virtual ResultExecutedContext InvokeActionResultWithFilters(ControllerContext controllerContext,
                                                                              IList<IResultFilter> filters,
                                                                              ActionResult actionResult);

        protected virtual AuthorizationContext InvokeAuthorizationFilters(ControllerContext controllerContext,
                                                                          IList<IAuthorizationFilter> filters,
                                                                          ActionDescriptor actionDescriptor);

        protected virtual ExceptionContext InvokeExceptionFilters(ControllerContext controllerContext,
                                                                  IList<IExceptionFilter> filters, Exception exception);
    }
}
