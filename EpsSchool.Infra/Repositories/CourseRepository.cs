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
    public class CourseRepository : ICourseRepository
    {
        private readonly SchoolContext _context;

        public CourseRepository(SchoolContext context)
        {
            _context = context;
        }

        public void Create(Course course)
        {
            _context.Courses.Add(course);
        }

        public void Update(Course course)
        {
            _context.Entry(course).State = EntityState.Modified;
        }

        public void Delete(Course course)
        {
            _context.Entry(course).State = EntityState.Deleted;
        }

        public async Task SaveAsync()
        {
            await _context.SaveChangesAsync();
        }

        public async Task<List<Course>> GetAllAsync()
        {
            IQueryable<Course> query = _context.Courses;

            query = query.AsNoTracking()
                         .OrderBy(s => s.Name);

            return await query.ToListAsync();
        }

        public async Task<Course> GetByIdAsync(Guid id)
        {
            IQueryable<Course> query = _context.Courses;

            query = query.AsNoTracking()
                         .Where(s => s.Id == id);

            return await query.FirstOrDefaultAsync();
        }

    }
}