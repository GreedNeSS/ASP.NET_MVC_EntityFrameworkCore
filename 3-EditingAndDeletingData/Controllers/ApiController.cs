using Microsoft.AspNetCore.Mvc;
using _3_EditingAndDeletingData.Models;

namespace _3_EditingAndDeletingData.Controllers
{
    public class ApiController : Controller
    {
        ApplicationContext db;

        public ApiController(ApplicationContext context)
        {
            db = context;
        }

        public async Task<IActionResult> Create(User user)
        {
            user.Id = Guid.NewGuid();
            db.Users.Add(user);
            await db.SaveChangesAsync();
            return Redirect("/");
        }
        public async Task<IActionResult> Edit(User user)
        {
            db.Users.Update(user);
            await db.SaveChangesAsync();
            return Redirect("/");
        }
        public async Task<IActionResult> Delete(string id)
        {
            User user = new User { Id = Guid.Parse(id) };
            db.Entry(user).State = Microsoft.EntityFrameworkCore.EntityState.Deleted;
            await db.SaveChangesAsync();
            return Redirect("/");
        }
    }
}
