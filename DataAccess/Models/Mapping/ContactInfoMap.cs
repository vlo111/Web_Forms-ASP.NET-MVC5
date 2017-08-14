using System.ComponentModel.DataAnnotations.Schema;
using System.Data.Entity.ModelConfiguration;

namespace DataAccess.Models.Mapping
{
    public class ContactInfoMap : EntityTypeConfiguration<ContactInfo>
    {
        public ContactInfoMap()
        {
            // Primary Key
            this.HasKey(t => t.ContactInfoID);

            // Properties
            this.Property(t => t.Name)
                .IsRequired()
                .HasMaxLength(50);

            this.Property(t => t.Contact)
                .HasMaxLength(150);

            // Table & Column Mappings
            this.ToTable("ContactInfo");
            this.Property(t => t.ContactInfoID).HasColumnName("ContactInfoID");
            this.Property(t => t.ContactInfoTypeID).HasColumnName("ContactInfoTypeID");
            this.Property(t => t.CustomerContactID).HasColumnName("CustomerContactID");
            this.Property(t => t.Name).HasColumnName("Name");
            this.Property(t => t.Contact).HasColumnName("Contact");
            this.Property(t => t.PrimaryContact).HasColumnName("PrimaryContact");
        }
    }
}
