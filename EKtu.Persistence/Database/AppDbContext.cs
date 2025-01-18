using EKtu.Domain.Entity;
using Microsoft.EntityFrameworkCore;

namespace EKtu.Persistence.Database
{
    public class AppDbContext : DbContext
    {
        public AppDbContext(DbContextOptions<AppDbContext> dbContextOptions) : base(dbContextOptions) { }
        public DbSet<Course> Course { get; set; }
        public DbSet<Department> Department { get; set; }

        public DbSet<Instructor> Instructor { get; set; }

        public DbSet<InstructorCourse> InstructorCourse { get; set; }

        public DbSet<InstructorDepartment> InstructorDepartment { get; set; }
        public DbSet<Student> Student { get; set; }

        public DbSet<StudentChooseCourse> StudentChooseCourse { get; set; }

        public DbSet<Title> Title { get; set; }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<Course>()
                .HasMany(y => y.InstructorCourses)
                .WithOne(y => y.Course)
                .HasForeignKey(y => y.CourseId);

            modelBuilder.Entity<Course>()
                .HasMany(y => y.StudentChooseCourses)
                .WithOne(y => y.Course)
                .HasForeignKey(y => y.CourseId);

            modelBuilder.Entity<Course>()
                .HasOne(y => y.Department)
                .WithMany(y => y.Courses)
                .HasForeignKey(y => y.DepartmentId);

            modelBuilder.Entity<Department>()
                .HasMany(y => y.InstructorDepartments)
                .WithOne(y => y.Deparment)
                .HasForeignKey(y => y.DepartmentId);

            modelBuilder.Entity<Instructor>()
                .HasOne(y => y.Title)
                .WithMany(y => y.Instructors)
                .HasForeignKey(y => y.TitleId);

            modelBuilder.Entity<Student>()
                .HasOne(y => y.Instructor)
                .WithMany(y => y.Student)
                .HasForeignKey(y => y.InstructorId);

            modelBuilder.Entity<Student>()

                .HasMany(y => y.StudentChooseCourses)
                .WithOne(y => y.Student)
                .HasForeignKey(y => y.StudentId);

            base.OnModelCreating(modelBuilder);
        }



    }
}
