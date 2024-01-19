using Core.Entity;
using Microsoft.EntityFrameworkCore;
using System.Reflection.Metadata;

namespace Infrastructure
{
    public class ApplicationContext : DbContext
    {
        public DbSet<UserEntity> Users { get; set; }
        public DbSet<LessonEntity> Lessons { get; set; }
        public DbSet<NewsEntity> News { get; set; }
        public DbSet<MailEntity> Mails { get; set; }

        public ApplicationContext(DbContextOptions<ApplicationContext> option) : base(option) { }

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
            => optionsBuilder.UseNpgsql("Host=45.8.96.144;Database=MiracleAppDB;Username=mira31;Password=c(gY4EtjBXIOsL");

        protected override void OnModelCreating(ModelBuilder builder)
        {
            builder.Entity<MailEntity>(entity => {
                entity.HasIndex(e => e.Email).IsUnique();
            });

            builder.Entity<UserEntity>(entity =>
            {
                entity.HasIndex(e => e.Phone).IsUnique();
            });
        }
    }
}
