using Microsoft.EntityFrameworkCore;

namespace _7_Pagination.Models
{
    public class UsersContext : DbContext
    {
        public DbSet<User> Users { get; set; } = null!;
        public DbSet<Company> Companies{ get; set; } = null!;

        public UsersContext(DbContextOptions<UsersContext> context) : base(context)
        {
            Database.EnsureCreated();
        }
    }
}
