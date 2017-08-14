using System.ComponentModel.DataAnnotations.Schema;
using System.Data.Entity.ModelConfiguration;

namespace DataAccess.Models.Mapping
{
    public class PartStatuMap : EntityTypeConfiguration<PartStatu>
    {
        public PartStatuMap()
        {
            // Primary Key
            this.HasKey(t => t.PartStatusID);

            // Properties
            this.Property(t => t.Status)
                .IsRequired();

            // Table & Column Mappings
            this.ToTable("PartStatus");
            this.Property(t => t.PartStatusID).HasColumnName("PartStatusID");
            this.Property(t => t.Status).HasColumnName("Status");
        }
    }
}
