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
        #region Alunos
        public async Task<PageList<Student>> GetAllAlunosAsync(PageParams pageParams, bool includeProfessor = false)
        {
            IQueryable<Student> query = _context.Alunos;

            if (includeProfessor)
            {
                query = query.Include(a => a.AlunosCursosDisciplinas)
                             .ThenInclude(acd => acd.CursoDisciplina)
                             .ThenInclude(cd => cd.Disciplina)
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

        public Student GetAlunoById(int alunoId, bool includeProfessor = false)
        {
            IQueryable<Student> query = _context.Alunos;

            if (includeProfessor)
            {
                query = query.Include(a => a.AlunosCursosDisciplinas)
                             .ThenInclude(acd => acd.CursoDisciplina)
                             .ThenInclude(cd => cd.Disciplina)
                             .ThenInclude(d => d.Teacher);
            }

            query = query.AsNoTracking()
                         .OrderBy(a => a.Id)
                         .Where(aluno => aluno.Id.Equals(alunoId));


            return query.FirstOrDefault();
        }
        #endregion
        #region Professores
        public Teacher[] GetAllProfessores(bool includeAlunos = false)
        {
            IQueryable<Teacher> query = _context.Professores;

            if (includeAlunos)
            {
                query = query.Include(p => p.Disciplinas)
                             .ThenInclude(d => d.CursosDisciplinas)
                             .ThenInclude(cd => cd.AlunosCursosDisciplinas)
                             .ThenInclude(acd => acd.Student);
            }

            query = query.AsNoTracking().OrderBy(p => p.Id);

            return query.ToArray();
        }
        public Teacher GetProfessorById(int professorId, bool includeAlunos = false)
        {
            IQueryable<Teacher> query = _context.Professores;

            if (includeAlunos)
            {
                query = query.Include(p => p.Disciplinas)
                             .ThenInclude(d => d.CursosDisciplinas)
                             .ThenInclude(cd => cd.AlunosCursosDisciplinas)
                             .ThenInclude(acd => acd.Student);
            }

            query = query.AsNoTracking()
                         .OrderBy(p => p.Id)
                         .Where(p => p.Id == professorId);


            return query.FirstOrDefault();
        }

        public Teacher[] GetProfessoresByAlunoId(int alunoId, bool includeAlunos = false)
        {
            IQueryable<Teacher> query = _context.Professores;

            if (includeAlunos)
            {
                query = query.Include(p => p.Disciplinas)
                             .ThenInclude(d => d.CursosDisciplinas)
                             .ThenInclude(cd => cd.AlunosCursosDisciplinas)
                             .ThenInclude(acd => acd.Student);
            }

            query = query.AsNoTracking()
                         .OrderBy(a => a.Id)
                         .Where(professor => professor.Disciplinas.Any(
                             d => d.CursosDisciplinas.Any(
                             cd => cd.AlunosCursosDisciplinas.Any(
                             acd => acd.StudentId == alunoId))));

            return query.ToArray();
        }
        #endregion
    }
}