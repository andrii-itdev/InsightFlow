using System;

namespace DataManagement.Infrastructure.Exceptions
{
    internal class NoRecordsFoundException<T> : Exception
    {
        internal NoRecordsFoundException(T id) : base($"No records found for id \"{id}\"")
        {
        }
    }
}
