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
        Task<PageList<Student>> GetAllAlunosAsync(PageParams pageParams, bool includeProfessor = false);
        Student GetAlunoById(int alunoId, bool includeProfessor = false);

        //Professor
        Teacher[] GetAllProfessores(bool includeAlunos = false);
        Teacher GetProfessorById(int professorId, bool includeAlunos = false);
        Teacher[] GetProfessoresByAlunoId(int alunoId, bool includeAlunos = false);
    }
}