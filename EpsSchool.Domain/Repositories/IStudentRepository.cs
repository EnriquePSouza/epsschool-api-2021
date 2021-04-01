using System.Threading.Tasks;
using EpsSchool.Domain.Entities;
using EpsSchool.Domain.Helpers;

namespace EpsSchool.Domain.Repositories
{
    public interface IStudentRepository
    {
        void Create(Student student);
        void Update(Student student);
        void Delete(Student student);
        Student GetById(int studentId, bool includeTeacher = false);
        Task<PageList<Student>> GetAllAsync(PageParams pageParams, bool includeTeacher = false);
    }
}