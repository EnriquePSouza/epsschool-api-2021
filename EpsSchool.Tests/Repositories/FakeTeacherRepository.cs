using System;
using System.Threading.Tasks;
using EpsSchool.Domain.Entities;
using EpsSchool.Domain.Repositories;
using System.Collections.Generic;

namespace EpsSchool.Tests.Repositories
{
    public class FakeTeacherRepository : ITeacherRepository
    {
        public void Create(Teacher teacher) { }

        public void Delete(Teacher teacher)
        {
            throw new NotImplementedException();
        }

        public Task<List<Teacher>> GetAll(bool includeStudents = false)
        {
            throw new NotImplementedException();
        }

        public Teacher GetById(Guid teacherId, bool includeStudents = false)
        {
            return new Teacher("Enrique", "Souza", "33458856");
        }

        public Task<List<Teacher>> GetByStudentId(Guid studentId, bool includeStudents = false)
        {
            throw new NotImplementedException();
        }

        public void Update(Teacher teacher) { }
    }
}