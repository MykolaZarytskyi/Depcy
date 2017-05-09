using Dependency.Models;
using Dependency.Repositories;
using System;
using System.Web.Mvc;
using System.Web.Routing;

namespace Dependency.ControllerFactory
{
    public class DependencyControllerFactory : DefaultControllerFactory
    {
        public override IController CreateController(RequestContext requestContext, string controllerName)
        {
            ModelFirstDBContext mfc = new ModelFirstDBContext();
            UnitOfWork uw = new UnitOfWork(mfc);

            //if(controllerName == "Home")
            //{
            //    Dependency.Controllers.Dep1Controller cont = new Controllers.Dep1Controller(uw);
            //    return cont;
            //}
            //else
            //{
            //    return base.CreateController(requestContext, controllerName);
            //}

            // 1 way
            //Dependency.Controllers.Dep1Controller cont = new Controllers.Dep1Controller(uw);
            //return cont;

            // 2 way
            Type typeCont = Type.GetType("Dependency.Controllers." + controllerName);
            IController cont = Activator.CreateInstance(typeCont, new []{ uw })  as IController;
            return cont;
        }
    }
}