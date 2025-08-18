using System;

namespace DidactCore.Plugins
{
    public class PluginExecutionVersion
    {
        public string FlowTypeName { get; set; } = null!;

        public string FlowVersion { get; set; } = null!;

        public string LibraryAssemblyName { get; set; } = null!;

        public string LibraryAssemblyVersion { get; set; } = null!;

        public PluginExecutionVersion(string flowTypeName, string flowVersion, string libraryAssemblyName, string libraryAssemblyVersion)
        {
            FlowTypeName = flowTypeName;
            FlowVersion = flowVersion;
            LibraryAssemblyName = libraryAssemblyName;
            LibraryAssemblyVersion = libraryAssemblyVersion;
        }

        // Override the Equals method
        public override bool Equals(object obj)
        {
            if (obj is null || GetType() != obj.GetType())
            {
                return false;
            }

            return Equals((PluginExecutionVersion)obj);
        }

        // Implement IEquatable<T>.Equals
        public bool Equals(PluginExecutionVersion other)
        {
            if (other is null)
            {
                return false;
            }

            return other.FlowTypeName == FlowTypeName
                && other.FlowVersion == FlowVersion
                && other.LibraryAssemblyName == LibraryAssemblyName
                && other.LibraryAssemblyVersion == LibraryAssemblyVersion;
        }

        // Override GetHashCode
        public override int GetHashCode()
        {
            // Combine hash codes from fields to ensure uniqueness
            return HashCode.Combine(FlowTypeName, FlowVersion, LibraryAssemblyName, LibraryAssemblyVersion);
        }

        // Optionally, override == and != operators for syntactic sugar
        public static bool operator ==(PluginExecutionVersion left, PluginExecutionVersion right)
        {
            if (left is null)
            {
                return right is null;
            }
            return left.Equals(right);
        }

        public static bool operator !=(PluginExecutionVersion left, PluginExecutionVersion right)
        {
            return !(left == right);
        }
    }
}
