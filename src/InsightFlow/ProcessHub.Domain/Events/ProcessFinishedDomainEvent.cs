using MediatR;

namespace ProcessHub.Domain.Events
{
    using ProcessHub.Domain.AggregatesModel;

    internal class ProcessFinishedDomainEvent : INotification
    {
        public Process Process { get; }

        public ProcessFinishedDomainEvent(Process process) 
        {
            Process = process;
        }
    }
}
