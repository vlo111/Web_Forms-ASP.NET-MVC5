using System;
using System.Collections.Generic;

namespace DataAccess.Models
{
    public partial class Shipment
    {
        public Shipment()
        {
            this.Tags = new List<Tag>();
        }

        public int ShipmentID { get; set; }
        public string Name { get; set; }
        public string SpecialInstructions { get; set; }
        public Nullable<System.DateTime> ShipmentDate { get; set; }
        public System.DateTime CreatedDate { get; set; }
        public string CreatedBy { get; set; }
        public string ShippingTimeFrameID { get; set; }
        public int ShippingAddressID { get; set; }
        public virtual ShippingAddress ShippingAddress { get; set; }
        public virtual ICollection<Tag> Tags { get; set; }
    }
}
