using System.Threading.Tasks;
using EpsSchool.Shared.Commands;

namespace EpsSchool.Shared.Handlers
{
    public interface ITeacherHandler<T> where T : ICommand
    {
        Task<ICommandResult> TeacherHandle(T command);
    }
}