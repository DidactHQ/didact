using Microsoft.EntityFrameworkCore.Metadata.Builders;
using Microsoft.EntityFrameworkCore;
using DidactCore.Entities;

namespace DidactEngine.Services.Contexts.Configurations
{
    public partial class StrictQueueItemConfiguration : IEntityTypeConfiguration<StrictQueueItem>
    {
        public void Configure(EntityTypeBuilder<StrictQueueItem> entity)
        {
            //entity.ToTable(nameof(StrictQueueItem));
            //entity.Property(e => e.CreatedBy).HasMaxLength(255);
            //entity.Property(e => e.LastUpdatedBy).HasMaxLength(255);
            //entity.Property(e => e.RowVersion).IsRowVersion().IsConcurrencyToken();

            //entity.HasOne(d => d.Organization)
            //    .WithMany(p => p.FifoQueueInbounds)
            //    .HasForeignKey(d => d.OrganizationId)
            //    .OnDelete(DeleteBehavior.ClientSetNull)
            //    .HasConstraintName($"FK_{nameof(StrictQueueItem)}_{nameof(Organization)}");

            //entity.HasOne(d => d.FlowRun)
            //    .WithMany(p => p.FifoQueueInbounds)
            //    .HasForeignKey(d => d.FlowRunId)
            //    .OnDelete(DeleteBehavior.ClientSetNull)
            //    .HasConstraintName($"FK_{nameof(StrictQueueItem)}_{nameof(FlowRun)}");

            //entity.HasOne(d => d.FifoQueue)
            //    .WithMany(p => p.FifoQueueInbounds)
            //    .HasForeignKey(d => d.FifoQueueId)
            //    .OnDelete(DeleteBehavior.ClientSetNull)
            //    .HasConstraintName($"FK_{nameof(StrictQueueItem)}_{nameof(StrictQueue)}");

            OnConfigurePartial(entity);
        }

        partial void OnConfigurePartial(EntityTypeBuilder<StrictQueueItem> entity);
    }
}