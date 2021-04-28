using System;
using System.Linq;
using System.Linq.Expressions;
using EpsSchool.Domain.Entities;
using EpsSchool.Domain.Helpers;

namespace EpsSchool.Domain.Queries
{
    public static class CourseQueries
    {
        public static Expression<Func<Course, bool>> GetById(Guid id)
        {
            return x => x.Id == id;
        }
    }
}