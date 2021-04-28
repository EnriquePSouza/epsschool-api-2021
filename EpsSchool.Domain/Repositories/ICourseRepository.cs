using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using EpsSchool.Domain.Entities;

namespace EpsSchool.Domain.Repositories
{
    public interface ICourseRepository
    {
        void Create(Course course);
        void Update(Course course);
        void Delete(Course course);
        Task SaveAsync();
        Task<Course> GetByIdAsync(Guid Id);
        Task<List<Course>> GetAllAsync();
    }
}