using System.ComponentModel.DataAnnotations.Schema;
using System.Data.Entity.ModelConfiguration;

namespace DataAccess.Models.Mapping
{
    public class ImageMap : EntityTypeConfiguration<Image>
    {
        public ImageMap()
        {
            // Primary Key
            this.HasKey(t => t.ImageID);

            // Properties
            this.Property(t => t.Name)
                .IsRequired();

            this.Property(t => t.Ext)
                .IsRequired()
                .HasMaxLength(3);

            this.Property(t => t.Image1)
                .IsRequired();

            // Table & Column Mappings
            this.ToTable("Image");
            this.Property(t => t.ImageID).HasColumnName("ImageID");
            this.Property(t => t.Name).HasColumnName("Name");
            this.Property(t => t.Ext).HasColumnName("Ext");
            this.Property(t => t.Image1).HasColumnName("Image");
        }
    }
}
