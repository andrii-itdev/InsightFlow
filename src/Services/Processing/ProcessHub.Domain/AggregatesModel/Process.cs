using System.Reflection.Metadata;

namespace ProcessHub.Domain.AggregatesModel
{
    public class Process
    {
        public ProcessStatus Status { get; set; }

        public Process()
        {
            Status = ProcessStatus.Initiated;
        }
    }
}
