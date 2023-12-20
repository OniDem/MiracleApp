using Core.Entity;
using Microsoft.EntityFrameworkCore;

namespace Infrastructure
{
    public class ApplicationContext : DbContext
    {
        public DbSet<UserEntity> Users { get; set; }
        public DbSet<LessonEntity> Lessons { get; set; }

        public DbSet<NewsEntity> News { get; set; }

        public ApplicationContext(DbContextOptions<ApplicationContext> option) : base(option) { }

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
            => optionsBuilder.UseNpgsql("Host=45.8.96.144;Database=MiracleAppDB;Username=mira31;Password=c(gY4EtjBXIOsL");
    }
}
