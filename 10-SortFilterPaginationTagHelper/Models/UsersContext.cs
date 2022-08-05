using Microsoft.EntityFrameworkCore;

namespace _10_SortFilterPaginationTagHelper.Models
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
