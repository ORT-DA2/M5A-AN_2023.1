using System;
namespace Uyflix.Exceptions
{
    public class BusinessLogicException : Exception
    {
        public int Code { get; set; }

        public BusinessLogicException() : base()
        {

        }

        public BusinessLogicException(string message) : base(message)
        {

        }

        public BusinessLogicException(string message, Exception innerException) : base(message, innerException)
        {

        }

        public BusinessLogicException(string message, int code, Exception innerException) : base(message, innerException)
        {
            this.Code = code;
        }
    }
}
