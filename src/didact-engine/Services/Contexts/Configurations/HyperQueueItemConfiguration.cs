using Microsoft.EntityFrameworkCore.Metadata.Builders;
using Microsoft.EntityFrameworkCore;
using DidactCore.Entities;

namespace DidactEngine.Services.Contexts.Configurations
{
    public partial class HyperQueueItemConfiguration : IEntityTypeConfiguration<HyperQueueItem>
    {
        public void Configure(EntityTypeBuilder<HyperQueueItem> entity)
        {
            entity.ToTable(nameof(HyperQueueItem));
            entity.Property(e => e.CreatedBy).HasMaxLength(255);
            entity.Property(e => e.UpdatedBy).HasMaxLength(255);
            entity.Property(e => e.RowVersion).IsRowVersion().IsConcurrencyToken();

            //entity.HasOne(d => d.Organization)
            //    .WithMany(p => p.HyperQueueInbounds)
            //    .HasForeignKey(d => d.OrganizationId)
            //    .OnDelete(DeleteBehavior.ClientSetNull)
            //    .HasConstraintName($"FK_{nameof(HyperQueueItem)}_{nameof(Organization)}");

            //entity.HasOne(d => d.FlowRun)
            //    .WithMany(p => p.HyperQueueInbounds)
            //    .HasForeignKey(d => d.FlowRunId)
            //    .OnDelete(DeleteBehavior.ClientSetNull)
            //    .HasConstraintName($"FK_{nameof(HyperQueueItem)}_{nameof(FlowRun)}");

            //entity.HasOne(d => d.HyperQueue)
            //    .WithMany(p => p.HyperQueueInbounds)
            //    .HasForeignKey(d => d.HyperQueueId)
            //    .OnDelete(DeleteBehavior.ClientSetNull)
            //    .HasConstraintName($"FK_{nameof(HyperQueueItem)}_${nameof(HyperQueue)}");

            OnConfigurePartial(entity);
        }

        partial void OnConfigurePartial(EntityTypeBuilder<HyperQueueItem> entity);
    }
}