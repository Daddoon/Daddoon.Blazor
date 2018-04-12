using System;

namespace Daddoon.Blazor.Helpers
{
    public static class UriHelper
    {
        private static string _baseAddress = null;
        public  static string BaseAddress {
            get
            {
                return _baseAddress;
            }
            set
            {
                if (_baseAddress == null)
                    _baseAddress = value;
            }
        }

        public static Uri GetUri(string requestUri)
        {
            if (Uri.IsWellFormedUriString(requestUri, UriKind.Absolute))
                return new Uri(requestUri, UriKind.Absolute);
            else if (Uri.IsWellFormedUriString(requestUri, UriKind.Relative))
            {
                return new Uri(BaseAddress + requestUri, UriKind.Absolute);
            }
            else
                return new Uri(BaseAddress + requestUri, UriKind.Absolute);
        }
    }
}
