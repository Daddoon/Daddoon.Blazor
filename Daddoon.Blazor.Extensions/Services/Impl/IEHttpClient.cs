using Microsoft.AspNetCore.Blazor;
using Microsoft.AspNetCore.Blazor.Browser.Interop;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http;
using System.Threading.Tasks;

namespace Daddoon.Blazor.Services.Impl
{
    public class IEHttpClient : BaseHttpClient
    {
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

        private static Dictionary<int, TaskResultTuple> _taskDico;

        public static void TaskDispatcher(string taskIdStr, string result)
        {
            //TODO: Dispose invalid/faulted Task
            if (int.TryParse(taskIdStr, out int taskId) == false)
                return;


            if (_taskDico.ContainsKey(taskId))
            {
                _taskDico[taskId].result = result;
                _taskDico[taskId].task.Start();
            }
        }

        public static int CreateTaskToDispatch<T>(out Task<T> futurTask)
        {
            int id = GetTaskId();

            futurTask = new Task<T>(delegate ()
            {
                if (_taskDico.ContainsKey(id))
                {
                    try
                    {
                        return JsonUtil.Deserialize<T>(_taskDico[id].result);
                    }
                    catch (Exception ex)
                    {
                        return default(T);
                    }
                }
                return default(T);

            });

            _taskDico.Add(id, new TaskResultTuple(futurTask, string.Empty));

            return id;
        }

        private static int _taskId = 0;
        public static int GetTaskId()
        {
            return ++_taskId;
        }

        public IEHttpClient(HttpClient http) : base(http)
        {
            if (_taskDico == null)
                _taskDico = new Dictionary<int, TaskResultTuple>();
        }

        public override Task<T> GetJsonAsync<T>(string requestUri)
        {
            //TODO: Faulty task => Set as error
            int id = CreateTaskToDispatch<T>(out Task<T> futurTask);
            RegisteredFunction.Invoke<string>("daddoon_jQuery_GetJsonAsync", id, BaseAddress + requestUri);

            return futurTask;
        }
    }
}
