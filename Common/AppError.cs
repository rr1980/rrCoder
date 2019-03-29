using System;

namespace Common
{
    public class AppError : Exception
    {
        public string ClassName
        {
            get
            {
                return this.GetType().Name;
            }
        }
        public int StatusCode { get; set; }
        public DateTime Time { get; set; }
        public Exception Exception { get; set; }

        public AppError(string message, Exception inner, int statusCode) : base(message, inner)
        {
            Time = DateTime.Now;
            StatusCode = statusCode;
        }
    }

    public class LoginError : Exception
    {
        public LoginError(string message) : base(message)
        {

        }
    }
}
