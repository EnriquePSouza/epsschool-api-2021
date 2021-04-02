using System.Linq;
using System.Threading.Tasks;
using EpsSchool.Domain.Entities;
using EpsSchool.Domain.Helpers;
using EpsSchool.Domain.Repositories;
using EpsSchool.infra.Contexts;
using Microsoft.EntityFrameworkCore;

namespace EpsSchool.Infra.Repositories
{
    public class StudentRepository : IStudentRepository
    {
        private readonly SchoolContext _context;
        
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

        public Student GetById(int studentId, bool includeTeacher = false)
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

        public async Task<PageList<Student>> GetAllAsync(PageParams pageParams, bool includeTeacher = false)
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

            if (!string.IsNullOrEmpty(pageParams.Name))
                query = query.Where(aluno => aluno.Name
                                                  .ToUpper()
                                                  .Contains(pageParams.Name.ToUpper()) ||
                                             aluno.Surname
                                                  .ToUpper()
                                                  .Contains(pageParams.Name.ToUpper()));

            if (pageParams.Registration > 0)
                query = query.Where(aluno => aluno.Registration == pageParams.Registration);

            if (pageParams.Status != null)
                query = query.Where(aluno => aluno.Status == (pageParams.Status != 0));

            return await PageList<Student>.CreateAsync(query, pageParams.PageNumber, pageParams.PageSize);
        }
    }
}