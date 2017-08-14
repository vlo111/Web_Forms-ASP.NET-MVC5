using System.ComponentModel.DataAnnotations.Schema;
using System.Data.Entity.ModelConfiguration;

namespace DataAccess.Models.Mapping
{
    public class ContactInfoTypeMap : EntityTypeConfiguration<ContactInfoType>
    {
        public ContactInfoTypeMap()
        {
            // Primary Key
            this.HasKey(t => new { t.ContactInfoTypeID, t.Name });

            // Properties
            this.Property(t => t.ContactInfoTypeID)
                .HasDatabaseGeneratedOption(DatabaseGeneratedOption.None);

            this.Property(t => t.Name)
                .IsRequired()
                .HasMaxLength(50);

            // Table & Column Mappings
            this.ToTable("ContactInfoType");
            this.Property(t => t.ContactInfoTypeID).HasColumnName("ContactInfoTypeID");
            this.Property(t => t.Name).HasColumnName("Name");
        }
    }
}
