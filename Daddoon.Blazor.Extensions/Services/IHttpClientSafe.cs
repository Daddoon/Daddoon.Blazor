using Daddoon.Blazor.Models;
using System;
using System.Collections.Generic;
using System.Net.Http;
using System.Net.Http.Headers;
using System.Text;
using System.Threading.Tasks;

namespace Daddoon.Blazor.Services
{
    public interface IHttpClientSafe
    {
        HttpRequestHeaders DefaultRequestHeaders { get; }
        Uri BaseAddress { get; set; }
        TimeSpan Timeout { get; set; }
        void CancelPendingRequests();

        #region Safe Methods

        Task<HttpResult<T>> GetJsonAsyncSafe<T>(Uri requestUri);
        Task<HttpResult<T>> GetJsonAsyncSafe<T>(string requestUri);
        Task<HttpResult> PostJsonAsyncSafe(Uri requestUri, object content);
        Task<HttpResult> PostJsonAsyncSafe(string requestUri, object content);
        Task<HttpResult<T>> PostJsonAsyncSafe<T>(Uri requestUri, object content);
        Task<HttpResult<T>> PostJsonAsyncSafe<T>(string requestUri, object content);
        Task<HttpResult> PutJsonAsyncSafe(Uri requestUri, object content);
        Task<HttpResult> PutJsonAsyncSafe(string requestUri, object content);
        Task<HttpResult<T>> PutJsonAsyncSafe<T>(Uri requestUri, object content);
        Task<HttpResult<T>> PutJsonAsyncSafe<T>(string requestUri, object content);
        Task<HttpResult> SendJsonAsyncSafe(HttpMethod method, Uri requestUri, object content);
        Task<HttpResult> SendJsonAsyncSafe(HttpMethod method, string requestUri, object content);
        Task<HttpResult<T>> SendJsonAsyncSafe<T>(HttpMethod method, Uri requestUri, object content);
        Task<HttpResult<T>> SendJsonAsyncSafe<T>(HttpMethod method, string requestUri, object content);
        Task<HttpResult<string>> GetStringAsyncSafe(Uri requestUri);
        Task<HttpResult<string>> GetStringAsyncSafe(string requestUri);

        #endregion
    }
}
