using Microsoft.EntityFrameworkCore;
using MiracleDesktopApp.Infrastructure.Models;

namespace MiracleDesktopApp.Infrastructure
{
    public class ApplicationContext : DbContext
    {
        public DbSet<UserModel> Users { get; set; } = null!;
        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            optionsBuilder.UseSqlite("Data Source=miracleapp.db");
        }
    }
}
