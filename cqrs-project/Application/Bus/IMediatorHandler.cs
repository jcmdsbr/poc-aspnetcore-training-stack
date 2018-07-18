using System.Threading.Tasks;
using Domain.Core.Commands;
using Domain.Core.Events;

namespace Application.Bus
{
    public interface IMediatorHandler
    {
        Task SendCommand<T>(T command) where T : Command;
        Task RaiseEvent<T>(T @event) where T : Event;
    }
}