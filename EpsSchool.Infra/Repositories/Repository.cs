using System.Linq;
using System.Threading.Tasks;
using EpsSchool.Domain.Helpers;
using EpsSchool.Domain.Entities;
using Microsoft.EntityFrameworkCore;
using EpsSchool.Domain.Repositories;
using EpsSchool.infra.Contexts;

namespace EpsSchool.infra.Repositories
{
    public class Repository : IRepository
    {
        private readonly SchoolContext _context;
        public Repository(SchoolContext context)
        {
            _context = context;
        }
        #region Generic
        public void Add<T>(T entity) where T : class
        {
            _context.Add(entity);
        }

        public void Update<T>(T entity) where T : class
        {
            _context.Update(entity);
        }

        public void Remove<T>(T entity) where T : class
        {
            _context.Remove(entity);
        }

        public bool SaveChanges()
        {
            return (_context.SaveChanges() > 0);
        }
        #endregion
        #region Students
        public async Task<PageList<Student>> GetAllStudentsAsync(PageParams pageParams, bool includeTeacher = false)
        {
            IQueryable<Student> query = _context.Students;

            if (includeTeacher)
            {
                query = query.Include(a => a.StudentsCoursesSubjects)
                             .ThenInclude(acd => acd.CourseSubject)
                             .ThenInclude(cd => cd.Subject)
                             .ThenInclude(d => d.Teacher);
            }

            query = query.AsNoTracking().OrderBy(a => a.Id);

            if (!string.IsNullOrEmpty(pageParams.Nome))
                query = query.Where(aluno => aluno.Nome
                                                  .ToUpper()
                                                  .Contains(pageParams.Nome.ToUpper()) ||
                                             aluno.Sobrenome
                                                  .ToUpper()
                                                  .Contains(pageParams.Nome.ToUpper()));

            if (pageParams.Matricula > 0)
                query = query.Where(aluno => aluno.Registration == pageParams.Matricula);

            if (pageParams.Ativo != null)
                query = query.Where(aluno => aluno.Ativo == (pageParams.Ativo != 0));

            return await PageList<Student>.CreateAsync(query, pageParams.PageNumber, pageParams.PageSize);
        }

        public Student GetStudentById(int studentId, bool includeTeacher = false)
        {
            IQueryable<Student> query = _context.Students;

            if (includeTeacher)
            {
                query = query.Include(a => a.StudentsCoursesSubjects)
                             .ThenInclude(acd => acd.CourseSubject)
                             .ThenInclude(cd => cd.Subject)
                             .ThenInclude(d => d.Teacher);
            }

            query = query.AsNoTracking()
                         .OrderBy(a => a.Id)
                         .Where(aluno => aluno.Id.Equals(studentId));


            return query.FirstOrDefault();
        }
        #endregion
        #region Teachers
        public Teacher[] GetAllTeachers(bool includeStudents = false)
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

            return query.ToArray();
        }
        public Teacher GetTeacherById(int teacherId, bool includeStudents = false)
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

        public Teacher[] GetTeachersByStudentId(int studentId, bool includeStudents = false)
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

            return query.ToArray();
        }
        #endregion
    }
}