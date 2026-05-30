using DidactCore.Schedules;
using Microsoft.Extensions.DependencyInjection;
using System;

namespace DidactDomain.Schedules
{
    public class OneTimeScheduleBuilderFactory
    {
        private readonly IServiceProvider _serviceProvider;

        public OneTimeScheduleBuilderFactory(IServiceProvider serviceProvider)
        {
            _serviceProvider = serviceProvider;
        }

        public IOneTimeScheduleBuilder Create() => _serviceProvider.GetRequiredService<IOneTimeScheduleBuilder>();
    }
}