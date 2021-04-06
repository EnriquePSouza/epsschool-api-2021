using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using EpsSchool.Domain.Entities;
using EpsSchool.Domain.Repositories;
using EpsSchool.infra.Contexts;
using Microsoft.EntityFrameworkCore;

namespace EpsSchool.Infra.Repositories
{
    public class TeacherRepository : ITeacherRepository
    {
        private readonly SchoolContext _context;
        
        public TeacherRepository(SchoolContext context)
        {
            _context = context;
        }

        public void Create(Teacher teacher)
        {
            _context.Teachers.Add(teacher);
            _context.SaveChanges();
        }

        public void Update(Teacher teacher)
        {
            _context.Entry(teacher).State = EntityState.Modified;
            _context.SaveChanges();
        }

        public void Delete(Teacher teacher)
        {
            _context.Entry(teacher).State = EntityState.Deleted;
            _context.SaveChanges();
        }

        public Task<Teacher> GetById(Guid teacherId, bool includeStudents = false)
        {
            IQueryable<Teacher> query = _context.Teachers;

            if (includeStudents)
            {
                query = query.Include(t => t.Subject)
                                .ThenInclude(s => s.CoursesSubjects)
                                .ThenInclude(cs => cs.Course)
                             .Include(t => t.Subject)
                                .ThenInclude(s => s.CoursesSubjects)
                                .ThenInclude(cs => cs.StudentsCoursesSubjects)
                                .ThenInclude(acd => acd.Student);
            }

            query = query.AsNoTracking()
                         .OrderBy(p => p.Id)
                         .Where(p => p.Id == teacherId);


            return query.FirstOrDefaultAsync();
        }

        public async Task<List<Teacher>> GetAll(bool includeStudents = false)
        {
            IQueryable<Teacher> query = _context.Teachers;

            if (includeStudents)
            {
                query = query.Include(t => t.Subject)
                                .ThenInclude(s => s.CoursesSubjects)
                                .ThenInclude(cs => cs.Course)
                             .Include(t => t.Subject)
                                .ThenInclude(s => s.CoursesSubjects)
                                .ThenInclude(cs => cs.StudentsCoursesSubjects)
                                .ThenInclude(acd => acd.Student);
            }

            query = query.AsNoTracking().OrderBy(p => p.Id);

            return await query.ToListAsync();
        }

        public async Task<List<Teacher>> GetByStudentId(Guid studentId, bool includeStudents = false)
        {
            IQueryable<Teacher> query = _context.Teachers;

            if (includeStudents)
            {
                query = query.Include(t => t.Subject)
                                .ThenInclude(s => s.CoursesSubjects)
                                .ThenInclude(cs => cs.Course)
                             .Include(t => t.Subject)
                                .ThenInclude(s => s.CoursesSubjects)
                                .ThenInclude(cs => cs.StudentsCoursesSubjects)
                                .ThenInclude(acd => acd.Student);
            }

            query = query.AsNoTracking()
                         .OrderBy(t => t.Id)
                         .Where(t => t.Subject.Any(
                             d => d.CoursesSubjects.Any(
                             cd => cd.StudentsCoursesSubjects.Any(
                             acd => acd.StudentId == studentId))));

            return await query.ToListAsync();
        }
    }
}