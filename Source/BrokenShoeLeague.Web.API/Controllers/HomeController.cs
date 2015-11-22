using System.Web.Mvc;

namespace BrokenShoeLeague.Web.API.Controllers
{
    public class HomeController : Controller
    {
        public ActionResult Index()
        {
            return View();
        }
    }
}
