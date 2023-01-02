using System.Data.Entity;
using Microsoft.AspNet.Identity.EntityFramework;

namespace TuitionClassProject.Models
{
    public class ApplicationDbContext : IdentityDbContext<ApplicationUser>
    {
        public DbSet<Course> Courses { get; set; }
        public DbSet<Instructor> Instructors { get; set; }
        public DbSet<Student> Students { get; set; }
        

        public ApplicationDbContext()
            : base("DefaultConnection", throwIfV1Schema: false)
        {
        }

        public static ApplicationDbContext Create()
        {
            return new ApplicationDbContext();
        }

        protected override void OnModelCreating(DbModelBuilder modelBuilder)
        {
            modelBuilder.Entity<CourseStudents>()
                .HasKey(cs => new
                {
                    cs.CourseId, cs.StudentId
                });

            modelBuilder.Entity<CourseStudents>()
                .HasRequired(cs => cs.Course)
                .WithMany()
                .WillCascadeOnDelete(true);

            modelBuilder.Entity<CourseStudents>()
                .HasRequired(cs => cs.Student)
                .WithMany()
                .WillCascadeOnDelete(false);

            modelBuilder.Entity<InstructorStudents>()
                .HasKey(i => new
                {
                    i.InstructorId, i.StudentId
                });

            modelBuilder.Entity<InstructorStudents>()
                .HasRequired(i => i.Instructor)
                .WithMany()
                .WillCascadeOnDelete(true);

            modelBuilder.Entity<InstructorStudents>()
                .HasRequired(i => i.Student)
                .WithMany()
                .WillCascadeOnDelete(false);

            modelBuilder.Entity<Course>()
                .HasRequired(c => c.Instructor)
                .WithRequiredPrincipal(i => i.Course);

            base.OnModelCreating(modelBuilder);
        }
    }
}