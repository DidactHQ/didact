using System;

namespace DidactCore.Entities
{
    public class LibraryDeploymentLocalFileSystem
    {
        public long LibraryDeploymentLocalFileSystemId { get; set; }

        public long LibraryDeploymentId { get; set; }

        public long EnvironmentId { get; set; }

        public string FolderPath { get; set; } = null!;

        public DateTime Created { get; set; }

        public string CreatedBy { get; set; } = null!;

        public DateTime Updated { get; set; }

        public string UpdatedBy { get; set; } = null!;

        public bool Active { get; set; }

        public byte[] RowVersion { get; set; } = null!;
    }
}
