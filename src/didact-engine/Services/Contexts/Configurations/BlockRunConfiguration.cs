using Microsoft.EntityFrameworkCore.Metadata.Builders;
using Microsoft.EntityFrameworkCore;
using DidactCore.Entities;

namespace DidactEngine.Services.Contexts.Configurations
{
    public partial class BlockRunConfiguration : IEntityTypeConfiguration<BlockRun>
    {
        public void Configure(EntityTypeBuilder<BlockRun> entity)
        {
            //entity.ToTable(nameof(BlockRun));
            //entity.Property(e => e.BlockName).HasMaxLength(255);
            //entity.Property(e => e.Name).HasMaxLength(255);
            //entity.Property(e => e.StateLastUpdatedBy).HasMaxLength(255);
            //entity.Property(e => e.CreatedBy).HasMaxLength(255);
            //entity.Property(e => e.LastUpdatedBy).HasMaxLength(255);
            //entity.Property(e => e.Active).IsRequired().HasDefaultValue(true);
            //entity.Property(e => e.RowVersion).IsRowVersion().IsConcurrencyToken();

            //entity.HasOne(d => d.FlowRun)
            //    .WithMany(p => p.BlockRuns)
            //    .HasForeignKey(d => d.FlowRunId)
            //    .OnDelete(DeleteBehavior.ClientSetNull)
            //    .HasConstraintName($"FK_{nameof(BlockRun)}_{nameof(FlowRun)}");

            //entity.HasOne(d => d.Organization)
            //    .WithMany(p => p.BlockRuns)
            //    .HasForeignKey(d => d.OrganizationId)
            //    .OnDelete(DeleteBehavior.ClientSetNull)
            //    .HasConstraintName($"FK_{nameof(BlockRun)}_{nameof(Organization)}");

            //entity.HasOne(d => d.State)
            //    .WithMany(p => p.BlockRuns)
            //    .HasForeignKey(d => d.StateId)
            //    .OnDelete(DeleteBehavior.ClientSetNull)
            //    .HasConstraintName($"FK_{nameof(BlockRun)}_{nameof(State)}");

            OnConfigurePartial(entity);
        }

        partial void OnConfigurePartial(EntityTypeBuilder<BlockRun> entity);
    }
}