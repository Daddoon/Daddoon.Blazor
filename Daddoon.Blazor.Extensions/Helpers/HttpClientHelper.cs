using Daddoon.Blazor.Services;
using Daddoon.Blazor.Services.Impl;
using System;
using System.Collections.Generic;
using System.Net.Http;
using System.Text;

namespace Daddoon.Blazor.Helpers
{
    public static class HttpClientHelper
    {
        /// <summary>
        /// Return the standard System.Net.HttpClient implementation, wrapped in the BaseHttpClient class
        /// </summary>
        /// <returns></returns>
        public static IHttpClient GetStandardImplementation(IServiceProvider serviceProvider)
        {
            var client = serviceProvider.GetService(typeof(HttpClient)) as HttpClient;
            return new BaseHttpClient(client);
        }

        /// <summary>
        /// Return the jQuery Ajax implementation (using jQuery 3.3.1)
        /// </summary>
        /// <returns></returns>
        public static IHttpClient GetjQueryImplementation(IServiceProvider serviceProvider)
        {
            var client = serviceProvider.GetService(typeof(HttpClient)) as HttpClient;
            return new jQueryHttpClient(client);
        }
    }
}
