using System;

namespace Common
{
    public class AppError : Exception
    {
        public int StatusCode { get; set; }
        public DateTime Time { get; set; }
        public Exception Exception { get; set; }

        public string ErrorType { get; set; }

        public AppError(string message) : base(message)
        {
            Time = DateTime.Now;
        }

        public AppError(string message, Exception inner) : base(message, inner)
        {
            Time = DateTime.Now;
        }

        public AppError(string message, Exception inner, int statusCode) : base(message, inner)
        {
            Time = DateTime.Now;
            StatusCode = statusCode;
        }
    }

    public abstract class BaseError : Exception
    {
        public string Name { get; set; }
        public string ErrorType { get; set; }

        public BaseError() { }

        public BaseError(string message, string name, string errorType) : base(message)
        {
            Name = name;
            ErrorType = errorType;
        }
    }

    public class ForbiddenError : BaseError
    {
        public ForbiddenError(string message) : base(message, "Auth failure", "UserError")
        {

        }
    }
}
