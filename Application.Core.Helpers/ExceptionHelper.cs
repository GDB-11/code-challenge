namespace Application.Core.Helpers
{
    public class CustomGenericException : Exception
    {
        public CustomGenericException(string message) : base(message) { }
    }

    public class AuthException : Exception
    {
        public AuthException(string message) : base(message) { }
    }

    public class AccessException : Exception
    {
        public AccessException(string message) : base(message) { }
    }

    public class RequestException : Exception
    {
        public RequestException(string message) : base(message) { }
    }
}
