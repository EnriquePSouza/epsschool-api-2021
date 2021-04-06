using System;
using System.Collections.Generic;
using EpsSchool.Domain.Entities;
using Microsoft.EntityFrameworkCore;

namespace EpsSchool.infra.Contexts
{
    public class SchoolContext : DbContext
    {
        private readonly DateTime _birthdate = DateTime.Parse("07/17/2005", new System.Globalization.CultureInfo("en-US"));
        public SchoolContext(DbContextOptions<SchoolContext> options) : base(options) { }
        public DbSet<Student> Students { get; set; }
        public DbSet<Teacher> Teachers { get; set; }
        public DbSet<Course> Courses { get; set; }
        public DbSet<Subject> Subjects { get; set; }
        public DbSet<CourseSubject> CoursesSubjects { get; set; }
        public DbSet<StudentCourseSubject> StudentsCoursesSubjects { get; set; }

        protected override void OnModelCreating(ModelBuilder builder)
        {
            #region Students
            Student student1 = new Student("Joana", "Alves", "33556699", _birthdate);
            Student student2 = new Student("Fernanda", "Silva", "33447789", _birthdate);
            Student student3 = new Student("Vanessa", "Lisboa", "99562341", _birthdate);
            Student student4 = new Student("Maria", "Madalena", "99452417", _birthdate);
            Student student5 = new Student("João", "Paulo", "98564712", _birthdate);
            Student student6 = new Student("Ananias", "Fernandes", "33589624", _birthdate);
            Student student7 = new Student("José", "Arimatéia", "98745122", _birthdate);
            Student student8 = new Student("Carlos", "Gaiado", "44558896", _birthdate);
            Student student9 = new Student("Diogenes", "Finético", "22665588", _birthdate);
            #endregion
            #region Teachers
            Teacher teacher1 = new Teacher("José", "Roberto", "44778899");
            Teacher teacher2 = new Teacher("Carlos", "Eduardo", "33568941");
            Teacher teacher3 = new Teacher("Manuel", "Nobre", "99587462");
            Teacher teacher4 = new Teacher("João", "Olavo", "33506987");
            Teacher teacher5 = new Teacher("Lucas", "Ribas", "33214896");
            #endregion
            #region Courses
            Course course1 = new Course("Informatica");
            Course course2 = new Course("Manutenção de Micros");
            Course course3 = new Course("Redes de Computadores");
            #endregion
            #region Subjects
            Subject subject1 = new Subject("Matemática", teacher1.Id);
            Subject subject2 = new Subject("Limpeza de Gabinete", teacher2.Id);
            Subject subject3 = new Subject("Português", teacher3.Id);
            Subject subject4 = new Subject("Arquitetura de Servidores", teacher4.Id);
            Subject subject5 = new Subject("Programação", teacher5.Id);
            #endregion
            #region CoursesSubjects
            CourseSubject courseSubject1 = new CourseSubject(course1.Id, subject1.Id);
            CourseSubject courseSubject2 = new CourseSubject(course1.Id, subject3.Id);
            CourseSubject courseSubject3 = new CourseSubject(course1.Id, subject5.Id);
            CourseSubject courseSubject4 = new CourseSubject(course2.Id, subject2.Id);
            CourseSubject courseSubject5 = new CourseSubject(course2.Id, subject3.Id);
            CourseSubject courseSubject6 = new CourseSubject(course3.Id, subject1.Id);
            CourseSubject courseSubject7 = new CourseSubject(course3.Id, subject3.Id);
            CourseSubject courseSubject8 = new CourseSubject(course3.Id, subject4.Id);
            #endregion
            builder.Entity<StudentCourseSubject>()
                .HasKey(AD => new { AD.StudentId, AD.CourseSubjectId });

            builder.Entity<Teacher>()
                .HasData(new List<Teacher>() { teacher1, teacher2,
                    teacher3, teacher4, teacher5 });

            builder.Entity<Course>()
                .HasData(new List<Course>() { course1, course2, course3 });

            builder.Entity<Subject>()
                .HasData(new List<Subject>() { subject1, subject2,
                    subject3, subject4, subject5 });

            builder.Entity<Student>()
                .HasData(new List<Student>() { student1, student2, student3,
                    student4, student5, student6, student7, student8, student9 });

            builder.Entity<CourseSubject>()
                .HasData(new List<CourseSubject>() { courseSubject1, courseSubject2,
                    courseSubject3, courseSubject4, courseSubject5,
                    courseSubject6, courseSubject7, courseSubject8 });

            builder.Entity<StudentCourseSubject>()
                .HasData(new List<StudentCourseSubject>() {
                    new StudentCourseSubject(courseSubject1.Id, student1.Id),
                    new StudentCourseSubject(courseSubject2.Id, student1.Id),
                    new StudentCourseSubject(courseSubject3.Id, student1.Id),
                    new StudentCourseSubject(courseSubject1.Id, student2.Id),
                    new StudentCourseSubject(courseSubject2.Id, student2.Id),
                    new StudentCourseSubject(courseSubject3.Id, student2.Id),
                    new StudentCourseSubject(courseSubject1.Id, student3.Id),
                    new StudentCourseSubject(courseSubject2.Id, student3.Id),
                    new StudentCourseSubject(courseSubject3.Id, student3.Id),
                    new StudentCourseSubject(courseSubject4.Id, student4.Id),
                    new StudentCourseSubject(courseSubject5.Id, student4.Id),
                    new StudentCourseSubject(courseSubject4.Id, student5.Id),
                    new StudentCourseSubject(courseSubject5.Id, student5.Id),
                    new StudentCourseSubject(courseSubject4.Id, student6.Id),
                    new StudentCourseSubject(courseSubject5.Id, student6.Id),
                    new StudentCourseSubject(courseSubject6.Id, student7.Id),
                    new StudentCourseSubject(courseSubject7.Id, student7.Id),
                    new StudentCourseSubject(courseSubject8.Id, student7.Id),
                    new StudentCourseSubject(courseSubject6.Id, student8.Id),
                    new StudentCourseSubject(courseSubject7.Id, student8.Id),
                    new StudentCourseSubject(courseSubject8.Id, student8.Id),
                    new StudentCourseSubject(courseSubject6.Id, student9.Id),
                    new StudentCourseSubject(courseSubject7.Id, student9.Id),
                    new StudentCourseSubject(courseSubject8.Id, student9.Id)
                });
        }

    }
}