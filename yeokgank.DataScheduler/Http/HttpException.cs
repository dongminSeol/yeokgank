using System;
using System.Net;

namespace yeokgank.DataScheduler.Http
{
    class HttpException : Exception
    {
        public HttpStatusCode HttpCode { get; set; }
        public HttpException()
        {
        }

        public HttpException(string message): base(message)
        {
        }

        public HttpException(string message, Exception inner): base(message, inner)
        {
        }
    }
}
