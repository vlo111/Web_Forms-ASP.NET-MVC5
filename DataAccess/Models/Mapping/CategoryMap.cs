using System.ComponentModel.DataAnnotations.Schema;
using System.Data.Entity.ModelConfiguration;

namespace DataAccess.Models.Mapping
{
    public class CategoryMap : EntityTypeConfiguration<Category>
    {
        public CategoryMap()
        {
            // Primary Key
            this.HasKey(t => t.CategoryID);

            // Properties
            this.Property(t => t.Name)
                .IsRequired();

            // Table & Column Mappings
            this.ToTable("Category");
            this.Property(t => t.CategoryID).HasColumnName("CategoryID");
            this.Property(t => t.Name).HasColumnName("Name");
            this.Property(t => t.CategoryParentID).HasColumnName("CategoryParentID");
        }
    }
}
