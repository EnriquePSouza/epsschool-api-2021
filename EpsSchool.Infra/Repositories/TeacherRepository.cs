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

        public Teacher GetById(int teacherId, bool includeStudents = false)
        {
            IQueryable<Teacher> query = _context.Teachers;

            if (includeStudents)
            {
                query = query.Include(p => p.Subjects)
                             .ThenInclude(d => d.CoursesSubjects)
                             .ThenInclude(cd => cd.StudentsCoursesSubjects)
                             .ThenInclude(acd => acd.Student);
            }

            query = query.AsNoTracking()
                         .OrderBy(p => p.Id)
                         .Where(p => p.Id == teacherId);


            return query.FirstOrDefault();
        }

        public async Task<List<Teacher>> GetAll(bool includeStudents = false)
        {
            IQueryable<Teacher> query = _context.Teachers;

            if (includeStudents)
            {
                query = query.Include(p => p.Subjects)
                             .ThenInclude(d => d.CoursesSubjects)
                             .ThenInclude(cd => cd.StudentsCoursesSubjects)
                             .ThenInclude(acd => acd.Student);
            }

            query = query.AsNoTracking().OrderBy(p => p.Id);

            return await query.ToListAsync();
        }

        public async Task<List<Teacher>> GetByStudentId(int studentId, bool includeStudents = false)
        {
            IQueryable<Teacher> query = _context.Teachers;

            if (includeStudents)
            {
                query = query.Include(p => p.Subjects)
                             .ThenInclude(d => d.CoursesSubjects)
                             .ThenInclude(cd => cd.StudentsCoursesSubjects)
                             .ThenInclude(acd => acd.Student);
            }

            query = query.AsNoTracking()
                         .OrderBy(a => a.Id)
                         .Where(professor => professor.Subjects.Any(
                             d => d.CoursesSubjects.Any(
                             cd => cd.StudentsCoursesSubjects.Any(
                             acd => acd.StudentId == studentId))));

            return await query.ToListAsync();
        }
    }
}