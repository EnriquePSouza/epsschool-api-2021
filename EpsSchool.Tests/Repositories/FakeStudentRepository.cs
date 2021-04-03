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
        public void Create(Student student)
        {
            throw new NotImplementedException();   
        }

        public void Delete(Student student)
        {
            throw new NotImplementedException();
        }

        public void Update(Student student)
        {
            throw new NotImplementedException();   
        }

        public Task<PageList<Student>> GetAllAsync(PageParams pageParams, bool includeTeacher = false)
        {
            throw new NotImplementedException();
        }

        public Task<List<Student>> GetAllByCourseIdAsync(int disciplinaId, bool includeProfessor = false)
        {
            throw new NotImplementedException();
        }

        public Task<Student> GetById(int studentId, bool includeTeacher = false)
        {
            throw new NotImplementedException();
        }

        public Student GetById(int id)
        {
            return new Student(1, 1, "Enrique", "Souza", "33458856", DateTime.Now);
        }

    }
}