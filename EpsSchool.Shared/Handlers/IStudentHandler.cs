using System.Threading.Tasks;
using EpsSchool.Shared.Commands;

namespace EpsSchool.Shared.Handlers
{
    public interface IStudentHandler<T> where T : ICommand
    {
        Task<ICommandResult> StudentHandle(T command);
    }
}