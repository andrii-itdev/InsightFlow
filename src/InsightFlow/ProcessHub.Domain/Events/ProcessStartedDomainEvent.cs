using MediatR;

namespace ProcessHub.Domain.Events
{
    using ProcessHub.Domain.AggregatesModel;

    public class ProcessStartedDomainEvent : INotification
    {
        public Process Process { get; }

        public ProcessStartedDomainEvent(Process process)
        {
            Process = process;
        }
    }
}
