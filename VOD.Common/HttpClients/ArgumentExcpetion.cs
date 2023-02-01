using System.Runtime.Serialization;

namespace VOD.Common.HttpClients
{
    [Serializable]
    internal class ArgumentExcpetion : Exception
    {
        public ArgumentExcpetion()
        {
        }

        public ArgumentExcpetion(string? message) : base(message)
        {
        }

        public ArgumentExcpetion(string? message, Exception? innerException) : base(message, innerException)
        {
        }

        protected ArgumentExcpetion(SerializationInfo info, StreamingContext context) : base(info, context)
        {
        }
    }
}