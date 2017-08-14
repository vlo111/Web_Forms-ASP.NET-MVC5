using System.ComponentModel.DataAnnotations.Schema;
using System.Data.Entity.ModelConfiguration;

namespace DataAccess.Models.Mapping
{
    public class MeasUnitMap : EntityTypeConfiguration<MeasUnit>
    {
        public MeasUnitMap()
        {
            // Primary Key
            this.HasKey(t => t.MeasUnitID);

            // Properties
            this.Property(t => t.ShortDescription)
                .IsRequired()
                .HasMaxLength(50);

            this.Property(t => t.LongDescription)
                .IsRequired()
                .HasMaxLength(50);

            // Table & Column Mappings
            this.ToTable("MeasUnit");
            this.Property(t => t.MeasUnitID).HasColumnName("MeasUnitID");
            this.Property(t => t.ShortDescription).HasColumnName("ShortDescription");
            this.Property(t => t.LongDescription).HasColumnName("LongDescription");
        }
    }
}
