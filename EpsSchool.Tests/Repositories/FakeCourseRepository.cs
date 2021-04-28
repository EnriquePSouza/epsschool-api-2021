using System;
using System.Threading.Tasks;
using EpsSchool.Domain.Entities;
using EpsSchool.Domain.Repositories;
using EpsSchool.Domain.Helpers;
using System.Collections.Generic;

namespace EpsSchool.Tests.Repositories
{
    public class FakeCourseRepository : ICourseRepository
    {
        public void Create(Course subject) { }

        public void Update(Course subject) { }

        public void Delete(Course subject) { }

        public async Task SaveAsync()
        {
            await Task.Delay(10);
        }

        public Task<List<Course>> GetAllAsync()
        {
            throw new NotImplementedException();
        }

        public async Task<Course> GetByIdAsync(Guid id)
        {
            return await Task.Factory.StartNew(() => { return new Course("Informática"); });
        }
    }
}