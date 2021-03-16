using System.Collections.Generic;
using System.Threading.Tasks;
using EpsSchool.Api.Helpers;
using EpsSchool.Api.Models;

namespace EpsSchool.Api.Data
{
    public interface IRepository
    {
        void Add<T>(T entity) where T : class;
        void Update<T>(T entity) where T : class;
        void Remove<T>(T entity) where T : class;
        bool SaveChanges();

        //Aluno
        public Task<PageList<Aluno>> GetAllAlunosAsync(PageParams pageParams, bool includeProfessor = false);
        public Aluno[] GetAllAlunos(bool includeProfessor = false);
        public Aluno[] GetAllAlunosByDisciplinaId(int disciplinaId, bool includeProfessor = false);
        public Aluno GetAlunoById(int alunoId, bool includeProfessor = false);

        //Professor
        public Professor[] GetAllProfessores(bool includeAlunos = false);
        public Professor[] GetAllProfessoresByDisciplinaId(int disciplinaId, bool includeAlunos = false);
        public Professor GetProfessorById(int professorId, bool includeAlunos = false);
    }
}