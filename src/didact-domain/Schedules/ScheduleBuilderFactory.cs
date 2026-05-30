using DidactCore.Schedules;
using Microsoft.Extensions.DependencyInjection;
using System;

namespace DidactDomain.Schedules
{
    public class ScheduleBuilderFactory : IScheduleBuilderFactory
    {
        private readonly IServiceProvider _serviceProvider;

        public ScheduleBuilderFactory(IServiceProvider serviceProvider)
        {
            _serviceProvider = serviceProvider;
        }

        public IScheduleBuilder Create()
        {
            return _serviceProvider.GetRequiredService<IScheduleBuilder>();
        }
    }
}
