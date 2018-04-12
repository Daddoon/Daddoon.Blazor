// Copyright (c) .NET Foundation. All rights reserved.
// Licensed under the Apache License, Version 2.0. See License.txt in the project root for license information.

using Daddoon.Blazor.Models;
using Microsoft.AspNetCore.Blazor;
using System;
using System.Net.Http;
using System.Text;
using System.Threading.Tasks;

namespace Daddoon.Blazor
{
    /// <summary>
    /// Extension methods for working with JSON APIs.
    /// </summary>
    public static class HttpClientJsonSafeExtensions
    {
        /// <summary>
        /// Sends a GET request to the specified URI, and parses the JSON response body
        /// to create an object of the generic type.
        /// </summary>
        /// <typeparam name="T">A type into which the response body can be JSON-deserialized.</typeparam>
        /// <param name="httpClient">The <see cref="HttpClient"/>.</param>
        /// <param name="requestUri">The URI that the request will be sent to.</param>
        /// <returns>The response parsed as an object of the generic type.</returns>
        public static Task<HttpResult<T>> GetJsonAsyncSafe<T>(this HttpClient httpClient, string requestUri)
            => httpClient.GetJsonAsyncSafe<T>(Daddoon.Blazor.Helpers.UriHelper.GetUri(requestUri));

        /// <summary>
        /// Sends a GET request to the specified URI, and parses the JSON response body
        /// to create an object of the generic type.
        /// </summary>
        /// <typeparam name="T">A type into which the response body can be JSON-deserialized.</typeparam>
        /// <param name="httpClient">The <see cref="HttpClient"/>.</param>
        /// <param name="requestUri">The URI that the request will be sent to.</param>
        /// <returns>The response parsed as an object of the generic type.</returns>
        public static Task<HttpResult<T>> GetJsonAsyncSafe<T>(this HttpClient httpClient, Uri requestUri)
            => httpClient.SendJsonAsyncSafe<T>(HttpMethod.Get, requestUri, new object());

        /// <summary>
        /// Sends a POST request to the specified URI, including the specified <paramref name="content"/>
        /// in JSON-encoded format, and parses the JSON response body to create an object of the generic type.
        /// </summary>
        /// <typeparam name="T">A type into which the response body can be JSON-deserialized.</typeparam>
        /// <param name="httpClient">The <see cref="HttpClient"/>.</param>
        /// <param name="requestUri">The URI that the request will be sent to.</param>
        /// <param name="content">Content for the request body. This will be JSON-encoded and sent as a string.</param>
        /// <returns>The response parsed as an object of the generic type.</returns>
        public static async Task<HttpResult> PostJsonAsyncSafe(this HttpClient httpClient, string requestUri, object content)
            => await httpClient.PostJsonAsyncSafe<IgnoreResponse>(Daddoon.Blazor.Helpers.UriHelper.GetUri(requestUri), content);

        /// <summary>
        /// Sends a POST request to the specified URI, including the specified <paramref name="content"/>
        /// in JSON-encoded format, and parses the JSON response body to create an object of the generic type.
        /// </summary>
        /// <typeparam name="T">A type into which the response body can be JSON-deserialized.</typeparam>
        /// <param name="httpClient">The <see cref="HttpClient"/>.</param>
        /// <param name="requestUri">The URI that the request will be sent to.</param>
        /// <param name="content">Content for the request body. This will be JSON-encoded and sent as a string.</param>
        /// <returns>The response parsed as an object of the generic type.</returns>
        public static async Task<HttpResult> PostJsonAsyncSafe(this HttpClient httpClient, Uri requestUri, object content)
            => await httpClient.SendJsonAsyncSafe<IgnoreResponse>(HttpMethod.Post, requestUri, content);

        /// <summary>
        /// Sends a POST request to the specified URI, including the specified <paramref name="content"/>
        /// in JSON-encoded format, and parses the JSON response body to create an object of the generic type.
        /// </summary>
        /// <typeparam name="T">A type into which the response body can be JSON-deserialized.</typeparam>
        /// <param name="httpClient">The <see cref="HttpClient"/>.</param>
        /// <param name="requestUri">The URI that the request will be sent to.</param>
        /// <param name="content">Content for the request body. This will be JSON-encoded and sent as a string.</param>
        /// <returns>The response parsed as an object of the generic type.</returns>
        public static Task<HttpResult<T>> PostJsonAsyncSafe<T>(this HttpClient httpClient, string requestUri, object content)
            => httpClient.PostJsonAsyncSafe<T>(Daddoon.Blazor.Helpers.UriHelper.GetUri(requestUri), content);

        /// <summary>
        /// Sends a POST request to the specified URI, including the specified <paramref name="content"/>
        /// in JSON-encoded format, and parses the JSON response body to create an object of the generic type.
        /// </summary>
        /// <typeparam name="T">A type into which the response body can be JSON-deserialized.</typeparam>
        /// <param name="httpClient">The <see cref="HttpClient"/>.</param>
        /// <param name="requestUri">The URI that the request will be sent to.</param>
        /// <param name="content">Content for the request body. This will be JSON-encoded and sent as a string.</param>
        /// <returns>The response parsed as an object of the generic type.</returns>
        public static Task<HttpResult<T>> PostJsonAsyncSafe<T>(this HttpClient httpClient, Uri requestUri, object content)
            => httpClient.SendJsonAsyncSafe<T>(HttpMethod.Post, requestUri, content);

        /// <summary>
        /// Sends a PUT request to the specified URI, including the specified <paramref name="content"/>
        /// in JSON-encoded format.
        /// </summary>
        /// <param name="httpClient">The <see cref="HttpClient"/>.</param>
        /// <param name="requestUri">The URI that the request will be sent to.</param>
        /// <param name="content">Content for the request body. This will be JSON-encoded and sent as a string.</param>
        public static async Task<HttpResult> PutJsonAsyncSafe(this HttpClient httpClient, string requestUri, object content)
            => await httpClient.PutJsonAsyncSafe(Daddoon.Blazor.Helpers.UriHelper.GetUri(requestUri), content);

        /// <summary>
        /// Sends a PUT request to the specified URI, including the specified <paramref name="content"/>
        /// in JSON-encoded format.
        /// </summary>
        /// <param name="httpClient">The <see cref="HttpClient"/>.</param>
        /// <param name="requestUri">The URI that the request will be sent to.</param>
        /// <param name="content">Content for the request body. This will be JSON-encoded and sent as a string.</param>
        public static async Task<HttpResult> PutJsonAsyncSafe(this HttpClient httpClient, Uri requestUri, object content)
            => await httpClient.SendJsonAsyncSafe<IgnoreResponse>(HttpMethod.Put, requestUri, content);

        /// <summary>
        /// Sends a PUT request to the specified URI, including the specified <paramref name="content"/>
        /// in JSON-encoded format, and parses the JSON response body to create an object of the generic type.
        /// </summary>
        /// <typeparam name="T">A type into which the response body can be JSON-deserialized.</typeparam>
        /// <param name="httpClient">The <see cref="HttpClient"/>.</param>
        /// <param name="requestUri">The URI that the request will be sent to.</param>
        /// <param name="content">Content for the request body. This will be JSON-encoded and sent as a string.</param>
        /// <returns>The response parsed as an object of the generic type.</returns>
        public static Task<HttpResult<T>> PutJsonAsyncSafe<T>(this HttpClient httpClient, string requestUri, object content)
            => httpClient.PutJsonAsyncSafe<T>(Daddoon.Blazor.Helpers.UriHelper.GetUri(requestUri), content);

        /// <summary>
        /// Sends a PUT request to the specified URI, including the specified <paramref name="content"/>
        /// in JSON-encoded format, and parses the JSON response body to create an object of the generic type.
        /// </summary>
        /// <typeparam name="T">A type into which the response body can be JSON-deserialized.</typeparam>
        /// <param name="httpClient">The <see cref="HttpClient"/>.</param>
        /// <param name="requestUri">The URI that the request will be sent to.</param>
        /// <param name="content">Content for the request body. This will be JSON-encoded and sent as a string.</param>
        /// <returns>The response parsed as an object of the generic type.</returns>
        public static Task<HttpResult<T>> PutJsonAsyncSafe<T>(this HttpClient httpClient, Uri requestUri, object content)
            => httpClient.SendJsonAsyncSafe<T>(HttpMethod.Put, requestUri, content);

        /// <summary>
        /// Sends an HTTP request to the specified URI, including the specified <paramref name="content"/>
        /// in JSON-encoded format.
        /// </summary>
        /// <param name="httpClient">The <see cref="HttpClient"/>.</param>
        /// <param name="method">The HTTP method.</param>
        /// <param name="requestUri">The URI that the request will be sent to.</param>
        /// <param name="content">Content for the request body. This will be JSON-encoded and sent as a string.</param>
        public static async Task<HttpResult> SendJsonAsyncSafe(this HttpClient httpClient, HttpMethod method, string requestUri, object content)
            => await httpClient.SendJsonAsyncSafe<IgnoreResponse>(method, Daddoon.Blazor.Helpers.UriHelper.GetUri(requestUri), content);

        /// <summary>
        /// Sends an HTTP request to the specified URI, including the specified <paramref name="content"/>
        /// in JSON-encoded format.
        /// </summary>
        /// <param name="httpClient">The <see cref="HttpClient"/>.</param>
        /// <param name="method">The HTTP method.</param>
        /// <param name="requestUri">The URI that the request will be sent to.</param>
        /// <param name="content">Content for the request body. This will be JSON-encoded and sent as a string.</param>
        public static async Task<HttpResult> SendJsonAsyncSafe(this HttpClient httpClient, HttpMethod method, Uri requestUri, object content)
            => await httpClient.SendJsonAsyncSafe<IgnoreResponse>(method, requestUri, content);

        /// <summary>
        /// Sends an HTTP request to the specified URI, including the specified <paramref name="content"/>
        /// in JSON-encoded format, and parses the JSON response body to create an object of the generic type.
        /// </summary>
        /// <typeparam name="T">A type into which the response body can be JSON-deserialized.</typeparam>
        /// <param name="httpClient">The <see cref="HttpClient"/>.</param>
        /// <param name="method">The HTTP method.</param>
        /// <param name="requestUri">The URI that the request will be sent to.</param>
        /// <param name="content">Content for the request body. This will be JSON-encoded and sent as a string.</param>
        /// <returns>The response parsed as an object of the generic type.</returns>
        public static Task<HttpResult<T>> SendJsonAsyncSafe<T>(this HttpClient httpClient, HttpMethod method, string requestUri, object content) => httpClient.SendJsonAsyncSafe<T>(method, Daddoon.Blazor.Helpers.UriHelper.GetUri(requestUri), content);

        /// <summary>
        /// Sends an HTTP request to the specified URI, including the specified <paramref name="content"/>
        /// in JSON-encoded format, and parses the JSON response body to create an object of the generic type.
        /// </summary>
        /// <typeparam name="T">A type into which the response body can be JSON-deserialized.</typeparam>
        /// <param name="httpClient">The <see cref="HttpClient"/>.</param>
        /// <param name="method">The HTTP method.</param>
        /// <param name="requestUri">The URI that the request will be sent to.</param>
        /// <param name="content">Content for the request body. This will be JSON-encoded and sent as a string.</param>
        /// <returns>The response parsed as an object of the generic type.</returns>
        public static async Task<HttpResult<T>> SendJsonAsyncSafe<T>(this HttpClient httpClient, HttpMethod method, Uri requestUri, object content)
        {
            HttpResult<T> result = new HttpResult<T>();

            HttpResponseMessage response = null;

            try
            {
                var requestJson = JsonUtil.Serialize(content);
                response = await httpClient.SendAsync(new HttpRequestMessage(method, requestUri)
                {
                    Content = new StringContent(requestJson, Encoding.UTF8, "application/json")
                });

                result.Code = response.StatusCode;
                result.Success = true;

                if (typeof(T) == typeof(IgnoreResponse))
                {
                    return result;
                }
                else
                {
                    var responseJson = await response.Content.ReadAsStringAsync();
                    result.Data = JsonUtil.Deserialize<T>(responseJson);
                    return result;
                }
            }
            catch (System.Exception)
            {
                result.Success = false;

                if (response != null)
                {
                    result.Code = response.StatusCode;
                    result.ClientError = true;
                }

                return result;
            }
        }

        public static Task<HttpResult<string>> GetStringAsyncSafe(this HttpClient httpClient, string requestUri)
            => httpClient.GetStringAsyncSafe(Daddoon.Blazor.Helpers.UriHelper.GetUri(requestUri));

        public static async Task<HttpResult<string>> GetStringAsyncSafe(this HttpClient httpClient, Uri requestUri)
        {
            HttpResult<string> result = new HttpResult<string>();

            HttpResponseMessage response = null;

            try
            {
                response = await httpClient.SendAsync(new HttpRequestMessage(HttpMethod.Get, requestUri));

                result.Code = response.StatusCode;
                result.Success = true;

                result.Data = await response.Content.ReadAsStringAsync();
                return result;
            }
            catch (System.Exception)
            {
                result.Success = false;

                if (response != null)
                {
                    result.Code = response.StatusCode;
                    result.ClientError = true;
                }

                return result;
            }
        }

        class IgnoreResponse { }
    }
}
