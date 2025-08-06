using System;

namespace DidactCore.Entities
{
    public class Engine
    {
        public long EngineId { get; set; }

        public long EnvironmentId { get; set; }

        public string UniqueName { get; set; } = null!;

        public string? Name { get; set; }

        public int? LatestProcessId { get; set; }

        public DateTime LastHeartbeat { get; set; }

        public string? Description { get; set; }

        public DateTime Created { get; set; }

        public string CreatedBy { get; set; } = null!;

        public DateTime Updated { get; set; }

        public string UpdatedBy { get; set; } = null!;

        public bool Active { get; set; }

        public byte[] RowVersion { get; set; } = null!;

        public virtual Environment Environment { get; set; } = null!;
    }
}
