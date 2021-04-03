using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using EpsSchool.Domain.Entities;
using EpsSchool.Domain.Helpers;
using EpsSchool.Domain.Repositories;
using EpsSchool.infra.Contexts;
using Microsoft.AspNetCore.Mvc;
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

        public async Task<Student> GetById(int studentId, bool includeTeacher = false)
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
                         .Where(s => s.Id.Equals(studentId));


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
                             .ThenInclude(sb => sb.Teacher);
            }

            query = query.AsNoTracking().OrderBy(s => s.Id);

            if (!string.IsNullOrEmpty(pageParams.Name))
                query = query.Where(s => s.Name
                                                  .ToUpper()
                                                  .Contains(pageParams.Name.ToUpper()) ||
                                                s.Surname
                                                  .ToUpper()
                                                  .Contains(pageParams.Name.ToUpper()));

            if (pageParams.Registration > 0)
                query = query.Where(s => s.Registration == pageParams.Registration);

            if (pageParams.Status != null)
                query = query.Where(s => s.Status == (pageParams.Status != 0));

            return await PageList<Student>.CreateAsync(query, pageParams.PageNumber, pageParams.PageSize);
        }

        public async Task<List<Student>> GetAllByCourseIdAsync(int courseId, bool includeTeacher = false)
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
                         .Where(s => s.StudentsCoursesSubjects.Any(
                             d => d.CourseSubject.CourseId == courseId));

            return await query.ToListAsync();
        }
    }
}