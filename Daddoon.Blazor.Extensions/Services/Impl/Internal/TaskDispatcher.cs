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
            public static Func<object, T> JsonToCSharp<T>()
            {
                return delegate (object result)
                {
                    string content = result as string;

                    try
                    {
                        return JsonUtil.Deserialize<T>(content);
                    }
                    catch (Exception)
                    {
                        return default(T);
                    }
                };
            }
        }

        public static void Dispatch(string taskIdStr, string result)
        {
            //TODO: Dispose invalid/faulted Task/timeouted task
            if (int.TryParse(taskIdStr, out int taskId) == false)
                return;


            if (_taskDico.ContainsKey(taskId))
            {
                _taskDico[taskId].result = result;
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

                    //Remove current referenced task reference as it's a completed callback
                    _taskDico.Remove(id);

                    return action != null ? action(result) : default(T);
                }
                return default(T);
            });

            _taskDico.Add(id, new TaskResultTuple(futurTask, string.Empty));

            return id;
        }
    }
}
