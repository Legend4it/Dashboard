using System.Runtime.Serialization;


namespace Dashboard.Logger
{
    [Serializable]
    public class AppVersionInfoException : Exception
    {
        public AppVersionInfoException() { }

        public AppVersionInfoException(string? message) : base(message) { }

        public AppVersionInfoException(string? message, Exception? innerException) : base(message, innerException) { }

        protected AppVersionInfoException(SerializationInfo info, StreamingContext context) : base(info, context) { }
    }
}
