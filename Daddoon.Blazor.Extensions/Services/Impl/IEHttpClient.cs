using Microsoft.AspNetCore.Blazor;
using Microsoft.AspNetCore.Blazor.Browser.Interop;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http;
using System.Threading.Tasks;

namespace Daddoon.Blazor.Services.Impl
{
    public class IEHttpClient : BaseHttpClient
    {
        public IEHttpClient(HttpClient http) : base(http)
        {
        }

        public override Task<T> GetJsonAsync<T>(string requestUri)
        {
            string result = RegisteredFunction.Invoke<string>("daddoon_jQuery_GetJsonAsync", BaseAddress + requestUri);
            return Task.FromResult(JsonUtil.Deserialize<T>(result));
        }
    }
}
