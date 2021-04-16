using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using EpsSchool.Domain.Entities;
using EpsSchool.Domain.Queries;
using EpsSchool.Domain.Repositories;
using EpsSchool.Infra.Contexts;
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
        }

        public void Update(Teacher teacher)
        {
            _context.Entry(teacher).State = EntityState.Modified;
        }

        public void Delete(Teacher teacher)
        {
            _context.Entry(teacher).State = EntityState.Deleted;
        }

        public async Task SaveAsync()
        {
            await _context.SaveChangesAsync();
        }

        public async Task<Teacher> GetById(Guid teacherId, bool includeStudents = false)
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
                                .ThenInclude(scs => scs.Student);
            }

            query = query.AsNoTracking()
                         .OrderBy(t => t.Id)
                         .Where(TeacherQueries.GetTeacherById(teacherId));


            return await query.FirstOrDefaultAsync();
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
                         .Include(t => t.Subject)
                         .ThenInclude(sb => sb.CoursesSubjects
                                     .Where(TeacherQueries.GetAllByStudentIdAsync(studentId)));

            return await query.ToListAsync();
        }
    }
}