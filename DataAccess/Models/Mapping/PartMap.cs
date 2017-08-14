using System.ComponentModel.DataAnnotations.Schema;
using System.Data.Entity.ModelConfiguration;

namespace DataAccess.Models.Mapping
{
    public class PartMap : EntityTypeConfiguration<Part>
    {
        public PartMap()
        {
            // Primary Key
            this.HasKey(t => t.PartID);

            // Properties
            this.Property(t => t.Name)
                .IsRequired();

            // Table & Column Mappings
            this.ToTable("Part");
            this.Property(t => t.PartID).HasColumnName("PartID");
            this.Property(t => t.AltPartID).HasColumnName("AltPartID");
            this.Property(t => t.Name).HasColumnName("Name");
            this.Property(t => t.Description).HasColumnName("Description");
            this.Property(t => t.ProductLineID).HasColumnName("ProductLineID");
            this.Property(t => t.CategoryID).HasColumnName("CategoryID");
            this.Property(t => t.ImageID).HasColumnName("ImageID");
            this.Property(t => t.PartStatusID).HasColumnName("PartStatusID");
            this.Property(t => t.CustomFlag).HasColumnName("CustomFlag");
            this.Property(t => t.Comments).HasColumnName("Comments");
            this.Property(t => t.CreatedDate).HasColumnName("CreatedDate");
            this.Property(t => t.ModifiedDate).HasColumnName("ModifiedDate");
            this.Property(t => t.EmployeeID).HasColumnName("EmployeeID");
            this.Property(t => t.Weight).HasColumnName("Weight");
            this.Property(t => t.Height).HasColumnName("Height");
            this.Property(t => t.Width).HasColumnName("Width");
            this.Property(t => t.Length).HasColumnName("Length");
            this.Property(t => t.PriceID).HasColumnName("PriceID");
            this.Property(t => t.MeasUnitID).HasColumnName("MeasUnitID");
            this.Property(t => t.PartInventoryID).HasColumnName("PartInventoryID");

            // Relationships
            this.HasRequired(t => t.Category)
                .WithMany(t => t.Parts)
                .HasForeignKey(d => d.CategoryID);
            this.HasRequired(t => t.Employee)
                .WithMany(t => t.Parts)
                .HasForeignKey(d => d.EmployeeID);
            this.HasOptional(t => t.Image)
                .WithMany(t => t.Parts)
                .HasForeignKey(d => d.ImageID);
            this.HasRequired(t => t.MeasUnit)
                .WithMany(t => t.Parts)
                .HasForeignKey(d => d.MeasUnitID);
            this.HasOptional(t => t.PartStatu)
                .WithMany(t => t.Parts)
                .HasForeignKey(d => d.PartStatusID);
            this.HasRequired(t => t.ProductLine)
                .WithMany(t => t.Parts)
                .HasForeignKey(d => d.ProductLineID);

        }
    }
}
