using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Microsoft.AspNetCore.Mvc.Rendering;
using _6_DataFiltering.Models;

namespace _6_DataFiltering.Controllers
{
    public class HomeController : Controller
    {
        UsersContext db;

        public HomeController(UsersContext context)
        {
            db = context;

            if (!db.Companies.Any())
            {
                Company oracle = new Company { Name = "Oracle" };
                Company google = new Company { Name = "Google" };
                Company microsoft = new Company { Name = "Microsoft" };
                Company apple = new Company { Name = "Apple" };

                User user1 = new User { Name = "Олег Васильев", Company = oracle, Age = 26 };
                User user2 = new User { Name = "Александр Овсов", Company = oracle, Age = 24 };
                User user3 = new User { Name = "Алексей Петров", Company = microsoft, Age = 25 };
                User user4 = new User { Name = "Иван Иванов", Company = microsoft, Age = 26 };
                User user5 = new User { Name = "Петр Андреев", Company = microsoft, Age = 23 };
                User user6 = new User { Name = "Василий Иванов", Company = google, Age = 23 };
                User user7 = new User { Name = "Олег Кузнецов", Company = google, Age = 25 };
                User user8 = new User { Name = "Андрей Петров", Company = apple, Age = 24 };

                db.Companies.AddRange(oracle, microsoft, google, apple);
                db.Users.AddRange(user1, user2, user3, user4, user5, user6, user7, user8);
                db.SaveChanges();
            }
        }

        public async Task<IActionResult> Index(int? company, string? name)
        {
            IQueryable<User> users = db.Users.Include(u => u.Company);

            if (company != null && company != 0)
            {
                users = users.Where(u => u.CompanyId == company);
            }

            if (!string.IsNullOrEmpty(name))
            {
                users = users.Where(u => u.Name!.Contains(name) );
            }

            List<Company> companies = await db.Companies.ToListAsync();
            companies.Insert(0, new Company { Id = 0, Name = "Все" });

            UserListViewModel viewModel = new UserListViewModel
            {
                Users = await users.ToListAsync(),
                Companies = new SelectList(companies, "Id", "Name", company),
                Name = name
            };

            Console.WriteLine(viewModel.Users);

            return View(viewModel);
        }
    }
}
