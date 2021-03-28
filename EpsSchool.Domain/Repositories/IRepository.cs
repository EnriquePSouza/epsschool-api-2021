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
        Task<PageList<Aluno>> GetAllAlunosAsync(PageParams pageParams, bool includeProfessor = false);
        Aluno GetAlunoById(int alunoId, bool includeProfessor = false);

        //Professor
        Professor[] GetAllProfessores(bool includeAlunos = false);
        Professor GetProfessorById(int professorId, bool includeAlunos = false);
        Professor[] GetProfessoresByAlunoId(int alunoId, bool includeAlunos = false);
    }
}