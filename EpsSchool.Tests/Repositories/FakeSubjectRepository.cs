using System;
using System.Threading.Tasks;
using EpsSchool.Domain.Entities;
using EpsSchool.Domain.Repositories;
using EpsSchool.Domain.Helpers;
using System.Collections.Generic;

namespace EpsSchool.Tests.Repositories
{
    public class FakeSubjectRepository : ISubjectRepository
    {
        public void Create(Subject subject) { }

        public void Update(Subject subject) { }

        public void Delete(Subject subject) { }

        public async Task SaveAsync()
        {
            await Task.Delay(10);
        }

        public Task<List<Subject>> GetAllAsync()
        {
            throw new NotImplementedException();
        }

        public async Task<Subject> GetByIdAsync(Guid id)
        {
            return await Task.Factory.StartNew(() => { return new Subject("Matemática"); });
        }
    }
}