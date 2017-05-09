using Dependency.Models;
using Dependency.Repositories;
using System.Collections.Generic;
using System.Threading.Tasks;
using System.Web.Mvc;

namespace Dependency.Controllers
{
    public class Dep2Controller : Controller
    {
        public IUnitOfWork _rep = null;

        public Dep2Controller(IUnitOfWork rep)
        {
            _rep = rep;
        }

        public ActionResult Index()
        {
            Task<List<Book>> list = _rep.Books.GetAll(); 

            return View(list);
        }
    }
}