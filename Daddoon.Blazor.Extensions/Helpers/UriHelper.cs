using System;
using System.IO;

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


        /// <summary>
        /// Check if Uri Path are matching. requestUri2 must be Absolute kind
        /// </summary>
        /// <param name="requestUri1"></param>
        /// <param name="requestUri2"></param>
        /// <returns></returns>
        public static bool UriPathMatch(string requestUri1, Uri requestUri2)
        {
            if (requestUri2 == null || requestUri2.IsAbsoluteUri == false)
                return false;

            Uri uri = GetUri(requestUri1);
            return UriPathMatch(uri, requestUri2);
        }

        public static bool UriPathMatch(string requestUri1, string requestUri2)
        {
            //For NULL value comparison, as we don't also know if we are in a absolute or relative context
            if (requestUri1 == requestUri2)
                return true;

            //As previous case was false, if one URI is empty, it's not a valid Uri to compare
            if (string.IsNullOrEmpty(requestUri1) || string.IsNullOrEmpty(requestUri2))
                return false;

            Uri uri1 = GetUri(requestUri1);
            Uri uri2 = GetUri(requestUri2);

            return UriPathMatch(uri1, uri2);
        }

        /// <summary>
        /// Check if Uri Path are matching. requestUri1 and requestUri2 must be Absolute kind
        /// </summary>
        /// <param name="requestUri1"></param>
        /// <param name="requestUri2"></param>
        /// <returns></returns>
        public static bool UriPathMatch(Uri requestUri1, Uri requestUri2)
        {
            if (requestUri1 == null || requestUri2 == null
                || requestUri1.IsAbsoluteUri == false || requestUri2.IsAbsoluteUri == false)
                return false;

            var path1 = requestUri1.AbsolutePath.TrimStart(Path.DirectorySeparatorChar, Path.AltDirectorySeparatorChar).ToLowerInvariant();
            var path2 = requestUri2.AbsolutePath.TrimStart(Path.DirectorySeparatorChar, Path.AltDirectorySeparatorChar).ToLowerInvariant();

            if (path1 == path2)
                return true;
            return false;
        }
    }
}
