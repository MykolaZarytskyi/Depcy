using Dependency.Models;
using Dependency.Repositories;
using System.Collections.Generic;
using System.Threading.Tasks;
using System.Web.Mvc;

namespace Dependency.Controllers
{
    public class Dep1Controller : Controller
    {

        public IUnitOfWork _rep = null;

        public Dep1Controller(IUnitOfWork rep)
        {
            _rep = rep;
        }

        public ActionResult Index()
        {
            Task<List<Author>> list = _rep.Authors.GetAll();

            return View(list);
        }
    }
}