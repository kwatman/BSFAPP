using System;
using System.Collections.Generic;
using System.Net;
using System.Net.Http;
using System.Text;

namespace Imi.Project.Mobile.Core.Exceptions
{
    public class CustomHttpRequestException: HttpRequestException
    {
        public HttpStatusCode HttpCode { get; }

        public CustomHttpRequestException(HttpStatusCode statusCode) : this(statusCode, null, null)
        {
        }

        public CustomHttpRequestException(HttpStatusCode statusCode, string message) : this(statusCode, message, null)
        {
        }

        public CustomHttpRequestException(HttpStatusCode statusCode, string message, Exception inner) : base(message, inner)
        {
            HttpCode = statusCode;
        }
    }
}
