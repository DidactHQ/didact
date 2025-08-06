using System;

namespace DidactCore.Entities
{
    public class LibraryDeployment
    {
        public long LibraryDeploymentId { get; set; }

        public int LibraryDeploymentTypeId { get; set; }

        public long LibraryId { get; set; }

        public long EnvironmentId { get; set; }

        public string? Name { get; set; }

        public string? Description { get; set; }

        public DateTime Created { get; set; }

        public string CreatedBy { get; set; } = null!;

        public DateTime Updated { get; set; }

        public string UpdatedBy { get; set; } = null!;

        public bool Active { get; set; }

        public byte[] RowVersion { get; set; } = null!;
    }
}
