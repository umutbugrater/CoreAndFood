using Microsoft.EntityFrameworkCore;

namespace CoreAndFood.Entities
{
    public class Context : DbContext
    {
        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            optionsBuilder.UseSqlServer("server=DESKTOP-JCPO54A\\SQLEXPRESS; database=DbCoreFood; integrated security=true;TrustServerCertificate=True");

        }
        public DbSet<Food> Foods { get; set; }
        public DbSet<Category> Categories { get; set; }
        public DbSet<Admin> Admins { get; set; }
    }
}
