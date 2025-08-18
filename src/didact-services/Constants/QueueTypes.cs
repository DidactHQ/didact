namespace DidactCore.Constants
{
    public static class QueueTypes
    {
        /// <summary>
        /// <para>
        /// A queue type designated for maximum throughput by running jobs concurrently or in parallel.
        /// </para>
        /// <para>
        /// A hyper queue will attempt best-effort ordering of Flows, but ordering is not strictly guaranteed. This is to prioritize throughput.
        /// </para>
        /// <para>
        /// A hyper queue is an excellent candidate for a clustered/distributed environment.
        /// </para>
        /// </summary>
        public const string HyperQueue = "Hyper Queue";

        /// <summary>
        /// <para>
        /// A queue type designated for strict, guaranteed ordering.
        /// </para>
        /// <para>
        /// Because ordering is strictly enforced, a strict queue will necessarily sacrifice throughput.
        /// </para>
        /// </summary>
        public const string StrictQueue = "Strict Queue";
    }
}
