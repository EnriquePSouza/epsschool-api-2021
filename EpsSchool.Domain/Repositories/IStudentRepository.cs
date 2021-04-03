using System.Collections.Generic;
using System.Threading.Tasks;
using EpsSchool.Domain.Entities;
using EpsSchool.Domain.Helpers;
using Microsoft.AspNetCore.Mvc;

namespace EpsSchool.Domain.Repositories
{
    public interface IStudentRepository
    {
        void Create(Student student);
        void Update(Student student);
        void Delete(Student student);
        Task<Student> GetById(int studentId, bool includeTeacher = false);
        Task<PageList<Student>> GetAllAsync(PageParams pageParams, bool includeTeacher = false);
        Task<List<Student>> GetAllByCourseIdAsync(int courseId, bool includeTeacher = false);
    }
}