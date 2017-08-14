using System.ComponentModel.DataAnnotations.Schema;
using System.Data.Entity.ModelConfiguration;

namespace DataAccess.Models.Mapping
{
    public class ShipmentMap : EntityTypeConfiguration<Shipment>
    {
        public ShipmentMap()
        {
            // Primary Key
            this.HasKey(t => t.ShipmentID);

            // Properties
            this.Property(t => t.Name)
                .IsRequired()
                .HasMaxLength(50);

            this.Property(t => t.CreatedBy)
                .IsRequired()
                .HasMaxLength(50);

            this.Property(t => t.ShippingTimeFrameID)
                .IsFixedLength()
                .HasMaxLength(10);

            // Table & Column Mappings
            this.ToTable("Shipment");
            this.Property(t => t.ShipmentID).HasColumnName("ShipmentID");
            this.Property(t => t.Name).HasColumnName("Name");
            this.Property(t => t.SpecialInstructions).HasColumnName("SpecialInstructions");
            this.Property(t => t.ShipmentDate).HasColumnName("ShipmentDate");
            this.Property(t => t.CreatedDate).HasColumnName("CreatedDate");
            this.Property(t => t.CreatedBy).HasColumnName("CreatedBy");
            this.Property(t => t.ShippingTimeFrameID).HasColumnName("ShippingTimeFrameID");
            this.Property(t => t.ShippingAddressID).HasColumnName("ShippingAddressID");

            // Relationships
            this.HasRequired(t => t.ShippingAddress)
                .WithMany(t => t.Shipments)
                .HasForeignKey(d => d.ShippingAddressID);

        }
    }
}
