using System.Runtime.Serialization;

namespace StaffScheduler.Core.Application.Exceptions
{
    [Serializable]
    public class UserExistException : Exception
    {
        protected UserExistException(SerializationInfo info, StreamingContext context) : base(info, context)
        {
        }

        public UserExistException(string message) : base(message)
        {
        }
    }

}
