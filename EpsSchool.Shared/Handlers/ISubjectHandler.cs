using System.Threading.Tasks;
using EpsSchool.Shared.Commands;

namespace EpsSchool.Shared.Handlers
{
    public interface ISubjectHandler<T> where T : ICommand
    {
        Task<ICommandResult> SubjectHandle(T command);
    }
}