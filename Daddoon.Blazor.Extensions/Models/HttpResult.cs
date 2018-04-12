using System;
using System.Collections.Generic;
using System.Net;
using System.Text;

namespace Daddoon.Blazor.Models
{
    public class HttpResult
    {
        public HttpResult()
        {
            Code = HttpStatusCode.InternalServerError;
        }

        public HttpStatusCode Code { get; set; }

        public bool IsSuccessStatusCode {
            get
            {
                return ((int)Code >= 200) && ((int)Code <= 299);
            }
        }

        public bool Success { get; set; }

        public bool ClientError { get; set; }
    }

    public class HttpResult<T> : HttpResult
    {
        public T Data { get; set; }
    }
}
