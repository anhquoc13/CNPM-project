using System.Reflection;
using Domain.Entities;
using Microsoft.EntityFrameworkCore;

namespace Infrastructure.Persistence
{
    public class FlashCardContext : DbContext
    {
        public FlashCardContext(DbContextOptions<FlashCardContext> options) : base(options)
        {
        }
        protected override void OnModelCreating(ModelBuilder builder)
        {
            base.OnModelCreating(builder);
            builder.ApplyConfigurationsFromAssembly(Assembly.GetExecutingAssembly());
        }

        public DbSet<User> User { get; set; }
        public DbSet<Class> Class { get; set; }
        public DbSet<Course> Course { get; set; }
        public DbSet<DetailFolder> DetailFolder { get; set; }
        public DbSet<Folder> Folder { get; set; }
        public DbSet<GroupFolder> GroupFolder { get; set; }
        public DbSet<listVocabulary> listVocabulary { get; set; }
        public DbSet<MemberOF> MemberOF { get; set; }
        public DbSet<TestOFCourse> TestOFCourse { get; set; }
        public DbSet<TestOfFolder> TestOfFolder { get; set; }
        public DbSet<Vocabulary> Vocabulary { get; set; }
    }
}