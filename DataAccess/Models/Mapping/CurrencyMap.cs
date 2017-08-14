using System.ComponentModel.DataAnnotations.Schema;
using System.Data.Entity.ModelConfiguration;

namespace DataAccess.Models.Mapping
{
    public class CurrencyMap : EntityTypeConfiguration<Currency>
    {
        public CurrencyMap()
        {
            // Primary Key
            this.HasKey(t => t.CurrencyID);

            // Properties
            this.Property(t => t.Code)
                .IsRequired()
                .HasMaxLength(3);

            this.Property(t => t.Name)
                .IsRequired();

            // Table & Column Mappings
            this.ToTable("Currency");
            this.Property(t => t.CurrencyID).HasColumnName("CurrencyID");
            this.Property(t => t.Code).HasColumnName("Code");
            this.Property(t => t.Name).HasColumnName("Name");
        }
    }
}
