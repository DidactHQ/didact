using DidactCore.Schedules;

namespace DidactDomain.Schedules
{
    public interface ICronScheduleBuilderFactory
    {
        ICronScheduleBuilder Create();
    }
}
