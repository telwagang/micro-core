
using System;
using System.Diagnostics;
using System.Net;
using System.Net.Http;

namespace Micro_core.DataLayer.Attributes
{
    public class MicroException : Exception
    {
        private readonly HttpStatusCode statusCode;

        public MicroException(HttpStatusCode statusCode, string message, Exception ex)
            : base(message, ex)
        {
            this.statusCode = statusCode;
        }

        public MicroException(HttpStatusCode statusCode, string message)
            : base(message)
        {
            this.statusCode = statusCode;
        }

        public MicroException(HttpStatusCode statusCode)
        {
            this.statusCode = statusCode;
        }

        public HttpStatusCode StatusCode
        {
            get { return this.statusCode; }
        }
    }
}