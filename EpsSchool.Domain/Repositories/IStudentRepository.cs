using EpsSchool.Domain.Entities;

namespace EpsSchool.Domain.Repositories
{
    public interface IStudentRepository
    {
        void Create(Student student);
        void Update(Student student);
        Student GetById(int id);
    }
}