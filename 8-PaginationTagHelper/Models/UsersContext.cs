using Microsoft.EntityFrameworkCore;

namespace _8_PaginationTagHelper.Models
{
    public class UsersContext : DbContext
    {
        public DbSet<User> Users { get; set; } = null!;
        public DbSet<Company> Companies { get; set; } = null!;

        public UsersContext(DbContextOptions<UsersContext> context) : base(context)
        {
            Database.EnsureCreated();
        }
    }
}
