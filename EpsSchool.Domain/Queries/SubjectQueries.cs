using System;
using System.Linq;
using System.Linq.Expressions;
using EpsSchool.Domain.Entities;
using EpsSchool.Domain.Helpers;

namespace EpsSchool.Domain.Queries
{
    public static class SubjectQueries
    {
        public static Expression<Func<Subject, bool>> GetById(Guid id)
        {
            return x => x.Id == id;
        }
    }
}