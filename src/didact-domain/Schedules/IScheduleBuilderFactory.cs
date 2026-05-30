using DidactCore.Schedules;

namespace DidactDomain.Schedules
{
    public interface IScheduleBuilderFactory
    {
        IScheduleBuilder Create();
    }
}
