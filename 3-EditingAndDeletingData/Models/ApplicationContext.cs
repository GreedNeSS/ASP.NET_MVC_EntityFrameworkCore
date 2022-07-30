using Microsoft.EntityFrameworkCore;

namespace _3_EditingAndDeletingData.Models
{
    public class ApplicationContext : DbContext
    {
        public DbSet<User> Users { get; set; } = null!;

        public ApplicationContext(DbContextOptions<ApplicationContext> context) : base(context)
        {
            Database.EnsureCreated();
        }
    }
}
