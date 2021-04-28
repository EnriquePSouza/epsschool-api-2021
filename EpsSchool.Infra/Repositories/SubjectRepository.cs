using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using EpsSchool.Domain.Entities;
using EpsSchool.Domain.Helpers;
using EpsSchool.Domain.Queries;
using EpsSchool.Domain.Repositories;
using EpsSchool.Infra.Contexts;
using Microsoft.EntityFrameworkCore;

namespace EpsSchool.Infra.Repositories
{
    public class SubjectRepository : ISubjectRepository
    {
        private readonly SchoolContext _context;

        public SubjectRepository(SchoolContext context)
        {
            _context = context;
        }

        public void Create(Subject subject)
        {
            _context.Subjects.Add(subject);
        }

        public void Update(Subject subject)
        {
            _context.Entry(subject).State = EntityState.Modified;
        }

        public void Delete(Subject subject)
        {
            _context.Entry(subject).State = EntityState.Deleted;
        }

        public async Task SaveAsync()
        {
            await _context.SaveChangesAsync();
        }

        public async Task<List<Subject>> GetAllAsync()
        {
            IQueryable<Subject> query = _context.Subjects;

            query = query.AsNoTracking()
                         .OrderBy(s => s.Name);

            return await query.ToListAsync();
        }

        public async Task<Subject> GetByIdAsync(Guid id)
        {
            IQueryable<Subject> query = _context.Subjects;

            query = query.AsNoTracking()
                         .Where(SubjectQueries.GetById(id));

            return await query.FirstOrDefaultAsync();
        }

    }
}