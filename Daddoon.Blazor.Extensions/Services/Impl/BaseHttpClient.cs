using Daddoon.Blazor.Models;
using Daddoon.Blazor.Services.Impl.Internal;
using Microsoft.AspNetCore.Blazor;
using System;
using System.IO;
using System.Net.Http;
using System.Net.Http.Headers;
using System.Threading;
using System.Threading.Tasks;

namespace Daddoon.Blazor.Services.Impl
{
    public class BaseHttpClient : IHttpClient
    {
        protected HttpClient _http;
        public BaseHttpClient(HttpClient http)
        {
            _http = http;
        }

        public virtual HttpRequestHeaders DefaultRequestHeaders => _http.DefaultRequestHeaders;

        public virtual Uri BaseAddress { get { return _http.BaseAddress; } set { _http.BaseAddress = value; } }
        public virtual long MaxResponseContentBufferSize { get { return _http.MaxResponseContentBufferSize; } set { _http.MaxResponseContentBufferSize = value; } }
        public virtual TimeSpan Timeout { get { return _http.Timeout; } set { _http.Timeout = value; } }

        public virtual void CancelPendingRequests()
        {
            _http.CancelPendingRequests();
        }

        public virtual Task<HttpResponseMessage> DeleteAsync(Uri requestUri, CancellationToken cancellationToken)
        {
            return _http.DeleteAsync(requestUri, cancellationToken);
        }

        public virtual Task<HttpResponseMessage> DeleteAsync(string requestUri, CancellationToken cancellationToken)
        {
            return _http.DeleteAsync(requestUri, cancellationToken);
        }

        public virtual Task<HttpResponseMessage> DeleteAsync(string requestUri)
        {
            return _http.DeleteAsync(requestUri);
        }

        public virtual Task<HttpResponseMessage> DeleteAsync(Uri requestUri)
        {
            return _http.DeleteAsync(requestUri);
        }

        public virtual void Dispose()
        {
            _http.Dispose();
        }

        public virtual Task<HttpResponseMessage> GetAsync(string requestUri)
        {
            return _http.GetAsync(requestUri);
        }

        public virtual Task<HttpResponseMessage> GetAsync(string requestUri, HttpCompletionOption completionOption)
        {
            return _http.GetAsync(requestUri, completionOption);
        }

        public virtual Task<HttpResponseMessage> GetAsync(string requestUri, HttpCompletionOption completionOption, CancellationToken cancellationToken)
        {
            return _http.GetAsync(requestUri, completionOption, cancellationToken);
        }

        public virtual Task<HttpResponseMessage> GetAsync(string requestUri, CancellationToken cancellationToken)
        {
            return _http.GetAsync(requestUri, cancellationToken);
        }

        public virtual Task<HttpResponseMessage> GetAsync(Uri requestUri)
        {
            return _http.GetAsync(requestUri);
        }

        public virtual Task<HttpResponseMessage> GetAsync(Uri requestUri, HttpCompletionOption completionOption)
        {
            return _http.GetAsync(requestUri, completionOption);
        }

        public virtual Task<HttpResponseMessage> GetAsync(Uri requestUri, HttpCompletionOption completionOption, CancellationToken cancellationToken)
        {
            return _http.GetAsync(requestUri, completionOption, cancellationToken);
        }

        public virtual Task<HttpResponseMessage> GetAsync(Uri requestUri, CancellationToken cancellationToken)
        {
            return _http.GetAsync(requestUri, cancellationToken);
        }

        public virtual Task<byte[]> GetByteArrayAsync(string requestUri)
        {
            return _http.GetByteArrayAsync(requestUri);
        }

        public virtual Task<byte[]> GetByteArrayAsync(Uri requestUri)
        {
            return _http.GetByteArrayAsync(requestUri);
        }

        public virtual Task<T> GetJsonAsync<T>(string requestUri)
        {
            return _http.GetJsonAsync<T>(requestUri);
        }

        public virtual Task<Stream> GetStreamAsync(string requestUri)
        {
            return _http.GetStreamAsync(requestUri);
        }

        public virtual Task<Stream> GetStreamAsync(Uri requestUri)
        {
            return _http.GetStreamAsync(requestUri);
        }

        public virtual Task<string> GetStringAsync(string requestUri)
        {
            return _http.GetStringAsync(requestUri);
        }

        public virtual Task<string> GetStringAsync(Uri requestUri)
        {
            return _http.GetStringAsync(requestUri);
        }

        public virtual Task<HttpResponseMessage> PostAsync(string requestUri, HttpContent content)
        {
            return _http.PostAsync(requestUri, content);
        }

        public virtual Task<HttpResponseMessage> PostAsync(string requestUri, HttpContent content, CancellationToken cancellationToken)
        {
            return _http.PostAsync(requestUri, content, cancellationToken);
        }

        public virtual Task<HttpResponseMessage> PostAsync(Uri requestUri, HttpContent content)
        {
            return _http.PostAsync(requestUri, content);
        }

        public virtual Task<HttpResponseMessage> PostAsync(Uri requestUri, HttpContent content, CancellationToken cancellationToken)
        {
            return _http.PostAsync(requestUri, content, cancellationToken);
        }

        public virtual Task PostJsonAsync(string requestUri, object content)
        {
            return _http.PostJsonAsync(requestUri, content);
        }

        public virtual Task<T> PostJsonAsync<T>(string requestUri, object content)
        {
            return _http.PostJsonAsync<T>(requestUri, content);
        }

        public virtual Task<HttpResponseMessage> PutAsync(string requestUri, HttpContent content)
        {
            return _http.PutAsync(requestUri, content);
        }

        public virtual Task<HttpResponseMessage> PutAsync(string requestUri, HttpContent content, CancellationToken cancellationToken)
        {
            return _http.PutAsync(requestUri, content, cancellationToken);
        }

        public virtual Task<HttpResponseMessage> PutAsync(Uri requestUri, HttpContent content)
        {
            return _http.PutAsync(requestUri, content);
        }

        public virtual Task<HttpResponseMessage> PutAsync(Uri requestUri, HttpContent content, CancellationToken cancellationToken)
        {
            return _http.PutAsync(requestUri, content, cancellationToken);
        }

        public virtual Task PutJsonAsync(string requestUri, object content)
        {
            return _http.PutJsonAsync(requestUri, content);
        }

        public virtual Task<T> PutJsonAsync<T>(string requestUri, object content)
        {
            return _http.PutJsonAsync<T>(requestUri, content);
        }

        public virtual Task<HttpResponseMessage> SendAsync(HttpRequestMessage request)
        {
            return _http.SendAsync(request);
        }

        public virtual Task<HttpResponseMessage> SendAsync(HttpRequestMessage request, HttpCompletionOption completionOption)
        {
            return _http.SendAsync(request, completionOption);
        }

        public virtual Task<HttpResponseMessage> SendAsync(HttpRequestMessage request, HttpCompletionOption completionOption, CancellationToken cancellationToken)
        {
            return _http.SendAsync(request, completionOption, cancellationToken);
        }

        public virtual Task<HttpResponseMessage> SendAsync(HttpRequestMessage request, CancellationToken cancellationToken)
        {
            return _http.SendAsync(request, cancellationToken);
        }

        public virtual Task SendJsonAsync(HttpMethod method, string requestUri, object content)
        {
            return _http.SendJsonAsync(method, requestUri, content);
        }

        public virtual Task<T> SendJsonAsync<T>(HttpMethod method, string requestUri, object content)
        {
            return _http.SendJsonAsync<T>(method, requestUri, content);
        }

        public virtual Task<HttpResult<T>> GetJsonAsyncSafe<T>(string requestUri)
        {
            return _http.GetJsonAsyncSafe<T>(requestUri);
        }

        public virtual Task<HttpResult<T>> GetJsonAsyncSafe<T>(Uri requestUri)
        {
            return _http.GetJsonAsyncSafe<T>(requestUri);
        }

        public virtual Task<HttpResult> PostJsonAsyncSafe(string requestUri, object content)
        {
            return _http.PostJsonAsyncSafe(requestUri, content);
        }

        public virtual Task<HttpResult> PostJsonAsyncSafe(Uri requestUri, object content)
        {
            return _http.PostJsonAsyncSafe(requestUri, content);
        }

        public virtual Task<HttpResult<T>> PostJsonAsyncSafe<T>(string requestUri, object content)
        {
            return _http.PostJsonAsyncSafe<T>(requestUri, content);
        }

        public virtual Task<HttpResult<T>> PostJsonAsyncSafe<T>(Uri requestUri, object content)
        {
            return _http.PostJsonAsyncSafe<T>(requestUri, content);
        }

        public virtual Task<HttpResult> PutJsonAsyncSafe(string requestUri, object content)
        {
            return _http.PutJsonAsyncSafe(requestUri, content);
        }

        public virtual Task<HttpResult> PutJsonAsyncSafe(Uri requestUri, object content)
        {
            return _http.PutJsonAsyncSafe(requestUri, content);
        }

        public virtual Task<HttpResult<T>> PutJsonAsyncSafe<T>(string requestUri, object content)
        {
            return _http.PutJsonAsyncSafe<T>(requestUri, content);
        }

        public virtual Task<HttpResult<T>> PutJsonAsyncSafe<T>(Uri requestUri, object content)
        {
            return _http.PutJsonAsyncSafe<T>(requestUri, content);
        }

        public virtual Task<HttpResult> SendJsonAsyncSafe(HttpMethod method, string requestUri, object content)
        {
            return _http.SendJsonAsyncSafe(method, requestUri, content);
        }

        public virtual Task<HttpResult> SendJsonAsyncSafe(HttpMethod method, Uri requestUri, object content)
        {
            return _http.SendJsonAsyncSafe(method, requestUri, content);
        }

        public virtual Task<HttpResult<T>> SendJsonAsyncSafe<T>(HttpMethod method, string requestUri, object content)
        {
            return _http.SendJsonAsyncSafe<T>(method, requestUri, content);
        }

        public virtual Task<HttpResult<T>> SendJsonAsyncSafe<T>(HttpMethod method, Uri requestUri, object content)
        {
            return _http.SendJsonAsyncSafe<T>(method, requestUri, content);
        }

        public virtual Task<HttpResult<string>> GetStringAsyncSafe(string requestUri)
        {
            return _http.GetStringAsyncSafe(requestUri);
        }

        public virtual Task<HttpResult<string>> GetStringAsyncSafe(Uri requestUri)
        {
            return _http.GetStringAsyncSafe(requestUri);
        }
    }
}
