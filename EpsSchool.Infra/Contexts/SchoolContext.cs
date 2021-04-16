using EpsSchool.Domain.Entities;
using EpsSchool.Domain.Helpers;
using Microsoft.EntityFrameworkCore;

namespace EpsSchool.Infra.Contexts
{
    public class SchoolContext : DbContext
    {
        public SchoolContext(DbContextOptions<SchoolContext> options) : base(options) { }
        public DbSet<User> Users { get; set; }
        public DbSet<Student> Students { get; set; }
        public DbSet<Teacher> Teachers { get; set; }
        public DbSet<Course> Courses { get; set; }
        public DbSet<Subject> Subjects { get; set; }
        public DbSet<CourseSubject> CoursesSubjects { get; set; }
        public DbSet<StudentCourseSubject> StudentsCoursesSubjects { get; set; }

        protected override void OnModelCreating(ModelBuilder builder)
        {
            builder.Entity<StudentCourseSubject>()
                .HasKey(scs => new { scs.StudentId, scs.CourseSubjectId });

            builder.Entity<Teacher>()
                .HasData(ListsManager.LoadTeachersSampleData());

            builder.Entity<Course>()
                .HasData(ListsManager.LoadCoursesSampleData());

            builder.Entity<Subject>()
                .HasData(ListsManager.LoadSubjectsSampleData());

            builder.Entity<Student>()
                .HasData(ListsManager.LoadStudentsSampleData());

            builder.Entity<CourseSubject>()
                .HasData(ListsManager.LoadCoursesSubjectsSampleData());

            builder.Entity<StudentCourseSubject>()
                .HasData(ListsManager.LoadStudentCoursesSubjectsSampleData());
        }

    }
}