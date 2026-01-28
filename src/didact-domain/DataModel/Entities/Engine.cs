using System;

namespace DidactDomain.DataModel.Entities
{
    public class Engine
    {
        public long EngineId { get; set; }

        public string Name { get; set; } = null!;

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
