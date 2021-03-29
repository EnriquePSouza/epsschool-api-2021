using System.Threading.Tasks;
using EpsSchool.Domain.Helpers;
using EpsSchool.Domain.Entities;

namespace EpsSchool.Domain.Repositories
{
    public interface IRepository
    {
        void Add<T>(T entity) where T : class;
        void Update<T>(T entity) where T : class;
        void Remove<T>(T entity) where T : class;
        bool SaveChanges();

        //Aluno
        Task<PageList<Student>> GetAllStudentsAsync(PageParams pageParams, bool includeProfessor = false);
        Student GetStudentById(int alunoId, bool includeProfessor = false);

        //Professor
        Teacher[] GetAllTeachers(bool includeAlunos = false);
        Teacher GetTeacherById(int professorId, bool includeAlunos = false);
        Teacher[] GetTeachersByStudentId(int alunoId, bool includeAlunos = false);
    }
}