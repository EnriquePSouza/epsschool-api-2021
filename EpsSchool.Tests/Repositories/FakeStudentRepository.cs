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

        public void Delete(Student student)
        {
            throw new NotImplementedException();
        }

        public void Update(Student student) { }

        public Task<PageList<Student>> GetAllAsync(PageParams pageParams, bool includeTeacher = false)
        {
            throw new NotImplementedException();
        }

        public Student GetById(Guid studentId, bool includeTeacher = false)
        {
            return new Student("Enrique", "Souza", "33458856", DateTime.Now);
        }

        public Task<List<Student>> GetAllByCourseIdAsync(Guid courseId, bool includeTeacher = false)
        {
            throw new NotImplementedException();
        }
    }
}