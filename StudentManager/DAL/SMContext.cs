using StudentManager.Models;
using System.Data.Entity;
using System.Data.Entity.ModelConfiguration.Conventions;


namespace StudentManager.DAL
{
	public class SMContext : DbContext
	{
        public SMContext() : base("SMContext")
        {
            this.Configuration.LazyLoadingEnabled = false;
        }

        public DbSet<Student> Students { get; set; }
        public DbSet<Course> Courses { get; set; }
        public DbSet<Group> Groups { get; set; }
        public DbSet<Lesson> Lessons { get; set; }
        public DbSet<LessonLocation> LessonLocations { get; set; }
        public DbSet<Attendancy> Attendancies { get; set; }

        protected override void OnModelCreating(DbModelBuilder modelBuilder)
        {
            modelBuilder.Conventions.Remove<PluralizingTableNameConvention>();

            modelBuilder.Entity<Group>()
             .HasMany(g => g.Students).WithMany(s => s.Groups)
             .Map(t => t.MapLeftKey("GroupID")
                 .MapRightKey("StudentID")
                 .ToTable("GroupStudent"));

            modelBuilder.Entity<Lesson>()
                .HasOptional(s => s.LessonLocation).WithOptionalDependent(l => l.Lesson);

            modelBuilder.Entity<Attendancy>()
                 .HasMany(a => a.Groups).WithMany(g => g.Attendancies)
                 .Map(t => t.MapLeftKey("GroupID")
                 .MapRightKey("AttendancyID")
                 .ToTable("GroupAttendancy"));
        }

    }
}