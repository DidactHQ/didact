using Microsoft.EntityFrameworkCore.Metadata.Builders;
using Microsoft.EntityFrameworkCore;
using DidactCore.Entities;

namespace DidactEngine.Services.Contexts.Configurations
{
    public partial class FlowScheduleConfiguration : IEntityTypeConfiguration<FlowSchedule>
    {
        public void Configure(EntityTypeBuilder<FlowSchedule> entity)
        {
            //entity.ToTable(nameof(FlowSchedule));
            //entity.Property(e => e.CronExpression).IsRequired().HasMaxLength(255);
            //entity.Property(e => e.CreatedBy).HasMaxLength(255);
            //entity.Property(e => e.LastUpdatedBy).HasMaxLength(255);
            //entity.Property(e => e.Active).IsRequired().HasDefaultValue(true);
            //entity.Property(e => e.RowVersion).IsRowVersion().IsConcurrencyToken();

            OnConfigurePartial(entity);
        }

        partial void OnConfigurePartial(EntityTypeBuilder<FlowSchedule> entity);
    }
}