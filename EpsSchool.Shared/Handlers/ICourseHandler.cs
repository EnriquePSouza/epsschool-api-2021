using System.Threading.Tasks;
using EpsSchool.Shared.Commands;

namespace EpsSchool.Shared.Handlers
{
    public interface ICourseHandler<T> where T : ICommand
    {
        Task<ICommandResult> CourseHandle(T command);
    }
}