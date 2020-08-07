namespace Resulter.AspNetCore
{
    using System.Collections.Generic;

    public class ErrorModel<TMessage>
    {
        public ErrorModel(IReadOnlyCollection<TMessage> errorMessages)
        {
            ErrorMessages = errorMessages;
        }

        public IReadOnlyCollection<TMessage> ErrorMessages { get; }
    }
}