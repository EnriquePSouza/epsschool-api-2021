using System;
using System.Threading.Tasks;
using EpsSchool.Domain.Entities;
using EpsSchool.Domain.Repositories;
using System.Collections.Generic;

namespace EpsSchool.Tests.Repositories
{
    public class FakeStudentCourseSubjectRepository : IStudentCourseSubjectRepository
    {
        public void Create(StudentCourseSubject studentCourseSubject) { }

        public void Update(StudentCourseSubject studentCourseSubject) { }

        public void Delete(StudentCourseSubject studentCourseSubject) { }

        public async Task SaveAsync()
        {
            await Task.Delay(10);
        }

        public async Task<List<CourseSubject>> GetAllByCourseIdAsync(Guid courseId)
        {
            return await Task.Factory.StartNew(() => { return new List<CourseSubject>(); });
        }

        public async Task<List<StudentCourseSubject>> GetAllByStudentIdAsync(Guid studentId)
        {
            return await Task.Factory.StartNew(() => { return new List<StudentCourseSubject>(); });
        }
    }
}