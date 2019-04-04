using System;
using System.Net;

namespace Common
{
    public abstract class AppError : Exception
    {
        public HttpStatusCode StatusCode { get; set; } = HttpStatusCode.InternalServerError;
        public DateTime Time { get; set; }

        public AppError(string message, HttpStatusCode statusCode = HttpStatusCode.InternalServerError) : base(message)
        {
            Time = DateTime.Now;
            StatusCode = statusCode;
        }
    }

    public class ForbiddenError : AppError
    {
        public ForbiddenError(string message) : base(message, HttpStatusCode.Forbidden)
        {
        }
    }

    public class UnauthorizedError : AppError
    {
        public UnauthorizedError(string message) : base(message, HttpStatusCode.Unauthorized)
        {
        }
    }
}

