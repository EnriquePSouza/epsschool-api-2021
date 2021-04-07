using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using EpsSchool.Domain.Entities;

namespace EpsSchool.Domain.Repositories
{
    public interface ITeacherRepository
    {
        void Create(Teacher teacher);
        void Update(Teacher teacher);
        void Delete(Teacher teacher);
        Teacher GetById(Guid teacherId, bool includeStudents = false);
        Task<List<Teacher>> GetAll(bool includeStudents = false);
        Task<List<Teacher>> GetByStudentId(Guid studentId, bool includeStudents = false);
    }
}