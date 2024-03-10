using Core.Entity;
using Microsoft.EntityFrameworkCore;

namespace Infrastructure
{
    public class ApplicationContext : DbContext
    {
        public DbSet<UserEntity> Users { get; set; }
        public DbSet<LessonEntity> Lessons { get; set; }
        public DbSet<NewsEntity> News { get; set; }
        public DbSet<MailEntity> Mails { get; set; }
        public DbSet<RibbonsEntity> Ribbons { get; set; }
        public DbSet<PicturesEntity> Pictures { get; set; }
        public DbSet<CommentsEntity> Comments { get; set; }


        public ApplicationContext(DbContextOptions<ApplicationContext> option) : base(option) { }

        protected override void OnModelCreating(ModelBuilder builder)
        {
            builder.Entity<UserEntity>(entity =>
            {
                entity.HasIndex(e => e.Phone).IsUnique();
            });
        }
    }
}
