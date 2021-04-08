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
            _context.SaveChanges();
        }

        public void Update(Student student)
        {
            _context.Entry(student).State = EntityState.Modified;
            _context.SaveChanges();
        }

        public void Delete(Student student)
        {
            _context.Entry(student).State = EntityState.Deleted;
            _context.SaveChanges();
        }

        public Student GetById(Guid studentId, bool includeTeacher = false)
        {
            IQueryable<Student> query = _context.Students;

            if (includeTeacher)
            {
                query = query.Include(s => s.StudentsCoursesSubjects)
                             .ThenInclude(scs => scs.CourseSubject)
                             .ThenInclude(cs => cs.Subject)
                             .ThenInclude(sb => sb.Teacher);
            }

            query = query.AsNoTracking()
                         .OrderBy(s => s.Id)
                         .Where(StudentQueries.GetStudentById(studentId));

            return query.FirstOrDefault();
        }

        public async Task<PageList<Student>> GetAllAsync(PageParams pageParams, bool includeTeacher = false)
        {
            IQueryable<Student> query = _context.Students;

            if (includeTeacher)
            {
                query = query.Include(s => s.StudentsCoursesSubjects)
                             .ThenInclude(scs => scs.CourseSubject)
                             .ThenInclude(cs => cs.Subject)
                             .ThenInclude(sb => sb.Teacher);
            }

            query = query.AsNoTracking().OrderBy(s => s.Id);

            if (!string.IsNullOrEmpty(pageParams.Name))
                query = query.Where(StudentQueries.GetAllWhenPageParamsContainsName(pageParams));

            if (!string.IsNullOrEmpty(pageParams.Enrollment))
                query = query.Where(StudentQueries.GetAllWhenPageParamsContainsEnrollment(pageParams));

            if (!string.IsNullOrEmpty(pageParams.Status))
                query = query.Where(StudentQueries.GetAllWhenPageParamsContainsStatus(pageParams));

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
                             .ThenInclude(sb => sb.Teacher);
            }

            query = query.AsNoTracking()
                         .OrderBy(s => s.Id)
                         .Where(StudentQueries.GetAllByCourseIdAsync(courseId));

            return await query.ToListAsync();
        }
    }
}