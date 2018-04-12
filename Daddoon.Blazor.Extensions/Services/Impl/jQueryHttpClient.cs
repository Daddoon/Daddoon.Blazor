using Daddoon.Blazor.Models;
using Daddoon.Blazor.Services.Impl.Internal;
using Microsoft.AspNetCore.Blazor;
using Microsoft.AspNetCore.Blazor.Browser.Interop;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Threading.Tasks;

namespace Daddoon.Blazor.Services.Impl
{
    public class jQueryHttpClient : BaseHttpClient
    {
        static class ContentType
        {
            /// <summary>
            /// Is application/x-www-form-urlencoded
            /// </summary>
            public const string Default = "application/x-www-form-urlencoded; charset=UTF-8";

            public const string Json = "application/json; charset=UTF-8";
        }

        class RequestMetadata
        {
            public RequestMetadata()
            {
                contentType = ContentType.Default;
            }

            public double timeout { get; set; }
            public string contentType { get; set; }
        }

        public jQueryHttpClient(HttpClient http) : base(http)
        {
        }

        #region NOT SAFE METHODS

        public override Task<T> GetJsonAsync<T>(string requestUri)
        {
            return SendJsonAsync<T>(HttpMethod.Get, requestUri, null);
        }

        public override Task PostJsonAsync(string requestUri, object content)
        {
            return SendJsonAsync(HttpMethod.Post, requestUri, content);
        }

        public override Task<T> PostJsonAsync<T>(string requestUri, object content)
        {
            return SendJsonAsync<T>(HttpMethod.Post, requestUri, content);
        }

        public override Task PutJsonAsync(string requestUri, object content)
        {
            return SendJsonAsync(HttpMethod.Put, requestUri, content);
        }

        public override Task<T> PutJsonAsync<T>(string requestUri, object content)
        {
            return SendJsonAsync<T>(HttpMethod.Put, requestUri, content);
        }

        public override Task SendJsonAsync(HttpMethod method, string requestUri, object content)
        {
            return SendJsonAsyncSafe(method, requestUri, content);
        }

        public override async Task<T> SendJsonAsync<T>(HttpMethod method, string requestUri, object content)
        {
            var result = await SendJsonAsyncSafe<T>(method, requestUri, content);
            if (result == null || result.IsSuccessStatusCode == false)
            {
                throw new HttpRequestException();
            }

            return result.Data;
        }

        public override Task<string> GetStringAsync(string requestUri)
        {
            Uri request = Daddoon.Blazor.Helpers.UriHelper.GetUri(requestUri);
            return GetStringAsync(request);
        }

        public override Task<string> GetStringAsync(Uri requestUri)
        {
            if (requestUri == null)
                return null;

            string absoluteURI = string.Empty;

            if (requestUri.IsAbsoluteUri)
                absoluteURI = requestUri.AbsoluteUri;
            else
                absoluteURI = BaseAddress + requestUri.PathAndQuery;

            int id = TaskDispatcher.CreateTaskToDispatch(TaskDispatcher.CommonTask.StringToCSharp(), out Task<string> futurTask);

            RegisteredFunction.Invoke<string>("daddoon_jQuery_SendAsync", id, WebRequestMethods.Http.Get, absoluteURI, new RequestMetadata()
            {
                timeout = Timeout.TotalMilliseconds
            }, null);
            return futurTask;
        }

        #endregion

        #region SAFE METHODS

        public override Task<HttpResult<T>> GetJsonAsyncSafe<T>(string requestUri)
        {
            return GetJsonAsyncSafe<T>(Daddoon.Blazor.Helpers.UriHelper.GetUri(requestUri));
        }

        public override Task<HttpResult<T>> GetJsonAsyncSafe<T>(Uri requestUri)
        {
            return SendJsonAsyncSafe<T>(HttpMethod.Get, requestUri, null);
        }

        public override Task<HttpResult> PostJsonAsyncSafe(string requestUri, object content)
        {
            return PostJsonAsyncSafe(Daddoon.Blazor.Helpers.UriHelper.GetUri(requestUri), content);
        }

        public override async Task<HttpResult> PostJsonAsyncSafe(Uri requestUri, object content)
        {
            return await PostJsonAsyncSafe<IgnoreResponse>(requestUri, content);
        }

        public override Task<HttpResult<T>> PostJsonAsyncSafe<T>(string requestUri, object content)
        {
            return PostJsonAsyncSafe<T>(Daddoon.Blazor.Helpers.UriHelper.GetUri(requestUri), content);
        }

        public override Task<HttpResult<T>> PostJsonAsyncSafe<T>(Uri requestUri, object content)
        {
            return SendJsonAsyncSafe<T>(HttpMethod.Post, requestUri, content);
        }

        public override Task<HttpResult> PutJsonAsyncSafe(string requestUri, object content)
        {
            return PutJsonAsyncSafe(Daddoon.Blazor.Helpers.UriHelper.GetUri(requestUri), content);
        }

        public override async Task<HttpResult> PutJsonAsyncSafe(Uri requestUri, object content)
        {
            return await PutJsonAsyncSafe<IgnoreResponse>(requestUri, content);
        }

        public override Task<HttpResult<T>> PutJsonAsyncSafe<T>(string requestUri, object content)
        {
            return PutJsonAsyncSafe<T>(Daddoon.Blazor.Helpers.UriHelper.GetUri(requestUri), content);
        }

        public override Task<HttpResult<T>> PutJsonAsyncSafe<T>(Uri requestUri, object content)
        {
            return SendJsonAsyncSafe<T>(HttpMethod.Put, requestUri, content);
        }

        public override Task<HttpResult> SendJsonAsyncSafe(HttpMethod method, string requestUri, object content)
        {
            return SendJsonAsyncSafe(method, Daddoon.Blazor.Helpers.UriHelper.GetUri(requestUri), content);
        }

        public override async Task<HttpResult> SendJsonAsyncSafe(HttpMethod method, Uri requestUri, object content)
        {
            return await SendJsonAsyncSafe<IgnoreResponse>(method, requestUri, content);
        }

        public override Task<HttpResult<T>> SendJsonAsyncSafe<T>(HttpMethod method, string requestUri, object content)
        {
            return SendJsonAsyncSafe<T>(method, Daddoon.Blazor.Helpers.UriHelper.GetUri(requestUri), content);
        }

        private string RequestUriDetermination(Uri requestUri)
        {
            string absoluteURI = string.Empty;

            if (requestUri.IsAbsoluteUri)
            {
                absoluteURI = requestUri.AbsoluteUri;
            }
            else
            {
                absoluteURI = BaseAddress + requestUri.Query;
            }

            return absoluteURI;
        }

        public override Task<HttpResult<T>> SendJsonAsyncSafe<T>(HttpMethod method, Uri requestUri, object content)
        {
            var failedHttpResult = new HttpResult<T>()
            {
                ClientError = true
            };

            Task<HttpResult<T>> failedTask = Task.FromResult(failedHttpResult);

            if (requestUri == null)
                return failedTask;

            try
            {
                string absoluteURI = RequestUriDetermination(requestUri);

                string contentJSON = null;

                if (content != null)
                    contentJSON = JsonUtil.Serialize(content);

                int id = TaskDispatcher.CreateTaskToDispatch(TaskDispatcher.CommonTask.JsonToCSharpSafe<T>(), out Task<HttpResult<T>> futurTask);

                RegisteredFunction.Invoke<string>("daddoon_jQuery_SendAsync", id, method.ToWebRequestMethods(), absoluteURI, new RequestMetadata()
                {
                    contentType = ContentType.Json,
                    timeout = Timeout.TotalMilliseconds
                }, contentJSON);
                return futurTask;
            }
            catch (Exception ex)
            {
                ExceptionLogger.LogException(ex);

                //In case of premature exception
                return failedTask;
            }
        }

        public override Task<HttpResult<string>> GetStringAsyncSafe(string requestUri)
        {
            return GetStringAsyncSafe(Daddoon.Blazor.Helpers.UriHelper.GetUri(requestUri));
        }

        public override Task<HttpResult<string>> GetStringAsyncSafe(Uri requestUri)
        {
            if (requestUri == null)
                return null;

            string absoluteURI = RequestUriDetermination(requestUri);

            int id = TaskDispatcher.CreateTaskToDispatch(TaskDispatcher.CommonTask.StringToCSharpSafe(), out Task<HttpResult<string>> futurTask);

            RegisteredFunction.Invoke<string>("daddoon_jQuery_SendAsync", id, WebRequestMethods.Http.Get, absoluteURI, new RequestMetadata()
            {
                contentType = ContentType.Default,
                timeout = Timeout.TotalMilliseconds
            }, null);
            return futurTask;
        }

        #endregion
    }
}
