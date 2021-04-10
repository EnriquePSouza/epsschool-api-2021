using System;
using System.Linq;
using System.Linq.Expressions;
using EpsSchool.Domain.Entities;
using EpsSchool.Domain.Helpers;

namespace EpsSchool.Domain.Queries
{
    public class TeacherQueries
    {
        public static Expression<Func<Teacher, bool>> GetTeacherById(Guid id)
        {
            return x => x.Id == id;
        }

        public static Func<CourseSubject, bool> GetAllByStudentIdAsync(Guid studentId)
        {
            return cs => cs.StudentsCoursesSubjects.Any(scs => scs.StudentId == studentId);
        }

    }
}