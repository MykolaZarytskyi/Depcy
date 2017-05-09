using Dependency.Models;
using Dependency.Repositories;
using System;
using System.Web.Mvc;
using System.Web.Routing;
using System.Web.SessionState;

namespace Dependency.ControllerFactory
{
    public class MyControllerFactory : IControllerFactory
    {
        public IController CreateController(RequestContext requestContext, string controllerName)
        {
            ModelFirstDBContext mfc = new ModelFirstDBContext();
            UnitOfWork uw = new UnitOfWork(mfc);

            Controllers.Dep1Controller cont = new Controllers.Dep1Controller(uw);
            return cont;
        }

        public SessionStateBehavior GetControllerSessionBehavior(RequestContext requestContext, string controllerName)
        {
            return SessionStateBehavior.Default;
        }

        public void ReleaseController(IController controller)
        {
            IDisposable disposable = controller as IDisposable;
            if (disposable != null)
                disposable.Dispose();
        }
    }
}