using _3_EditingAndDeletingData.Models;
using Microsoft.AspNetCore.Mvc;

namespace _3_EditingAndDeletingData.Controllers
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
            List<User> users = db.Users.ToList();
            return View(users);
        }

        public IActionResult Create()
        {
            return View();
        }

        public IActionResult Edit(string? id)
        {
            if (!string.IsNullOrEmpty(id))
            {
                User? user = db.Users.FirstOrDefault(u => u.Id == Guid.Parse(id));
                
                if (user != null)
                {
                    return View(user);
                }
            }

            return NotFound(new { message = "Пользователя не существует!" });
        }
    }
}
