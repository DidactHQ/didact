namespace DidactPrimitives.Constants
{
    public static class RetryStrategies
    {
        public const string None = "None";
        public const string FixedInterval = "Fixed Interval";
        public const string ExponentialBackoff = "Exponential Backoff";
        public const string LinearBackoff = "Linear Backoff";
    }
}
