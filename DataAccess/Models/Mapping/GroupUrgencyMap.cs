using System.ComponentModel.DataAnnotations.Schema;
using System.Data.Entity.ModelConfiguration;

namespace DataAccess.Models.Mapping
{
    public class GroupUrgencyMap : EntityTypeConfiguration<GroupUrgency>
    {
        public GroupUrgencyMap()
        {
            // Primary Key
            this.HasKey(t => t.GroupUrgencyID);

            // Properties
            this.Property(t => t.Number)
                .IsRequired()
                .HasMaxLength(50);

            // Table & Column Mappings
            this.ToTable("GroupUrgency");
            this.Property(t => t.GroupUrgencyID).HasColumnName("GroupUrgencyID");
            this.Property(t => t.Number).HasColumnName("Number");
            this.Property(t => t.Description).HasColumnName("Description");
        }
    }
}
