using Microsoft.AspNetCore.Mvc;

namespace ClientApplicationTest1.Controllers
{
    public class HomeController : Controller
    {
        public IActionResult Index()
        {
            return View();
        }
    }
}
