using Daddoon.Blazor.Models;
using Microsoft.AspNetCore.Blazor;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace Daddoon.Blazor.Services.Impl.Internal
{
    public static class TaskDispatcher
    {
        static TaskDispatcher()
        {
            if (_taskDico == null)
                _taskDico = new Dictionary<int, TaskResultTuple>();
        }

        private static Dictionary<int, TaskResultTuple> _taskDico;

        internal class TaskResultTuple
        {
            public TaskResultTuple(Task _task, string _result)
            {
                task = _task;
                result = _result;
            }

            public bool success;
            public Task task;
            public string result;
        }

        private static int _taskId = 0;
        private static int GetTaskId()
        {
            return ++_taskId;
        }

        public static class CommonTask
        {
            public static Func<object, string> StringToCSharp()
            {
                return delegate (object result)
                {
                    string content = result as string;

                    try
                    {
                        //jQuery implementation using HttpResult under the hood for convenience
                        HttpResult<string> httpResult = JsonUtil.Deserialize<HttpResult<string>>(content);
                        return httpResult.Data;
                    }
                    catch (Exception ex)
                    {
                        throw ex;
                    }
                };
            }

            public static Func<object, HttpResult<string>> StringToCSharpSafe()
            {
                return delegate (object result)
                {
                    string content = result as string;

                    try
                    {
                        //jQuery implementation using HttpResult under the hood for convenience
                        HttpResult<string> httpResult = JsonUtil.Deserialize<HttpResult<string>>(content);
                        return httpResult;
                    }
                    catch (Exception ex)
                    {
                        ExceptionLogger.LogException(ex);
                        return new HttpResult<string>()
                        {
                            ClientError = true
                        };
                    }
                };
            }

            public static Func<object, T> JsonToCSharp<T>()
            {
                return delegate (object result)
                {
                    string content = result as string;

                    try
                    {
                        //jQuery implementation using HttpResult under the hood for convenience
                        HttpResult<string> httpResult = JsonUtil.Deserialize<HttpResult<string>>(content);

                        if (typeof(T) == typeof(IgnoreResponse))
                            return default;
                        else
                            return JsonUtil.Deserialize<T>(httpResult.Data);
                    }
                    catch (Exception ex)
                    {
                        throw ex;
                    }
                };
            }

            public static Func<object, HttpResult<T>> JsonToCSharpSafe<T>()
            {
                return delegate (object result)
                {
                    string content = result as string;

                    try
                    {
                        //jQuery implementation using HttpResult under the hood for convenience
                        HttpResult<string> httpResult = JsonUtil.Deserialize<HttpResult<string>>(content);

                        HttpResult<T> httpResultJson = new HttpResult<T>()
                        {
                            ClientError = httpResult.ClientError,
                            Code = httpResult.Code,
                            Success = httpResult.Success,
                        };

                        if (typeof(T) == typeof(IgnoreResponse))
                        {
                            httpResultJson.Data = default;
                            return httpResultJson;
                        }
                        else
                            httpResultJson.Data = JsonUtil.Deserialize<T>(httpResult.Data);

                        return httpResultJson;
                    }
                    catch (Exception ex)
                    {
                        ExceptionLogger.LogException(ex);

                        return new HttpResult<T>()
                        {
                            ClientError = true
                        };
                    }
                };
            }
        }

        public static void Dispatch(string taskIdStr, bool success, string result)
        {
            //TODO: Dispose invalid/faulted Task/timeouted task
            if (int.TryParse(taskIdStr, out int taskId) == false)
                return;

            if (_taskDico.ContainsKey(taskId))
            {
                _taskDico[taskId].result = result;
                _taskDico[taskId].success = success;
                _taskDico[taskId].task.Start();
            }
        }

        /// <summary>
        /// Create a new task that will be fired when your underlying service will call the Dispatch method with the corresponding taskId
        /// </summary>
        /// <typeparam name="T"></typeparam>
        /// <param name="futurTask"></param>
        /// <returns></returns>
        public static int CreateTaskToDispatch<T>(Func<object, T> action, out Task<T> futurTask)
        {
            int id = GetTaskId();

            futurTask = new Task<T>(delegate ()
            {
                if (_taskDico.ContainsKey(id))
                {
                    var result = _taskDico[id].result;
                    var success = _taskDico[id].success;

                    //Remove current referenced task reference as it's a completed callback
                    _taskDico.Remove(id);

                    if (success)
                    {
                        return action != null ? action(result) : default;
                    }
                    else
                    {
                        throw new InvalidOperationException();
                    }
                }
                return default;
            });

            _taskDico.Add(id, new TaskResultTuple(futurTask, string.Empty));

            return id;
        }
    }
}
