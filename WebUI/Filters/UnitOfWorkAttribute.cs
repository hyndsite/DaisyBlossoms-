using System;
using System.Web.Mvc;
using NHibernate;
using RepoInfrastructure;
using StructureMap;


namespace WebUI.Filters {
    [AttributeUsage(AttributeTargets.Method, AllowMultiple = true)]
    public class UnitOfWorkAttribute : ActionFilterAttribute {

        public ISession Session {
            get { return MvcApplication.Session; }
        }

        public override void OnActionExecuting(ActionExecutingContext filterContext) {
            Session.BeginTransaction();
        }

        public override void  OnResultExecuted(ResultExecutedContext filterContext) {
            var transaction = Session.Transaction;

            if (transaction == null || !transaction.IsActive) return;
            
            var thereWereNoExceptions = filterContext.Exception == null || filterContext.ExceptionHandled;

            if (filterContext.Controller.ViewData.ModelState.IsValid && thereWereNoExceptions) {
                Commit();
            } else {
                Rollback();
            }
        }
        
        public void Commit() {
            Session.Transaction.Commit();
        }

        public void Rollback() {
            Session.Transaction.Rollback();
        }

        public void Dispose() {
            Session.Close();
        }
    }
}