using System;

namespace DidactDomain.DataModel.Entities
{
    public class DeploymentSourceFilesystem
    {
        public long DeploymentSourceFilesystemId { get; set; }

        public long DeploymentId { get; set; }

        public long EnvironmentId { get; set; }

        public string Path { get; set; } = null!;

        public DateTime Created { get; set; }

        public string CreatedBy { get; set; } = null!;

        public DateTime Updated { get; set; }

        public string UpdatedBy { get; set; } = null!;

        public bool Active { get; set; }

        public byte[] RowVersion { get; set; } = null!;
    }
}
