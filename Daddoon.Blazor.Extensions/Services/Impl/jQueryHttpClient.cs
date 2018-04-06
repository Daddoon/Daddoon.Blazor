using Daddoon.Blazor.Services.Impl.Internal;
using Microsoft.AspNetCore.Blazor;
using Microsoft.AspNetCore.Blazor.Browser.Interop;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http;
using System.Threading.Tasks;

namespace Daddoon.Blazor.Services.Impl
{
    public class jQueryHttpClient : BaseHttpClient
    {
        public jQueryHttpClient(HttpClient http) : base(http)
        {
        }

        public override Task<T> GetJsonAsync<T>(string requestUri)
        {
            int id = TaskDispatcher.CreateTaskToDispatch(TaskDispatcher.CommonTask.JsonToCSharp<T>(), out Task<T> futurTask);
            RegisteredFunction.Invoke<string>("daddoon_jQuery_GetJsonAsync", id, BaseAddress + requestUri);
            return futurTask;
        }
    }
}
