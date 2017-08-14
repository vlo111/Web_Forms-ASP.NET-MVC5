using System.ComponentModel.DataAnnotations.Schema;
using System.Data.Entity.ModelConfiguration;

namespace DataAccess.Models.Mapping
{
    public class ProductLineMap : EntityTypeConfiguration<ProductLine>
    {
        public ProductLineMap()
        {
            // Primary Key
            this.HasKey(t => t.ProductLineID);

            // Properties
            this.Property(t => t.Name)
                .IsRequired();

            // Table & Column Mappings
            this.ToTable("ProductLine");
            this.Property(t => t.ProductLineID).HasColumnName("ProductLineID");
            this.Property(t => t.Name).HasColumnName("Name");
            this.Property(t => t.Description).HasColumnName("Description");
        }
    }
}
