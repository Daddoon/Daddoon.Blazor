using System;
using System.Collections.Generic;
using System.Runtime.CompilerServices;
using System.Text;

namespace Daddoon.Blazor.Services.Impl.Internal
{
    public static class ExceptionLogger
    {
        public static void LogException(string message, Exception ex, [CallerMemberName] string caller = null)
        {
            if (message != null)
                message += " ";

            Console.WriteLine($"{caller} - {message}{ex.GetType().Name}  ex: {ex.Message}, ex: {ex.StackTrace}");
        }

        public static void LogException(Exception ex, [CallerMemberName] string caller = null)
        {
            LogException(null, ex, caller);
        }
    }
}
