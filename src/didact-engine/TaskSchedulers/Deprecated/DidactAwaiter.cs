using System.Runtime.CompilerServices;

namespace DidactEngine.TaskSchedulers.Deprecated
{
    public class DidactAwaiter : INotifyCompletion
    {
        private readonly Task _task;
        private readonly TaskScheduler _scheduler;

        public DidactAwaiter(Task task, TaskScheduler scheduler)
        {
            _task = task;
            _scheduler = scheduler;
        }

        // This tells the awaiter whether the task is already completed
        public bool IsCompleted => _task.IsCompleted;

        // This schedules the continuation on the custom task scheduler
        public void OnCompleted(Action continuation)
        {
            Task.Factory.StartNew(continuation, CancellationToken.None, TaskCreationOptions.DenyChildAttach, _scheduler);
        }

        // This is called to retrieve the result of the task when it's completed
        public void GetResult()
        {
            _task.GetAwaiter().GetResult(); // Re-throws any exceptions from the task
        }
    }
}
