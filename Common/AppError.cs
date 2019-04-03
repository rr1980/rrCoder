using System;
using System.Net;

namespace Common
{
    public abstract class AppError : Exception
    {
        public HttpStatusCode StatusCode { get; set; } = HttpStatusCode.InternalServerError;
        public DateTime Time { get; set; }
        public bool ShoeAlert { get; set; } = true;

        public AppError(string message, HttpStatusCode statusCode = HttpStatusCode.InternalServerError, bool showAlert = true) : base(message)
        {
            Time = DateTime.Now;
            StatusCode = statusCode;
            ShoeAlert = showAlert;
        }
    }


    public class ForbiddenError : AppError
    {

        public ForbiddenError(string message, bool showAlert = true) : base(message, HttpStatusCode.Forbidden, showAlert)
        {
        }
    }

    public class UnauthorizedError : AppError
    {

        public UnauthorizedError(string message) : base(message, HttpStatusCode.Unauthorized, false)
        {
        }
    }
}


//public abstract class BaseError : Exception
//{

//    public BaseError() { }

//    {
//        //Name = name;
//        ShoeAlert = showAlert;
//    }
//}

//    public abstract class StatusCodeError : AppError
//{
//        public HttpStatusCode StatusCode { get; protected set; } = HttpStatusCode.InternalServerError;

//        public StatusCodeError(string message, HttpStatusCode statusCode, bool showAlert = true) : base(message, showAlert)
//        {
//            StatusCode = statusCode;
//        }
//    }
