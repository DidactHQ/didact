using System;

namespace DidactDomain.DataModel.Entities
{
    public class Deployment
    {
        public long DeploymentId { get; set; }

        public int DeploymentTypeId { get; set; }

        public int DeploymentSourceTypeId { get; set; }

        public int DeploymentStatusId { get; set; }

        public long EnvironmentId { get; set; }

        public string Name { get; set; } = null!;

        public string Entrypoint { get; set; } = null!;

        public DateTime Created { get; set; }

        public string CreatedBy { get; set; } = null!;

        public DateTime Updated { get; set; }

        public string UpdatedBy { get; set; } = null!;

        public bool Active { get; set; }

        public byte[] RowVersion { get; set; } = null!;
    }
}
