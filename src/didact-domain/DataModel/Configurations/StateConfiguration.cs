using Microsoft.EntityFrameworkCore.Metadata.Builders;
using Microsoft.EntityFrameworkCore;
using DidactDomain.DataModel.Entities;

namespace DidactDomain.DataModel.Configurations
{
    public partial class StateConfiguration : IEntityTypeConfiguration<FlowRunState>
    {
        public void Configure(EntityTypeBuilder<FlowRunState> entity)
        {
            //entity.ToTable(nameof(State));
            //entity.Property(e => e.Name).IsRequired().HasMaxLength(255);
            //entity.Property(e => e.CreatedBy).HasMaxLength(255);
            //entity.Property(e => e.LastUpdatedBy).HasMaxLength(255);
            //entity.Property(e => e.Active).IsRequired().HasDefaultValue(true);
            //entity.Property(e => e.RowVersion).IsRowVersion().IsConcurrencyToken();

            OnConfigurePartial(entity);
        }

        partial void OnConfigurePartial(EntityTypeBuilder<FlowRunState> entity);
    }
}