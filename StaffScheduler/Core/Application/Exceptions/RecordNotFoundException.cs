using System.Runtime.Serialization;

namespace StaffScheduler.Core.Application.Exceptions
{
    [Serializable]
    public class RecordNotFoundException : Exception
    {
        protected RecordNotFoundException(SerializationInfo info, StreamingContext context) : base(info, context)
        {
        }

        public RecordNotFoundException(string message) : base(message)
        {
        }
    }

}
