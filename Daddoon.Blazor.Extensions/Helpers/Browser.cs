using Microsoft.AspNetCore.Blazor.Browser.Interop;
using System;
using System.Timers;

namespace Daddoon.Blazor.Helpers
{
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
    }
}
