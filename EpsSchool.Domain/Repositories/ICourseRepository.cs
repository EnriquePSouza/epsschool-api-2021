using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using EpsSchool.Domain.Entities;

namespace EpsSchool.Domain.Repositories
{
    public interface ICourseSubjectRepository
    {
        void Create(CourseSubject courseSubject);
        void Update(CourseSubject courseSubject);
        void Delete(CourseSubject courseSubject);
        Task SaveAsync();
    }
}