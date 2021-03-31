using EpsSchool.Domain.Entities;

namespace EpsSchool.Domain.Repositories
{
    public interface ITeacherRepository
    {
        void Create(Teacher student);
        void Update(Teacher student);
        Teacher GetById(int id);
    }
}