using System;
using System.Collections.Generic;

namespace DataAccess.Models
{
    public partial class File
    {
        public File()
        {
            this.CustOrders = new List<CustOrder>();
            this.OrderParts = new List<OrderPart>();
            this.Parts = new List<Part>();
            this.Tags = new List<Tag>();
        }

        public int FileID { get; set; }
        public string Name { get; set; }
        public string Type { get; set; }
        public byte[] Contents { get; set; }
        public Nullable<int> DocumentTypeID { get; set; }
        public int EmployeeID { get; set; }
        public virtual DocumentType DocumentType { get; set; }
        public virtual ICollection<CustOrder> CustOrders { get; set; }
        public virtual ICollection<OrderPart> OrderParts { get; set; }
        public virtual ICollection<Part> Parts { get; set; }
        public virtual ICollection<Tag> Tags { get; set; }
    }
}
