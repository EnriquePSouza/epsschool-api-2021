using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using EpsSchool.Domain.Commands;
using EpsSchool.Domain.Entities;
using EpsSchool.Domain.Helpers;

namespace EpsSchool.Domain.Repositories
{
    public interface IStudentRepository
    {
        void Create(Student student);
        void Update(Student student);
        void Delete(Student student);
        Student GetById(Guid studentId, bool includeTeacher = false);
        Task<PageList<Student>> GetAllAsync(PageParams pageParams, bool includeTeacher = false);
        Task<List<Student>> GetAllByCourseIdAsync(Guid courseId, bool includeTeacher = false);
    }
}