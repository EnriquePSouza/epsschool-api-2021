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

        public static Expression<Func<Student, bool>> GetAllWhenPageParamsContainsName(PageParams y)
        {
            return x => x.Name
                            .ToUpper()
                            .Contains(y.Name.ToUpper()) &&
                        x.Surname
                            .ToUpper()
                            .Contains(y.Name.ToUpper());
        }

        public static Expression<Func<Student, bool>> GetAllWhenPageParamsContainsEnrollment(PageParams y)
        {
            return x => x.Enrollment == y.Enrollment;
        }

        public static Expression<Func<Student, bool>> GetAllWhenPageParamsContainsStatus(PageParams y)
        {
            return x => x.Status == (y.Status.Equals(1));
        }

        public static Expression<Func<Student, bool>> GetAllByCourseIdAsync(Guid courseId)
        {
            return x => x.StudentsCoursesSubjects.Any(
                             scs => scs.CourseSubject.CourseId == courseId);
        }
    }
}