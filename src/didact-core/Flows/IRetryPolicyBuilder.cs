using System;

namespace DidactCore.Flows
{
    public interface IRetryPolicyBuilder
    {
        IRetryPolicyBuilder WithMaxAttempts(int maxAttempts);

        IRetryPolicyBuilder UseFixedInterval(TimeSpan delay);

        IRetryPolicyBuilder UseExponentialBackoff(
            TimeSpan initialDelay,
            TimeSpan maxDelay,
            double multiplier = 2);

        IRetryPolicyBuilder UseLinearBackoff(
            TimeSpan initialDelay,
            TimeSpan maxDelay);

        IRetryPolicyBuilder WithRetryWindow(TimeSpan retryWindow);

        IRetryPolicyBuilder WithAttemptTimeout(TimeSpan timeout);
    }
}
