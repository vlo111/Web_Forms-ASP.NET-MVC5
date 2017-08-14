using System;
using System.Collections.Generic;

namespace DataAccess.Models
{
    public partial class Tag
    {
        public Tag()
        {
            this.OrderParts = new List<OrderPart>();
            this.Files = new List<File>();
        }

        public int TagID { get; set; }
        public int OrderID { get; set; }
        public string TagName { get; set; }
        public Nullable<int> ShipmentID { get; set; }
        public virtual Shipment Shipment { get; set; }
        public virtual ICollection<OrderPart> OrderParts { get; set; }
        public virtual ICollection<File> Files { get; set; }
    }
}
