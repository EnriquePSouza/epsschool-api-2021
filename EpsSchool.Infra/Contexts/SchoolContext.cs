using System;
using System.Collections.Generic;
using EpsSchool.Domain.Entities;
using Microsoft.EntityFrameworkCore;

namespace EpsSchool.infra.Contexts
{
    public class SchoolContext : DbContext
    {
        public SchoolContext(DbContextOptions<SchoolContext> options) : base(options) { }
        public DbSet<Student> Students { get; set; }
        public DbSet<StudentCourseSubject> StudentsCoursesSubjects { get; set; }
        public DbSet<Course> Courses { get; set; }
        public DbSet<CourseSubject> CoursesSubjects { get; set; }
        public DbSet<Subject> Subjects { get; set; }
        public DbSet<Teacher> Teachers { get; set; }

        protected override void OnModelCreating(ModelBuilder builder)
        {
            builder.Entity<StudentCourseSubject>()
                .HasKey(AD => new { AD.StudentId, AD.CourseSubjectId });

            builder.Entity<Teacher>()
                .HasData(new List<Teacher>(){
                    new Teacher(1, 1, "José", "Roberto","44778899"),
                    new Teacher(2, 2, "Carlos", "Eduardo","33568941"),
                    new Teacher(3, 3, "Manuel", "Nobre","99587462"),
                    new Teacher(4, 4, "João", "Olavo","33506987"),
                    new Teacher(5, 5, "Lucas", "Ribas","33214896")
                });

            builder.Entity<Course>()
                .HasData(new List<Course>(){
                    new Course(1, "Informatica"),
                    new Course(2, "Manutenção de Micros"),
                    new Course(3, "Redes de Computadores")
                });

            builder.Entity<Subject>()
                .HasData(new List<Subject>(){
                    new Subject(1, "Matemática", 1),
                    new Subject(2, "Limpeza de Gabinete", 2),
                    new Subject(3, "Português", 3),
                    new Subject(4, "Arquitetura de Servidores", 4),
                    new Subject(5, "Programação", 5)
                });

            builder.Entity<Student>()
                .HasData(new List<Student>(){
                    new Student(1, 1, "Joana", "Alves", "33556699", DateTime.Parse("07/17/2005", new System.Globalization.CultureInfo("en-US"))),
                    new Student(2, 2, "Fernanda", "Silva", "33447789", DateTime.Parse("07/17/2005", new System.Globalization.CultureInfo("en-US"))),
                    new Student(3, 3, "Vanessa", "Lisboa", "99562341", DateTime.Parse("07/17/2005", new System.Globalization.CultureInfo("en-US"))),
                    new Student(4, 4, "Maria", "Madalena", "99452417", DateTime.Parse("07/17/2005", new System.Globalization.CultureInfo("en-US"))),
                    new Student(5, 5, "João", "Paulo", "98564712", DateTime.Parse("07/17/2005", new System.Globalization.CultureInfo("en-US"))),
                    new Student(6, 6, "Ananias", "Fernandes", "33589624", DateTime.Parse("07/17/2005", new System.Globalization.CultureInfo("en-US"))),
                    new Student(7, 7, "José", "Arimatéia", "98745122", DateTime.Parse("07/17/2005", new System.Globalization.CultureInfo("en-US")))
                });

            builder.Entity<CourseSubject>()
                .HasData(new List<CourseSubject>() {
                    new CourseSubject(1, 1, 1),
                    new CourseSubject(2, 1, 3),
                    new CourseSubject(3, 1, 5),
                    new CourseSubject(4, 2, 2),
                    new CourseSubject(5, 2, 3),
                    new CourseSubject(6, 3, 1),
                    new CourseSubject(7, 3, 3),
                    new CourseSubject(8, 3, 4)
                });

            builder.Entity<StudentCourseSubject>()
                .HasData(new List<StudentCourseSubject>() {
                    new StudentCourseSubject(1,1),
                    new StudentCourseSubject(1,2),
                    new StudentCourseSubject(1,3),
                    new StudentCourseSubject(2,1),
                    new StudentCourseSubject(2,2),
                    new StudentCourseSubject(2,3),
                    new StudentCourseSubject(3,4),
                    new StudentCourseSubject(3,5),
                    new StudentCourseSubject(4,4),
                    new StudentCourseSubject(4,5),
                    new StudentCourseSubject(5,4),
                    new StudentCourseSubject(5,5),
                    new StudentCourseSubject(6,5),
                    new StudentCourseSubject(6,6),
                    new StudentCourseSubject(6,7),
                    new StudentCourseSubject(7,5),
                    new StudentCourseSubject(7,6),
                    new StudentCourseSubject(7,7)
                });
        }

    }
}