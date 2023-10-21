using Infrastructure;
using System.Diagnostics.CodeAnalysis;

namespace ProcessHub.Domain.AggregatesModel
{
    public sealed record class ProcessStatus : Enumeration<int>
    {
        public static readonly ProcessStatus Initiated = new ProcessStatus(1, nameof(Initiated));
        public static readonly ProcessStatus Running = new ProcessStatus(2, nameof(Running));
        public static readonly ProcessStatus Completed = new ProcessStatus(4, nameof(Completed));
        public static readonly ProcessStatus Cancelled = new ProcessStatus(4, nameof(Cancelled));

        private ProcessStatus(int id, [NotNull] string name) : base(id, name)
        {
        }
    }
}
