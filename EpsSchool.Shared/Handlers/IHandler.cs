using System.Threading.Tasks;
using EpsSchool.Shared.Commands;

namespace EpsSchool.Shared.Handlers
{
    public interface IHandler<T> where T : ICommand
    {
        Task<ICommandResult> Handle(T command);
    }
}