using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using EpsSchool.Domain.Entities;
using EpsSchool.Domain.Helpers;
using EpsSchool.Domain.Queries;
using EpsSchool.Domain.Repositories;
using EpsSchool.Infra.Contexts;
using Microsoft.EntityFrameworkCore;

namespace EpsSchool.Infra.Repositories
{
    public class StudentRepository : IStudentRepository
    {
        private readonly SchoolContext _context;

        public StudentRepository(SchoolContext context)
        {
            _context = context;
        }

        public void Create(Student student)
        {
            _context.Students.Add(student);
        }

        public void Update(Student student)
        {
            _context.Entry(student).State = EntityState.Modified;
        }

        public void Delete(Student student)
        {
            _context.Entry(student).State = EntityState.Deleted;
        }

        public async Task SaveAsync()
        {
            await _context.SaveChangesAsync();
        }

        public async Task<Student> GetById(Guid studentId, bool includeTeacher = false)
        {
            IQueryable<Student> query = _context.Students;

            if (includeTeacher)
            {
                query = query.Include(s => s.StudentsCoursesSubjects)
                             .ThenInclude(scs => scs.CourseSubject)
                             .ThenInclude(cs => cs.Subject)
                             .ThenInclude(sb => sb.Teachers);
            }

            query = query.AsNoTracking()
                         .OrderBy(s => s.Id)
                         .Where(StudentQueries.GetStudentById(studentId));

            return await query.FirstOrDefaultAsync();
        }

        public async Task<PageList<Student>> GetAllAsync(PageParams pageParams, bool includeTeacher = false)
        {
            IQueryable<Student> query = _context.Students;

            if (includeTeacher)
            {
                query = query.Include(s => s.StudentsCoursesSubjects)
                             .ThenInclude(scs => scs.CourseSubject)
                             .ThenInclude(cs => cs.Subject)
                             .ThenInclude(sb => sb.Teachers);
            }

            query = query.AsNoTracking().OrderBy(s => s.Id);

            if (!string.IsNullOrEmpty(pageParams.Name))
                query = query.Where(StudentQueries.GetAllByName(pageParams.Name));

            if (!string.IsNullOrEmpty(pageParams.Enrollment))
                query = query.Where(StudentQueries.GetAllByEnrollment(pageParams.Enrollment));

            if (!string.IsNullOrEmpty(pageParams.Status))
                query = query.Where(StudentQueries.GetAllByStatus(pageParams.Status));

            return await PageList<Student>.CreateAsync(query, pageParams.PageNumber, pageParams.PageSize);
        }

        public async Task<List<Student>> GetAllByCourseIdAsync(Guid courseId, bool includeTeacher = false)
        {
            IQueryable<Student> query = _context.Students;

            if (includeTeacher)
            {
                query = query.Include(s => s.StudentsCoursesSubjects)
                             .ThenInclude(scs => scs.CourseSubject)
                             .ThenInclude(cs => cs.Subject)
                             .ThenInclude(sb => sb.Teachers);
            }

            query = query.AsNoTracking()
                         .OrderBy(s => s.Id)
                         .Where(StudentQueries.GetAllByCourseIdAsync(courseId));

            return await query.ToListAsync();
        }
    }
}