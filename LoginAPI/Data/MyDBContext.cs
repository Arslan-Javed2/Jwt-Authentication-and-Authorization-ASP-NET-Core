using LoginAPI.Models;
using Microsoft.EntityFrameworkCore;

namespace LoginAPI.Data
{
    public class MyDBContext : DbContext
    {
        public MyDBContext(DbContextOptions<MyDBContext> options) : base(options)
        {
            
        }

        public DbSet<Students> Students { get; set; }
        public DbSet<Users> Users { get; set; }
        public DbSet<Category> Category { get; set; }
    }
}
