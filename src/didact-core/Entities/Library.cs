using System;

namespace DidactCore.Entities
{
    public class Library
    {
        public long LibraryId { get; set; }

        public long EnvironmentId { get; set; }

        public string AssemblyName { get; set; } = null!;

        public DateTime Created { get; set; }

        public string CreatedBy { get; set; } = null!;

        public DateTime Updated { get; set; }

        public string UpdatedBy { get; set; } = null!;

        public bool Active { get; set; }

        public byte[] RowVersion { get; set; } = null!;
    }
}
