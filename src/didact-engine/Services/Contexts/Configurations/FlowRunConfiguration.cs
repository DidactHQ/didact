using Microsoft.EntityFrameworkCore.Metadata.Builders;
using Microsoft.EntityFrameworkCore;
using DidactCore.Entities;

namespace DidactEngine.Services.Contexts.Configurations
{
    public partial class FlowRunConfiguration : IEntityTypeConfiguration<FlowRun>
    {
        public void Configure(EntityTypeBuilder<FlowRun> entity)
        {
            //entity.ToTable(nameof(FlowRun));
            //entity.Property(e => e.Name).IsRequired().HasMaxLength(255);
            //entity.Property(e => e.StateLastUpdatedBy).HasMaxLength(255);
            //entity.Property(e => e.CreatedBy).HasMaxLength(255);
            //entity.Property(e => e.LastUpdatedBy).HasMaxLength(255);
            //entity.Property(e => e.Active).IsRequired().HasDefaultValue(true);
            //entity.Property(e => e.RowVersion).IsRowVersion().IsConcurrencyToken();

            //entity.HasOne(d => d.Flow)
            //    .WithMany(p => p.FlowRuns)
            //    .HasForeignKey(d => d.FlowId)
            //    .OnDelete(DeleteBehavior.ClientSetNull)
            //    .HasConstraintName($"FK_{nameof(FlowRun)}_{nameof(Flow)}");

            //entity.HasOne(d => d.Organization)
            //    .WithMany(p => p.FlowRuns)
            //    .HasForeignKey(d => d.OrganizationId)
            //    .OnDelete(DeleteBehavior.ClientSetNull)
            //    .HasConstraintName($"FK_{nameof(FlowRun)}_{nameof(Organization)}");

            //entity.HasOne(d => d.TriggerType)
            //    .WithMany(p => p.FlowRuns)
            //    .HasForeignKey(d => d.TriggerTypeId)
            //    .OnDelete(DeleteBehavior.ClientSetNull)
            //    .HasConstraintName($"FK_{nameof(FlowRun)}_{nameof(TriggerType)}");

            //entity.HasOne(d => d.ExecutionMode)
            //    .WithMany(p => p.FlowRuns)
            //    .HasForeignKey(d => d.ExecutionModeId)
            //    .OnDelete(DeleteBehavior.ClientSetNull)
            //    .HasConstraintName($"FK_{nameof(FlowRun)}_{nameof(ExecutionMode)}");

            //entity.HasOne(d => d.State)
            //    .WithMany(p => p.FlowRuns)
            //    .HasForeignKey(d => d.StateId)
            //    .OnDelete(DeleteBehavior.ClientSetNull)
            //    .HasConstraintName($"FK_{nameof(FlowRun)}_{nameof(State)}");

            OnConfigurePartial(entity);
        }

        partial void OnConfigurePartial(EntityTypeBuilder<FlowRun> entity);
    }
}