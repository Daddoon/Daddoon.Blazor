using Daddoon.Blazor.Services.Impl.Internal;
using Microsoft.AspNetCore.Blazor;
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

        #region Cookies

        /// <summary>
        /// Cookie implementation: js-cookie => https://github.com/js-cookie/js-cookie
        /// Expiration is in days
        /// </summary>
        public static class Cookies
        {
            #region SET

            private static double? GetDaysFromDateTime(DateTime? expiration)
            {
                double? nbDays = null;

                if (expiration != null)
                {
                    nbDays = ((DateTime)expiration - DateTime.Now).TotalDays;
                }

                return nbDays;
            }

            public static bool Set(string name, string value, double? expiration = null, string path = null, string domain = null, bool? secure = null)
            {
                if (!RegisteredFunctionExtension.TryInvoke(out bool val, "daddoon_cookie_set", name, value, expiration, path, domain, secure))
                {
                    ExceptionLogger.LogException("An error occured while trying to call daddoon_cookie_set", new InvalidOperationException());
                    return false;
                }

                return val;
            }

            public static bool Set(string name, string value, DateTime? expiration, string path = null, string domain = null, bool? secure = null)
            {
                return Set(name, value, GetDaysFromDateTime(expiration), path, domain, secure);
            }

            public static bool Set<T>(string name, T value, double? expiration = null, string path = null, string domain = null, bool? secure = null)
            {
                string json = null;

                if (value != null)
                {
                    json = JsonUtil.Serialize(value);
                }

                return Set(name, json, expiration, path, domain, secure);
            }

            public static bool Set<T>(string name, T value, DateTime? expiration, string path = null, string domain = null, bool? secure = null)
            {
                return Set(name, value, GetDaysFromDateTime(expiration), path, domain, secure);
            }

            #endregion

            #region GET

            public static string Get(string name)
            {
                if (!RegisteredFunctionExtension.TryInvoke(out string val, "daddoon_cookie_get", name))
                {
                    ExceptionLogger.LogException("An error occured while trying to call daddoon_cookie_get", new InvalidOperationException());
                    return null;
                }

                return val;
            }

            public static T Get<T>(string name) where T : new()
            {
                T result = default;
                string json = Get(name);

                if (!string.IsNullOrEmpty(json))
                {
                    try
                    {
                        result = JsonUtil.Deserialize<T>(json);
                    }
                    catch (Exception ex)
                    {
                        ExceptionLogger.LogException("An error occured while trying to deserialize the cookie", ex);
                    }
                }

                return result;
            }

            #endregion

            #region REMOVE

            public static bool Remove(string name, string path = null, string domain = null)
            {
                if (!RegisteredFunctionExtension.TryInvoke(out bool val, "daddoon_cookie_remove", name, path, domain))
                {
                    ExceptionLogger.LogException("An error occured while trying to call daddoon_cookie_remove", new InvalidOperationException());
                    return false;
                }

                return val;
            }

            #endregion
        }

        #endregion

        #region LocalStorage

        public static class LocalStorage
        {
            public static bool Set(string name, string value)
            {
                if (!RegisteredFunctionExtension.TryInvoke(out bool val, "daddoon_localstorage_set", name, value))
                {
                    ExceptionLogger.LogException("An error occured while trying to call daddoon_localstorage_set", new InvalidOperationException());
                    return false;
                }

                return val;
            }

            public static bool Set<T>(string name, T value)
            {
                string json = null;

                try
                {
                    json = JsonUtil.Serialize(value);
                }
                catch (Exception)
                {
                    ExceptionLogger.LogException("An error occured while trying to serialize data in LocalStorage.Set<T>", new InvalidOperationException());
                    return false;
                }

                return Set(name, json);
            }

            public static string Get(string name)
            {

                if (!RegisteredFunctionExtension.TryInvoke(out string val, "daddoon_localstorage_get", name))
                {
                    ExceptionLogger.LogException("An error occured while trying to call daddoon_localstorage_get", new InvalidOperationException());
                    return null;
                }

                return val;
            }

            public static T Get<T>(string name)
            {
                string result = Get(name);
                if (result == null)
                    return default;

                try
                {
                    T value = JsonUtil.Deserialize<T>(result);
                    return value;
                }
                catch (Exception)
                {
                    ExceptionLogger.LogException("An error occured while trying to deserialize data in LocalStorage.Get<T>", new InvalidOperationException());
                    return default;
                }
            }

            public static void Clear()
            {
                if (!RegisteredFunctionExtension.TryInvoke(out bool val, "daddoon_localstorage_clear"))
                {
                    ExceptionLogger.LogException("An error occured while trying to call daddoon_localstorage_clear", new InvalidOperationException());
                }
            }

            public static void Remove(string name)
            {
                if (!RegisteredFunctionExtension.TryInvoke(out bool val, "daddoon_localstorage_remove", name))
                {
                    ExceptionLogger.LogException("An error occured while trying to call daddoon_localstorage_remove", new InvalidOperationException());
                }
            }
        }

        public static class SessionStorage
        {
            public static bool Set(string name, string value)
            {
                if (!RegisteredFunctionExtension.TryInvoke(out bool val, "daddoon_sessionstorage_set", name, value))
                {
                    ExceptionLogger.LogException("An error occured while trying to call daddoon_sessionstorage_set", new InvalidOperationException());
                    return false;
                }

                return val;
            }

            public static bool Set<T>(string name, T value)
            {
                string json = null;

                try
                {
                    json = JsonUtil.Serialize(value);
                }
                catch (Exception)
                {
                    ExceptionLogger.LogException("An error occured while trying to serialize data in SessionStorage.Set<T>", new InvalidOperationException());
                    return false;
                }

                return Set(name, json);
            }

            public static string Get(string name)
            {

                if (!RegisteredFunctionExtension.TryInvoke(out string val, "daddoon_sessionstorage_get", name))
                {
                    ExceptionLogger.LogException("An error occured while trying to call daddoon_sessionstorage_get", new InvalidOperationException());
                    return null;
                }

                return val;
            }

            public static T Get<T>(string name)
            {
                string result = Get(name);
                if (result == null)
                    return default;

                try
                {
                    T value = JsonUtil.Deserialize<T>(result);
                    return value;
                }
                catch (Exception)
                {
                    ExceptionLogger.LogException("An error occured while trying to deserialize data in SessionStorage.Get<T>", new InvalidOperationException());
                    return default;
                }
            }

            public static void Clear()
            {
                if (!RegisteredFunctionExtension.TryInvoke(out bool val, "daddoon_sessionstorage_clear"))
                {
                    ExceptionLogger.LogException("An error occured while trying to call daddoon_sessionstorage_clear", new InvalidOperationException());
                }
            }

            public static void Remove(string name)
            {
                if (!RegisteredFunctionExtension.TryInvoke(out bool val, "daddoon_sessionstorage_remove", name))
                {
                    ExceptionLogger.LogException("An error occured while trying to call daddoon_sessionstorage_remove", new InvalidOperationException());
                }
            }
        }

        #endregion

        #region Location
        
        public static class Location
        {
            public static bool Reload(bool forceGet = false)
            {
                if (!RegisteredFunctionExtension.TryInvoke(out int val, "daddoon_location_reload", forceGet))
                {
                    ExceptionLogger.LogException("An error occured while trying to call daddoon_location_reload", new InvalidOperationException());
                    return false;
                }

                //Somehow pointless due to the behavior!
                return true;
            }
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
