using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using EpsSchool.Domain.Entities;

namespace EpsSchool.Domain.Repositories
{
    public interface ISubjectRepository
    {
        void Create(Subject subject);
        void Update(Subject subject);
        void Delete(Subject subject);
        Task SaveAsync();
        Task<Subject> GetByIdAsync(Guid Id);
        Task<List<Subject>> GetAllAsync();
    }
}