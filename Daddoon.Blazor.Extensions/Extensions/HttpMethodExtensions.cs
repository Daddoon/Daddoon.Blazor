using System;
using System.Collections.Generic;
using System.Text;

namespace System.Net.Http
{
    public static class HttpMethodExtensions
    {
        public static string ToWebRequestMethods(this HttpMethod method)
        {
            if (method == HttpMethod.Delete)
                return "DELETE"; //Method DELETE not present on WebRequest
            else if (method == HttpMethod.Get)
                return WebRequestMethods.Http.Get;
            else if (method == HttpMethod.Head)
                return WebRequestMethods.Http.Head;
            else if (method == HttpMethod.Options)
                return "OPTIONS";
            else if (method == HttpMethod.Post)
                return WebRequestMethods.Http.Post;
            else if (method == HttpMethod.Put)
                return WebRequestMethods.Http.Put;
            else if (method == HttpMethod.Trace)
                return "TRACE";
            return null;
        }
    }
}
