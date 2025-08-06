using Microsoft.EntityFrameworkCore.Metadata.Builders;
using Microsoft.EntityFrameworkCore;
using DidactCore.Entities;

namespace DidactEngine.Services.Contexts.Configurations
{
    public partial class FlowConfiguration : IEntityTypeConfiguration<Flow>
    {
        public void Configure(EntityTypeBuilder<Flow> entity)
        {
            //entity.ToTable(nameof(Flow));
            //entity.HasIndex(e => e.Name).IsUnique();
            //entity.Property(e => e.Name).IsRequired().HasMaxLength(255);
            //entity.Property(e => e.Version).HasMaxLength(255);
            //entity.Property(e => e.TypeName).IsRequired();
            //entity.Property(e => e.CreatedBy).HasMaxLength(255);
            //entity.Property(e => e.LastUpdatedBy).HasMaxLength(255);
            //entity.Property(e => e.Active).IsRequired().HasDefaultValue(true);
            //entity.Property(e => e.RowVersion).IsRowVersion().IsConcurrencyToken();

            //entity.HasOne(d => d.Organization)
            //    .WithMany(p => p.Flows)
            //    .HasForeignKey(d => d.OrganizationId)
            //    .OnDelete(DeleteBehavior.ClientSetNull)
            //    .HasConstraintName($"FK_{nameof(Flow)}_{nameof(Organization)}");

            //entity.HasOne(d => d.ExecutionMode)
            //    .WithMany(p => p.Flows)
            //    .HasForeignKey(d => d.ExecutionModeId)
            //    .OnDelete(DeleteBehavior.ClientSetNull)
            //    .HasConstraintName($"FK_{nameof(Flow)}_{nameof(ExecutionMode)}");

            OnConfigurePartial(entity);
        }

        partial void OnConfigurePartial(EntityTypeBuilder<Flow> entity);
    }
}