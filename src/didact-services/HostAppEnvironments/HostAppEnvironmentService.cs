namespace DidactServices.HostAppEnvironments
{
    using DidactServices.Constants;
    using System;

    public class HostAppEnvironmentService
    {
        public HostAppEnvironmentService() { }

        /// <summary>
        /// Gets the Didact Build Environment and uses the default if one is not found.
        /// </summary>
        /// <returns></returns>
        public static string GetBuildEnvironment()
        {
            return Environment.GetEnvironmentVariable(Constants.Keys.BuildEnvironment)
                ?? Constants.Defaults.DefaultBuildEnvironment;
        }

        public static bool IsBuildEnvironmentProduction(string buildEnvironment) =>
            string.Equals(buildEnvironment, Constants.BuildEnvironments.Production, StringComparison.OrdinalIgnoreCase);

        /// <summary>
        /// Gets the dynamic environment name of the host app by using the build environment.
        /// This helps distinguish a Didact maintainer from a Didact user.
        /// </summary>
        /// <param name="buildEnvironment"></param>
        /// <param name="hostAppEnvironment"></param>
        /// <returns></returns>
        public static string? GetDynamicHostAppEnvironment(string buildEnvironment, string? hostAppEnvironment)
        {
            if (string.IsNullOrEmpty(hostAppEnvironment))
            {
                return hostAppEnvironment;
            }

            return IsBuildEnvironmentProduction(buildEnvironment)
                ? buildEnvironment
                : hostAppEnvironment;
        }
    }
}
