namespace DidactEngine.TaskSchedulers.Deprecated
{
    public class DidactAwaitable
    {
        private readonly Task _task;
        private readonly TaskScheduler _scheduler;

        public DidactAwaitable(Task task, TaskScheduler scheduler)
        {
            _task = task;
            _scheduler = scheduler;
        }

        // This allows the await keyword to work with this class
        public DidactAwaiter GetAwaiter()
        {
            return new DidactAwaiter(_task, _scheduler);
        }
    }
}
