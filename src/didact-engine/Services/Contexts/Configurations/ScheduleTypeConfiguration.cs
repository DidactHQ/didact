using Microsoft.EntityFrameworkCore.Metadata.Builders;
using Microsoft.EntityFrameworkCore;
using DidactCore.Entities;

namespace DidactEngine.Services.Contexts.Configurations
{
    public partial class ScheduleTypeConfiguration : IEntityTypeConfiguration<ScheduleType>
    {
        public void Configure(EntityTypeBuilder<ScheduleType> entity)
        {
            //entity.ToTable(nameof(ScheduleType));
            //entity.Property(e => e.Name).IsRequired().HasMaxLength(255);
            //entity.Property(e => e.CreatedBy).HasMaxLength(255);
            //entity.Property(e => e.LastUpdatedBy).HasMaxLength(255);
            //entity.Property(e => e.Active).IsRequired().HasDefaultValue(true);
            //entity.Property(e => e.RowVersion).IsRowVersion().IsConcurrencyToken();

            OnConfigurePartial(entity);
        }

        partial void OnConfigurePartial(EntityTypeBuilder<ScheduleType> entity);
    }
}