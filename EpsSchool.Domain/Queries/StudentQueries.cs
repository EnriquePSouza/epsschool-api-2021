using System;
using System.Linq;
using System.Linq.Expressions;
using EpsSchool.Domain.Entities;
using EpsSchool.Domain.Helpers;

namespace EpsSchool.Domain.Queries
{
    public static class StudentQueries
    {
        public static Expression<Func<Student, bool>> GetStudentById(Guid id)
        {
            return x => x.Id == id;
        }

        public static Expression<Func<Student, bool>> GetAllByName(string name)
        {
            return x => x.FirstName
                            .ToUpper()
                            .Contains(name.ToUpper()) ||
                        x.LastName
                            .ToUpper()
                            .Contains(name.ToUpper());
        }

        public static Expression<Func<Student, bool>> GetAllByEnrollment(string enrollment)
        {
            return x => x.Enrollment == enrollment;
        }

        public static Expression<Func<Student, bool>> GetAllByStatus(string status)
        {
            return x => x.Status == (status.Equals(1));
        }

        public static Expression<Func<Student, bool>> GetAllByCourseIdAsync(Guid courseId)
        {
            return x => x.StudentsCoursesSubjects.Any(
                             scs => scs.CourseSubject.CourseId == courseId);
        }
    }
}