using System.ComponentModel.DataAnnotations.Schema;
using System.Data.Entity.ModelConfiguration;

namespace DataAccess.Models.Mapping
{
    public class ColourMap : EntityTypeConfiguration<Colour>
    {
        public ColourMap()
        {
            // Primary Key
            this.HasKey(t => t.ColourID);

            // Properties
            this.Property(t => t.Name)
                .IsRequired();

            this.Property(t => t.ShopColour)
                .IsRequired();

            // Table & Column Mappings
            this.ToTable("Colour");
            this.Property(t => t.ColourID).HasColumnName("ColourID");
            this.Property(t => t.Name).HasColumnName("Name");
            this.Property(t => t.Hex).HasColumnName("Hex");
            this.Property(t => t.ShopColour).HasColumnName("ShopColour");
        }
    }
}
