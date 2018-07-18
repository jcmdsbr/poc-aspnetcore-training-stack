using MediatR;

namespace Domain.Core.Events
{
    public abstract class Message : INotification
    {
        protected Message()
        {
            MessageType = GetType().Name;
        }

        public string MessageType { get; }
    }
}