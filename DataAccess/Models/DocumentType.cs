using System;
using System.Collections.Generic;

namespace DataAccess.Models
{
    public partial class DocumentType
    {
        public DocumentType()
        {
            this.Files = new List<File>();
        }

        public int DocumentTypeID { get; set; }
        public string Name { get; set; }
        public virtual ICollection<File> Files { get; set; }
    }
}
