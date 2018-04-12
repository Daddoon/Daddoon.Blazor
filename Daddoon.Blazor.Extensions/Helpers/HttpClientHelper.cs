using Daddoon.Blazor.Services;
using Daddoon.Blazor.Services.Impl;
using Microsoft.Extensions.DependencyInjection;
using System;
using System.Collections.Generic;
using System.Net.Http;
using System.Text;

namespace Daddoon.Blazor.Helpers
{
    public static class HttpClientHelper
    {
        private static void InitializeUriHelper(HttpClient client)
        {
            UriHelper.BaseAddress = client.BaseAddress.AbsoluteUri;
        }

        /// <summary>
        /// Add the standard System.Net.HttpClient implementation, wrapped in the BaseHttpClient class when calling IHttpClient interface in dependency services. The IHttpClientSafe interface implementation is also set in the depdency services
        /// </summary>
        /// <param name="serviceCollection"></param>
        public static void AddIHttpClientStandardImplementation(this IServiceCollection serviceCollection)
        {
            serviceCollection.Add(ServiceDescriptor.Singleton((option) => GetStandardImplementation(option)));
            serviceCollection.Add(ServiceDescriptor.Singleton<IHttpClientSafe>((option) => option.GetService(typeof(IHttpClient)) as IHttpClient));
        }

        /// <summary>
        /// Add the the jQuery Ajax implementation (using jQuery 3.3.1) . The IHttpClientSafe interface implementation is also set in the depdency services
        /// Warning: Not yet implemented method will implicitly fallback to the System.Net.HttpClient implementation
        /// 
        /// Supported implementations:
        /// - Task<string> GetStringAsync(Uri requestUri)
        /// - Task<string> GetStringAsync(string requestUri)
        /// - Task<T> GetJsonAsync<T>(string requestUri)
        /// - Task<T> PostJsonAsync<T>(string requestUri, object content)
        /// </summary>
        /// <param name="serviceCollection"></param>
        public static void AddIHttpClientJQueryImplementation(this IServiceCollection serviceCollection)
        {
            serviceCollection.Add(ServiceDescriptor.Singleton((option) => GetjQueryImplementation(option)));
            serviceCollection.Add(ServiceDescriptor.Singleton<IHttpClientSafe>((option) => option.GetService(typeof(IHttpClient)) as IHttpClient));
        }

        /// <summary>
        /// Return the standard System.Net.HttpClient implementation, wrapped in the BaseHttpClient class
        /// </summary>
        /// <returns></returns>
        public static IHttpClient GetStandardImplementation(IServiceProvider serviceProvider)
        {
            var client = serviceProvider.GetService(typeof(HttpClient)) as HttpClient;
            InitializeUriHelper(client);
            return new BaseHttpClient(client);
        }

        /// <summary>
        /// Return the jQuery Ajax implementation (using jQuery 3.3.1)
        /// Warning: Not yet implemented method will implicitly fallback to the System.Net.HttpClient implementation
        /// 
        /// Supported implementations:
        /// - Task<string> GetStringAsync(string requestUri)
        /// - Task<T> GetJsonAsync<T>(string requestUri)
        /// - Task<T> PostJsonAsync<T>(string requestUri, object content)
        /// - Task<T> PutJsonAsync<T>(string requestUri, object content)
        /// - Task<T> SendJsonAsync<T>(string requestUri, object content)
        /// - Task<string> GetStringAsyncSafe(string requestUri)
        /// - Task<T> GetJsonAsyncSafe<T>(string requestUri)
        /// - Task<T> PostJsonAsyncSafe<T>(string requestUri, object content)
        /// - Task<T> PutJsonAsyncSafe<T>(string requestUri, object content)
        /// - Task<T> SendJsonAsyncSafe<T>(string requestUri, object content)
        /// </summary>
        /// <returns></returns>
        public static IHttpClient GetjQueryImplementation(IServiceProvider serviceProvider)
        {
            var client = serviceProvider.GetService(typeof(HttpClient)) as HttpClient;
            InitializeUriHelper(client);
            return new jQueryHttpClient(client);
        }
    }
}
