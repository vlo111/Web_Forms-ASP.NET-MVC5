using System.ComponentModel.DataAnnotations.Schema;
using System.Data.Entity.ModelConfiguration;

namespace DataAccess.Models.Mapping
{
    public class CustomerMap : EntityTypeConfiguration<Customer>
    {
        public CustomerMap()
        {
            // Primary Key
            this.HasKey(t => t.CustomerID);

            // Properties
            this.Property(t => t.First)
                .IsRequired();

            this.Property(t => t.Last)
                .IsRequired();

            this.Property(t => t.Company)
                .IsRequired();

            this.Property(t => t.PhoneNo)
                .IsRequired();

            // Table & Column Mappings
            this.ToTable("Customer");
            this.Property(t => t.CustomerID).HasColumnName("CustomerID");
            this.Property(t => t.First).HasColumnName("First");
            this.Property(t => t.Last).HasColumnName("Last");
            this.Property(t => t.Company).HasColumnName("Company");
            this.Property(t => t.ContactEmail).HasColumnName("ContactEmail");
            this.Property(t => t.PhoneNo).HasColumnName("PhoneNo");
            this.Property(t => t.CellNo).HasColumnName("CellNo");
            this.Property(t => t.Fax).HasColumnName("Fax");
            this.Property(t => t.Created).HasColumnName("Created");
            this.Property(t => t.Modified).HasColumnName("Modified");
            this.Property(t => t.EmployeeID).HasColumnName("EmployeeID");
            this.Property(t => t.Address1).HasColumnName("Address1");
            this.Property(t => t.Address2).HasColumnName("Address2");
            this.Property(t => t.City).HasColumnName("City");
            this.Property(t => t.Country).HasColumnName("Country");
            this.Property(t => t.PostalCode).HasColumnName("PostalCode");
            this.Property(t => t.Comments).HasColumnName("Comments");
            this.Property(t => t.GSTExempt).HasColumnName("GSTExempt");
            this.Property(t => t.PSTExempt).HasColumnName("PSTExempt");
        }
    }
}
