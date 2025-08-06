namespace DidactEngine.TaskSchedulers.Deprecated
{
    public static class DidactThreadPoolExtensions
    {
        // This extension method adds the custom awaiter logic
        public static DidactAwaitable WithScheduler(this Task task, TaskScheduler scheduler)
        {
            return new DidactAwaitable(task, scheduler);
        }
    }
}
