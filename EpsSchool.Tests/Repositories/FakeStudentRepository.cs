using System;
using EpsSchool.Domain.Entities;
using EpsSchool.Domain.Repositories;

namespace EpsSchool.Tests.Repositories
{
    public class FakeStudentRepository : IStudentRepository
    {
        public void Create(Student student)
        {
            
        }

        public Student GetById(int id)
        {
            return new Student(1, 1, "Enrique", "Souza", "33458856", DateTime.Now);
        }

        public void Update(Student student)
        {
            
        }
    }
}