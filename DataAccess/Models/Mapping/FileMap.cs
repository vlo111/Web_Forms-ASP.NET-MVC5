using System.ComponentModel.DataAnnotations.Schema;
using System.Data.Entity.ModelConfiguration;

namespace DataAccess.Models.Mapping
{
    public class FileMap : EntityTypeConfiguration<File>
    {
        public FileMap()
        {
            // Primary Key
            this.HasKey(t => t.FileID);

            // Properties
            this.Property(t => t.Name)
                .IsRequired();

            this.Property(t => t.Type)
                .IsRequired();

            this.Property(t => t.Contents)
                .IsRequired();

            // Table & Column Mappings
            this.ToTable("File");
            this.Property(t => t.FileID).HasColumnName("FileID");
            this.Property(t => t.Name).HasColumnName("Name");
            this.Property(t => t.Type).HasColumnName("Type");
            this.Property(t => t.Contents).HasColumnName("Contents");
            this.Property(t => t.DocumentTypeID).HasColumnName("DocumentTypeID");
            this.Property(t => t.EmployeeID).HasColumnName("EmployeeID");

            // Relationships
            this.HasMany(t => t.OrderParts)
                .WithMany(t => t.Files)
                .Map(m =>
                    {
                        m.ToTable("OrderPartFiles");
                        m.MapLeftKey("FileID");
                        m.MapRightKey("OrderPartID");
                    });

            this.HasMany(t => t.Parts)
                .WithMany(t => t.Files)
                .Map(m =>
                    {
                        m.ToTable("PartFiles");
                        m.MapLeftKey("FileID");
                        m.MapRightKey("PartID");
                    });

            this.HasOptional(t => t.DocumentType)
                .WithMany(t => t.Files)
                .HasForeignKey(d => d.DocumentTypeID);

        }
    }
}
