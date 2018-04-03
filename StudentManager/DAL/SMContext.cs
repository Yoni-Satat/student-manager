using StudentManager.Models;
using System.Data.Entity;
using System.Data.Entity.ModelConfiguration.Conventions;


namespace StudentManager.DAL
{
	public class SMContext : DbContext
	{
        public SMContext() : base("SMContext")
        {
        }

        public DbSet<Student> Students { get; set; }
        public DbSet<Course> Courses { get; set; }
        public DbSet<Group> Groups { get; set; }        

        protected override void OnModelCreating(DbModelBuilder modelBuilder)
        {
            modelBuilder.Conventions.Remove<PluralizingTableNameConvention>();

            modelBuilder.Entity<Group>()
             .HasMany(g => g.Students).WithMany(s => s.Groups)
             .Map(t => t.MapLeftKey("GroupID")
                 .MapRightKey("StudentID")
                 .ToTable("GroupStudent"));
        }
    }
}