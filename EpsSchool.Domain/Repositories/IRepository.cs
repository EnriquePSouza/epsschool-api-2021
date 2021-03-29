using System.Threading.Tasks;
using EpsSchool.Domain.Helpers;
using EpsSchool.Domain.Entities;

namespace EpsSchool.Domain.Repositories
{
    public interface IRepository
    {
        #region Generic
        void Add<T>(T entity) where T : class;
        void Update<T>(T entity) where T : class;
        void Remove<T>(T entity) where T : class;
        bool SaveChanges();
        #endregion

        #region Student
        Task<PageList<Student>> GetAllStudentsAsync(PageParams pageParams, bool includeTeacher = false);
        Student GetStudentById(int studentId, bool includeTeacher = false);
        #endregion

        #region Teacher
        Teacher[] GetAllTeachers(bool includeStudents = false);
        Teacher GetTeacherById(int teacherId, bool includeStudents = false);
        Teacher[] GetTeachersByStudentId(int studentId, bool includeStudents = false);
        #endregion
    }
}