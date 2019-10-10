namespace OmniWallet.Api.Exceptions
{
    public class ValidationException : AppException
    {
        public ValidationException(string message, string property = null) : base(message)
        {
            Property = property ?? string.Empty;
        }

        public string Property { get; }
    }
}