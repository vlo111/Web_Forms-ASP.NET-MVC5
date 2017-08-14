using System;
using System.Collections.Generic;
using System.Data.Entity.ModelConfiguration;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DataAccess.Models.Mapping
{
    class FileTmpMap : EntityTypeConfiguration<FileTmp>
    {
        public FileTmpMap()
        {
            // Primary Key
            this.HasKey(t => t.ID);

            // Table & Column Mappings
            this.ToTable("FileTmp");
            this.Property(t => t.ID).HasColumnName("ID");
            this.Property(t => t.Name).HasColumnName("Name");
            this.Property(t => t.Type).HasColumnName("Type");
            this.Property(t => t.Contents).HasColumnName("Contents");
            this.Property(t => t.emp).HasColumnName("Emp");
            this.Property(t => t.doc).HasColumnName("Doc");
        }
    }
}