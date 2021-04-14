using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using EpsSchool.Domain.Entities;
using EpsSchool.Domain.Helpers;
using EpsSchool.Domain.Queries;
using EpsSchool.Domain.Repositories;
using EpsSchool.infra.Contexts;
using Microsoft.EntityFrameworkCore;

namespace EpsSchool.Infra.Repositories
{
    public class StudentCourseSubjectRepository : IStudentCourseSubjectRepository
    {
        private readonly SchoolContext _context;

        public StudentCourseSubjectRepository(SchoolContext context)
        {
            _context = context;
        }

        public void Create(StudentCourseSubject studentCourseSubject)
        {
            _context.StudentsCoursesSubjects.Add(studentCourseSubject);
        }

        public void Update(StudentCourseSubject studentCourseSubject)
        {
            _context.Entry(studentCourseSubject).State = EntityState.Modified;
        }

        public void Delete(StudentCourseSubject studentCourseSubject)
        {
            _context.Entry(studentCourseSubject).State = EntityState.Deleted;
        }

        public async Task SaveAsync()
        {
            await _context.SaveChangesAsync();
        }

        public async Task<List<StudentCourseSubject>> GetAllByStudentIdAsync(Guid studentId)
        {
            IQueryable<StudentCourseSubject> query = _context.StudentsCoursesSubjects;

            query = query.AsNoTracking()
                         .OrderBy(scs => scs.StudentId)
                         .Where(scs => scs.StudentId == studentId);

            return await query.ToListAsync();
        }

        public async Task<List<CourseSubject>> GetAllByCourseIdAsync(Guid courseId)
        {
            IQueryable<CourseSubject> query = _context.CoursesSubjects;

            query = query.AsNoTracking()
                         .OrderBy(cs => cs.CourseId)
                         .Where(cs => cs.CourseId == courseId);

            return await query.ToListAsync();
        }

    }
}