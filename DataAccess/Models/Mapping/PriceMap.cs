using System.ComponentModel.DataAnnotations.Schema;
using System.Data.Entity.ModelConfiguration;

namespace DataAccess.Models.Mapping
{
    public class PriceMap : EntityTypeConfiguration<Price>
    {
        public PriceMap()
        {
            // Primary Key
            this.HasKey(t => t.PriceID);

            // Properties
            this.Property(t => t.PriceID)
                .HasDatabaseGeneratedOption(DatabaseGeneratedOption.None);

            // Table & Column Mappings
            this.ToTable("Price");
            this.Property(t => t.PriceID).HasColumnName("PriceID");
            this.Property(t => t.PartID).HasColumnName("PartID");
            this.Property(t => t.ValidStart).HasColumnName("ValidStart");
            this.Property(t => t.ValidEnd).HasColumnName("ValidEnd");
            this.Property(t => t.DateCreated).HasColumnName("DateCreated");
            this.Property(t => t.CostValue).HasColumnName("CostValue");
            this.Property(t => t.CostCurrencyID).HasColumnName("CostCurrencyID");
            this.Property(t => t.SellValue).HasColumnName("SellValue");
            this.Property(t => t.SellCurrencyID).HasColumnName("SellCurrencyID");
            this.Property(t => t.EmployeeID).HasColumnName("EmployeeID");

            // Relationships
            this.HasRequired(t => t.Currency)
                .WithMany(t => t.Prices)
                .HasForeignKey(d => d.CostCurrencyID);
            this.HasRequired(t => t.Currency1)
                .WithMany(t => t.Prices1)
                .HasForeignKey(d => d.SellCurrencyID);
            this.HasRequired(t => t.Employee)
                .WithMany(t => t.Prices)
                .HasForeignKey(d => d.EmployeeID);
            this.HasRequired(t => t.Part)
                .WithMany(t => t.Prices)
                .HasForeignKey(d => d.PartID);

        }
    }
}
