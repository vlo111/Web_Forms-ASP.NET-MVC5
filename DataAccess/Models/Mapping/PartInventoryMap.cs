using System.ComponentModel.DataAnnotations.Schema;
using System.Data.Entity.ModelConfiguration;

namespace DataAccess.Models.Mapping
{
    public class PartInventoryMap : EntityTypeConfiguration<PartInventory>
    {
        public PartInventoryMap()
        {
            // Primary Key
            this.HasKey(t => t.PartInventoryID);

            // Properties
            this.Property(t => t.PartInventoryID)
                .HasDatabaseGeneratedOption(DatabaseGeneratedOption.None);

            this.Property(t => t.PartID)
                .HasDatabaseGeneratedOption(DatabaseGeneratedOption.Identity);

            // Table & Column Mappings
            this.ToTable("PartInventory");
            this.Property(t => t.PartInventoryID).HasColumnName("PartInventoryID");
            this.Property(t => t.PartID).HasColumnName("PartID");

            // Relationships
            this.HasRequired(t => t.Part)
                .WithMany(t => t.PartInventories)
                .HasForeignKey(d => d.PartID);

        }
    }
}
