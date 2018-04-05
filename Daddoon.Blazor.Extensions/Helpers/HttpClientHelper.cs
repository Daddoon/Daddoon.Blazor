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
        /// Return the IHttpClient implementation
        /// Actually, return the standard behavior, and a some fallback behavior for Internet Explorer
        /// </summary>
        /// <returns></returns>
        public static IHttpClient GetImplementation(IServiceProvider serviceProvider)
        {
            var client = serviceProvider.GetService(typeof(HttpClient)) as HttpClient;

            //TODO: TO REMOVE DEBUG
            return new IEHttpClient(client);
            //TODO: TO REMOVE!!!

            //Initializing IHttpClient from Daddoon.Blazor
            if (Browser.Platform.BrowserFamily == BrowserFamily.InternetExplorer
                || Browser.Platform.BrowserFamily == BrowserFamily.InternetExplorer11)
            {
                Console.WriteLine("Internet Explorer detected, fallbacking some HttpClient implementation...");
                return new IEHttpClient(client);
            }
            else
            {
                return new BaseHttpClient(client);
            }
        }
    }
}
