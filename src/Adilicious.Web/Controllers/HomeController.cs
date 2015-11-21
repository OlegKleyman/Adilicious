namespace Adilicious.Web.Controllers
{
    using System.Web.Mvc;

    public class HomeController : Controller
    {
        public ViewResult Index()
        {
            return View("index");
        }
    }
}