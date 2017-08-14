using System.ComponentModel.DataAnnotations.Schema;
using System.Data.Entity.ModelConfiguration;

namespace DataAccess.Models.Mapping
{
    public class AltPartIDMap : EntityTypeConfiguration<AltPartID>
    {
        public AltPartIDMap()
        {
            // Primary Key
            this.HasKey(t => t.AltPartID1);

            // Properties
            this.Property(t => t.PartNo)
                .IsRequired();

            // Table & Column Mappings
            this.ToTable("AltPartID");
            this.Property(t => t.AltPartID1).HasColumnName("AltPartID");
            this.Property(t => t.PartID).HasColumnName("PartID");
            this.Property(t => t.PartNo).HasColumnName("PartNo");

            // Relationships
            this.HasRequired(t => t.Part)
                .WithMany(t => t.AltPartIDs)
                .HasForeignKey(d => d.PartID);

        }
    }
}
