using System;

namespace DidactDomain.DataModel.Entities
{
    public class Step
    {
        public long StepId { get; set; }

        public long FlowRunId { get; set; }

        public long EnvironmentId { get; set; }

        public string Name { get; set; } = null!;

        public DateTime? ExecutionStartedAt { get; set; }

        public DateTime? ExecutionEndedAt { get; set; }

        public DateTime Created { get; set; }

        public string CreatedBy { get; set; } = null!;

        public DateTime Updated { get; set; }

        public string UpdatedBy { get; set; } = null!;

        public bool Active { get; set; }
    }
}
