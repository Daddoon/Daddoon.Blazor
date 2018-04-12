using Daddoon.Blazor.Helpers;
using Daddoon.Blazor.Services;
using Microsoft.AspNetCore.Blazor.Components;
using System;
using System.Net.Http;
using System.Threading.Tasks;

namespace Daddoon.Blazor
{
    public class RenderSVG : BlazorComponent
    {
        [Inject]
        protected IHttpClientSafe Client { get; set; }

        public string src { get; set; }
        public string @class { get; set; }
        public string style { get; set; }

        private string tempId { get; set; }
        private int sequence = 0;

        protected override void BuildRenderTree(Microsoft.AspNetCore.Blazor.RenderTree.RenderTreeBuilder builder)
        {
            tempId = Guid.NewGuid().ToString("N");

            builder.OpenElement(0, "svg");

            builder.AddAttribute(++sequence, "svg-id", tempId);

            if (!string.IsNullOrEmpty(style))
                builder.AddAttribute(++sequence, "style", style);

            if (!string.IsNullOrEmpty(@class))
                builder.AddAttribute(++sequence, "class", @class);

            builder.CloseElement();

            Browser.SetTimeout(async delegate (string dtempId, string dclass, string dstyle)
            {
                var result = await Client.GetStringAsyncSafe(src);
                if (!result.Success)
                    return;

                RegisteredFunctionExtension.TryInvoke<bool>(out bool dummy, "daddoon_svg_replace_content", dtempId, dclass, dstyle, result.Data);
            }, 10, tempId, @class, style);
        }
    }
}
