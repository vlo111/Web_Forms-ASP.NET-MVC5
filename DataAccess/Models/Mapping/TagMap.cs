using System.ComponentModel.DataAnnotations.Schema;
using System.Data.Entity.ModelConfiguration;

namespace DataAccess.Models.Mapping
{
    public class TagMap : EntityTypeConfiguration<Tag>
    {
        public TagMap()
        {
            // Primary Key
            this.HasKey(t => t.TagID);

            // Properties
            this.Property(t => t.TagName)
                .IsRequired()
                .HasMaxLength(150);

            // Table & Column Mappings
            this.ToTable("Tag");
            this.Property(t => t.TagID).HasColumnName("TagID");
            this.Property(t => t.OrderID).HasColumnName("OrderID");
            this.Property(t => t.TagName).HasColumnName("TagName");
            this.Property(t => t.ShipmentID).HasColumnName("ShipmentID");

            // Relationships
            this.HasMany(t => t.Files)
                .WithMany(t => t.Tags)
                .Map(m =>
                    {
                        m.ToTable("TagFiles");
                        m.MapLeftKey("TagID");
                        m.MapRightKey("FileID");
                    });

            this.HasOptional(t => t.Shipment)
                .WithMany(t => t.Tags)
                .HasForeignKey(d => d.ShipmentID);

        }
    }
}
