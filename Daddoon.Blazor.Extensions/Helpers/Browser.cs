using Microsoft.AspNetCore.Blazor.Browser.Interop;
using System;
using System.Timers;

namespace Daddoon.Blazor.Helpers
{
    public enum RenderingEngine : int
    {
        Unknown = 0,
        WebKit = 1,
        Blink = 2,
        Gecko = 3,
        MSIE = 4,
        MSEdge = 5,
    }

    public enum BrowserFamily : int
    {
        Other = 0,
        InternetExplorer = 1,
        InternetExplorer11 = 2,
        Edge = 3
    }

    public static class Browser
    {
        static Browser()
        {
        }

        #region Alert

        public static void Alert(string msg)
        {
            RegisteredFunction.Invoke<object>("daddoon_Alert", msg);
        }

        #endregion

        #region SetTimeout

        /// <summary>
        /// Call the given delegate after the timeout interval.
        /// Does not rely on the browser setTimeout but on System.Timers
        /// </summary>
        /// <param name="handler"></param>
        /// <param name="timeout"></param>
        public static void SetTimeout(Action handler, int timeout)
        {
            ElapsedEventHandler tmElapsed = null;
            Timer tm = new Timer(timeout);

            tmElapsed = delegate(object sender, ElapsedEventArgs e)
            {
                tm.Stop();
                tm.Elapsed -= tmElapsed;
                tm.Dispose();

                handler();
            };


            tm.Elapsed += tmElapsed;
            tm.Start();
        }

        [Obsolete("Use the parameterless version of SetTimeout, as scoped variables are available in C# delegates", false)]
        public static void SetTimeout<Param1>(Action<Param1> handler, int timeout, Param1 param1)
        {
            ElapsedEventHandler tmElapsed = null;
            Timer tm = new Timer(timeout);

            tmElapsed = delegate (object sender, ElapsedEventArgs e)
            {
                tm.Stop();
                tm.Elapsed -= tmElapsed;
                tm.Dispose();

                handler(param1);
            };


            tm.Elapsed += tmElapsed;
            tm.Start();
        }

        [Obsolete("Use the parameterless version of SetTimeout, as scoped variables are available in C# delegates", false)]
        public static void SetTimeout<Param1, Param2>(Action<Param1, Param2> handler, int timeout, Param1 param1, Param2 param2)
        {
            ElapsedEventHandler tmElapsed = null;
            Timer tm = new Timer(timeout);

            tmElapsed = delegate (object sender, ElapsedEventArgs e)
            {
                tm.Stop();
                tm.Elapsed -= tmElapsed;
                tm.Dispose();

                handler(param1, param2);
            };


            tm.Elapsed += tmElapsed;
            tm.Start();
        }

        [Obsolete("Use the parameterless version of SetTimeout, as scoped variables are available in C# delegates", false)]
        public static void SetTimeout<Param1, Param2, Param3>(Action<Param1, Param2, Param3> handler, int timeout, Param1 param1, Param2 param2, Param3 param3)
        {
            ElapsedEventHandler tmElapsed = null;
            Timer tm = new Timer(timeout);

            tmElapsed = delegate (object sender, ElapsedEventArgs e)
            {
                tm.Stop();
                tm.Elapsed -= tmElapsed;
                tm.Dispose();

                handler(param1, param2, param3);
            };


            tm.Elapsed += tmElapsed;
            tm.Start();
        }

        [Obsolete("Use the parameterless version of SetTimeout, as scoped variables are available in C# delegates", false)]
        public static void SetTimeout<Param1, Param2, Param3, Param4>(Action<Param1, Param2, Param3, Param4> handler, int timeout, Param1 param1, Param2 param2, Param3 param3, Param4 param4)
        {
            ElapsedEventHandler tmElapsed = null;
            Timer tm = new Timer(timeout);

            tmElapsed = delegate (object sender, ElapsedEventArgs e)
            {
                tm.Stop();
                tm.Elapsed -= tmElapsed;
                tm.Dispose();

                handler(param1, param2, param3, param4);
            };


            tm.Elapsed += tmElapsed;
            tm.Start();
        }

        [Obsolete("Use the parameterless version of SetTimeout, as scoped variables are available in C# delegates", false)]
        public static void SetTimeout<Param1, Param2, Param3, Param4, Param5>(Action<Param1, Param2, Param3, Param4, Param5> handler, int timeout, Param1 param1, Param2 param2, Param3 param3, Param4 param4, Param5 param5)
        {
            ElapsedEventHandler tmElapsed = null;
            Timer tm = new Timer(timeout);

            tmElapsed = delegate (object sender, ElapsedEventArgs e)
            {
                tm.Stop();
                tm.Elapsed -= tmElapsed;
                tm.Dispose();

                handler(param1, param2, param3, param4, param5);
            };


            tm.Elapsed += tmElapsed;
            tm.Start();
        }

        [Obsolete("Use the parameterless version of SetTimeout, as scoped variables are available in C# delegates", false)]
        public static void SetTimeout<Param1, Param2, Param3, Param4, Param5, Param6>(Action<Param1, Param2, Param3, Param4, Param5, Param6> handler, int timeout, Param1 param1, Param2 param2, Param3 param3, Param4 param4, Param5 param5, Param6 param6)
        {
            ElapsedEventHandler tmElapsed = null;
            Timer tm = new Timer(timeout);

            tmElapsed = delegate (object sender, ElapsedEventArgs e)
            {
                tm.Stop();
                tm.Elapsed -= tmElapsed;
                tm.Dispose();

                handler(param1, param2, param3, param4, param5, param6);
            };


            tm.Elapsed += tmElapsed;
            tm.Start();
        }

        [Obsolete("Use the parameterless version of SetTimeout, as scoped variables are available in C# delegates", false)]
        public static void SetTimeout<Param1, Param2, Param3, Param4, Param5, Param6, Param7>(Action<Param1, Param2, Param3, Param4, Param5, Param6, Param7> handler, int timeout, Param1 param1, Param2 param2, Param3 param3, Param4 param4, Param5 param5, Param6 param6, Param7 param7)
        {
            ElapsedEventHandler tmElapsed = null;
            Timer tm = new Timer(timeout);

            tmElapsed = delegate (object sender, ElapsedEventArgs e)
            {
                tm.Stop();
                tm.Elapsed -= tmElapsed;
                tm.Dispose();

                handler(param1, param2, param3, param4, param5, param6, param7);
            };


            tm.Elapsed += tmElapsed;
            tm.Start();
        }

        #endregion

        /// <summary>
        /// Get current browser metadata
        /// Bindings: Bowser.js 1.9.3
        /// </summary>
        public static class Platform
        {
            private static BrowserFamily? _browserFamily;
            public static BrowserFamily BrowserFamily
            {
                get
                {
                    if (_browserFamily == null && Name != string.Empty)
                    {
                        if (Name == "Internet Explorer")
                        {
                            _browserFamily = BrowserFamily.InternetExplorer;
                            if (Version == "11.0")
                            {
                                _browserFamily = BrowserFamily.InternetExplorer11;
                            }
                        }
                        else if (Name == "Microsoft Edge")
                        {
                            _browserFamily = BrowserFamily.Edge;
                        }
                        else
                            _browserFamily = BrowserFamily.Other;
                    }

                    return _browserFamily != null ? (BrowserFamily)_browserFamily : BrowserFamily.Other;
                }
            }

            private static RenderingEngine? _renderingEngine;
            public static RenderingEngine RenderingEngine
            {
                get
                {
                    if (_renderingEngine == null)
                    {
                        if (!RegisteredFunctionExtension.TryInvoke(out int val, "daddoon_bowser_renderingengine"))
                            return RenderingEngine.Unknown;
                        _renderingEngine = (RenderingEngine)val;
                    }
                    return _renderingEngine != null ? (RenderingEngine)_renderingEngine: RenderingEngine.Unknown;
                }
            }

            public static string UserAgent
            {
                get
                {
                    if (RegisteredFunctionExtension.TryInvoke(out string result, "daddoon_bowser_useragent"))
                        return result;
                    return string.Empty;
                }
            }

            public static string Name
            {
                get
                {
                    if (RegisteredFunctionExtension.TryInvoke(out string result, "daddoon_bowser_name"))
                        return result;
                    return string.Empty;
                }
            }

            public static string Version
            {
                get
                {
                    if (RegisteredFunctionExtension.TryInvoke(out string result, "daddoon_bowser_version"))
                        return result;
                    return string.Empty;
                }
            }
        }
    }
}
