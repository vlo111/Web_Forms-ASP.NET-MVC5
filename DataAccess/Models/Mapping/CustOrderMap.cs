using System.ComponentModel.DataAnnotations.Schema;
using System.Data.Entity.ModelConfiguration;

namespace DataAccess.Models.Mapping
{
    public class CustOrderMap : EntityTypeConfiguration<CustOrder>
    {
        public CustOrderMap()
        {
            // Primary Key
            this.HasKey(t => t.CustOrderID);

            // Properties
            this.Property(t => t.InvoiceNo)
                .IsRequired();

            this.Property(t => t.CommentsCentury)
                .IsRequired()
                .IsFixedLength()
                .HasMaxLength(10);

            // Table & Column Mappings
            this.ToTable("CustOrder");
            this.Property(t => t.CustOrderID).HasColumnName("CustOrderID");
            this.Property(t => t.Revision).HasColumnName("Revision");
            this.Property(t => t.CustomerID).HasColumnName("CustomerID");
            this.Property(t => t.PONum).HasColumnName("PONum");
            this.Property(t => t.InvoiceNo).HasColumnName("InvoiceNo");
            this.Property(t => t.CreatedDate).HasColumnName("CreatedDate");
            this.Property(t => t.EmployeeID).HasColumnName("EmployeeID");
            this.Property(t => t.ApproverID).HasColumnName("ApproverID");
            this.Property(t => t.CostTotal).HasColumnName("CostTotal");
            this.Property(t => t.CostCurrencyID).HasColumnName("CostCurrencyID");
            this.Property(t => t.SellTotal).HasColumnName("SellTotal");
            this.Property(t => t.SellCurrencyID).HasColumnName("SellCurrencyID");
            this.Property(t => t.GroupUrgencyID).HasColumnName("GroupUrgencyID");
            this.Property(t => t.DiscountAmountPercentage).HasColumnName("DiscountAmountPercentage");
            this.Property(t => t.CommentsCentury).HasColumnName("CommentsCentury");

            // Relationships
            this.HasMany(t => t.Files)
                .WithMany(t => t.CustOrders)
                .Map(m =>
                    {
                        m.ToTable("CustOrderFiles");
                        m.MapLeftKey("CustOrderID");
                        m.MapRightKey("FileID");
                    });

            this.HasOptional(t => t.Currency)
                .WithMany(t => t.CustOrders)
                .HasForeignKey(d => d.CostCurrencyID);
            this.HasOptional(t => t.Currency1)
                .WithMany(t => t.CustOrders1)
                .HasForeignKey(d => d.SellCurrencyID);
            this.HasRequired(t => t.Customer)
                .WithMany(t => t.CustOrders)
                .HasForeignKey(d => d.CustomerID);
            this.HasRequired(t => t.Employee)
                .WithMany(t => t.CustOrders)
                .HasForeignKey(d => d.EmployeeID);
            this.HasOptional(t => t.Employee1)
                .WithMany(t => t.CustOrders1)
                .HasForeignKey(d => d.ApproverID);

        }
    }
}
