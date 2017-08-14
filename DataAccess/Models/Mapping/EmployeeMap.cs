using System.ComponentModel.DataAnnotations.Schema;
using System.Data.Entity.ModelConfiguration;

namespace DataAccess.Models.Mapping
{
    public class EmployeeMap : EntityTypeConfiguration<Employee>
    {
        public EmployeeMap()
        {
            // Primary Key
            this.HasKey(t => t.EmployeeID);

            // Properties
            this.Property(t => t.EmployeeLookupID)
                .IsRequired();

            this.Property(t => t.FirstName)
                .IsRequired();

            this.Property(t => t.LastName)
                .IsRequired();

            this.Property(t => t.EmailAddress)
                .IsRequired();

            // Table & Column Mappings
            this.ToTable("Employee");
            this.Property(t => t.EmployeeID).HasColumnName("EmployeeID");
            this.Property(t => t.EmployeeLookupID).HasColumnName("EmployeeLookupID");
            this.Property(t => t.FirstName).HasColumnName("FirstName");
            this.Property(t => t.LastName).HasColumnName("LastName");
            this.Property(t => t.EmailAddress).HasColumnName("EmailAddress");
        }
    }
}
