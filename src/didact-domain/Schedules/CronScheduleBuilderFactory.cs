using DidactCore.Schedules;
using Microsoft.Extensions.DependencyInjection;
using System;

namespace DidactDomain.Schedules
{
    public class CronScheduleBuilderFactory
    {
        private readonly IServiceProvider _serviceProvider;

        public CronScheduleBuilderFactory(IServiceProvider serviceProvider)
        {
            _serviceProvider = serviceProvider;
        }

        public ICronScheduleBuilder Create()
        {
            return _serviceProvider.GetRequiredService<ICronScheduleBuilder>();
        }
    }
}
