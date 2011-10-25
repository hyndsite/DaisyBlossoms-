// Type: System.Web.Mvc.FilterAttribute
// Assembly: System.Web.Mvc, Version=3.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35
// Assembly location: c:\Program Files\Microsoft ASP.NET\ASP.NET MVC 3\Assemblies\System.Web.Mvc.dll

using System;

namespace System.Web.Mvc {
    [AttributeUsage(AttributeTargets.Class | AttributeTargets.Method, AllowMultiple = false, Inherited = true)]
    public abstract class FilterAttribute : Attribute, IMvcFilter {
        protected FilterAttribute();

        #region IMvcFilter Members

        public bool AllowMultiple { get; }
        public int Order { get; set; }

        #endregion
    }
}
