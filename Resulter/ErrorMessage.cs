namespace Resulter
{
    public class ErrorMessage
    {
        public ErrorMessage(string code, string? message)
        {
            Code = code;
            Message = message;
        }

        /// <summary>
        /// Gets error code.
        /// </summary>
        public string Code { get; }

        /// <summary>
        /// Gets error message description.
        /// </summary>
        public string? Message { get; }
    }
}