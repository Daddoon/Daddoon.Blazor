using Microsoft.AspNetCore.Blazor.Components;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace Daddoon.Blazor.Extensions.Interfaces
{
    public interface IApp : IComponent, IHandleEvent
    {
        /// <summary>
        /// Called at startup when Blazor is ready to be fully in use.
        /// </summary>
        /// <returns></returns>
        Task OnReady();
    }
}
