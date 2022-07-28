using _1_Connection.Models;
using Microsoft.AspNetCore.Mvc;

namespace _1_Connection.Controllers
{
    public class HomeController : Controller
    {
        ApplicationContext db;

        public HomeController(ApplicationContext context)
        {
            db = context;
        }

        public IActionResult Index()
        {
            return Content("Created DB");
        }
    }
}
