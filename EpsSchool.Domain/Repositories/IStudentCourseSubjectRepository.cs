using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using EpsSchool.Domain.Entities;

namespace EpsSchool.Domain.Repositories
{
    public interface IStudentCourseSubjectRepository
    {
        void Create(StudentCourseSubject studentCourseSubject);
        void Update(StudentCourseSubject studentCourseSubject);
        void Delete(StudentCourseSubject studentCourseSubject);
        Task SaveAsync();
        Task<List<StudentCourseSubject>> GetAllByStudentIdAsync(Guid studentId);
        Task<List<CourseSubject>> GetAllByCourseIdAsync(Guid courseId);
    }
}