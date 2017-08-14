using System.ComponentModel.DataAnnotations.Schema;
using System.Data.Entity.ModelConfiguration;

namespace DataAccess.Models.Mapping
{
    public class ShippingAddressMap : EntityTypeConfiguration<ShippingAddress>
    {
        public ShippingAddressMap()
        {
            // Primary Key
            this.HasKey(t => t.ShippingAddressID);

            // Properties
            this.Property(t => t.ShippingAddressID)
                .HasDatabaseGeneratedOption(DatabaseGeneratedOption.None);

            this.Property(t => t.ContactFirstName)
                .IsRequired();

            this.Property(t => t.ContactLastName)
                .IsRequired();

            this.Property(t => t.PhoneNo)
                .IsRequired();

            this.Property(t => t.Address1)
                .IsRequired();

            this.Property(t => t.Address2)
                .IsRequired();

            this.Property(t => t.City)
                .IsRequired();

            this.Property(t => t.Country)
                .IsRequired();

            this.Property(t => t.PostalCode)
                .IsRequired();

            // Table & Column Mappings
            this.ToTable("ShippingAddress");
            this.Property(t => t.ShippingAddressID).HasColumnName("ShippingAddressID");
            this.Property(t => t.CustomerID).HasColumnName("CustomerID");
            this.Property(t => t.LastUsed).HasColumnName("LastUsed");
            this.Property(t => t.ContactFirstName).HasColumnName("ContactFirstName");
            this.Property(t => t.ContactLastName).HasColumnName("ContactLastName");
            this.Property(t => t.CellNo).HasColumnName("CellNo");
            this.Property(t => t.PhoneNo).HasColumnName("PhoneNo");
            this.Property(t => t.Address1).HasColumnName("Address1");
            this.Property(t => t.Address2).HasColumnName("Address2");
            this.Property(t => t.City).HasColumnName("City");
            this.Property(t => t.Country).HasColumnName("Country");
            this.Property(t => t.PostalCode).HasColumnName("PostalCode");
            this.Property(t => t.Comments).HasColumnName("Comments");

            // Relationships
            this.HasRequired(t => t.Customer)
                .WithMany(t => t.ShippingAddresses)
                .HasForeignKey(d => d.CustomerID);

        }
    }
}
