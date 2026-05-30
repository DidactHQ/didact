using DidactCore.Schedules;

namespace DidactDomain.Schedules
{
    public interface IOneTimeScheduleBuilderFactory
    {
        IOneTimeScheduleBuilder Create();
    }
}
