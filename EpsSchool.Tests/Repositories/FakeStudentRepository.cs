using System;
using System.Threading.Tasks;
using EpsSchool.Domain.Entities;
using EpsSchool.Domain.Repositories;
using EpsSchool.Domain.Helpers;
using System.Collections.Generic;

namespace EpsSchool.Tests.Repositories
{
    public class FakeStudentRepository : IStudentRepository
    {
        public void Create(Student student) { }

        public void Update(Student student) { }

        public void Delete(Student student) { }

        public async Task SaveAsync()
        {
            await Task.Delay(10);
        }

        public Task<PageList<Student>> GetAllAsync(PageParams pageParams, bool includeTeacher = false)
        {
            throw new NotImplementedException();
        }

        public Task<List<Student>> GetAllByCourseIdAsync(Guid courseId, bool includeTeacher = false)
        {
            throw new NotImplementedException();
        }

        public async Task<Student> GetById(Guid studentId, bool includeTeacher = false)
        {
            return await Task.Factory.StartNew(() => { return new Student("Enrique", "Souza", "33458856", DateTime.Now); });
        }
    }
}