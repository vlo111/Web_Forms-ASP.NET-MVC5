using System.ComponentModel.DataAnnotations.Schema;
using System.Data.Entity.ModelConfiguration;

namespace DataAccess.Models.Mapping
{
    public class DocumentTypeMap : EntityTypeConfiguration<DocumentType>
    {
        public DocumentTypeMap()
        {
            // Primary Key
            this.HasKey(t => t.DocumentTypeID);

            // Properties
            this.Property(t => t.Name)
                .IsRequired();

            // Table & Column Mappings
            this.ToTable("DocumentType");
            this.Property(t => t.DocumentTypeID).HasColumnName("DocumentTypeID");
            this.Property(t => t.Name).HasColumnName("Name");
        }
    }
}
