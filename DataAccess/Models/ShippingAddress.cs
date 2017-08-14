using System;
using System.Collections.Generic;

namespace DataAccess.Models
{
    public partial class ShippingAddress
    {
        public ShippingAddress()
        {
            this.Shipments = new List<Shipment>();
        }

        public int ShippingAddressID { get; set; }
        public int CustomerID { get; set; }
        public System.DateTime LastUsed { get; set; }
        public string ContactFirstName { get; set; }
        public string ContactLastName { get; set; }
        public string CellNo { get; set; }
        public string PhoneNo { get; set; }
        public string Address1 { get; set; }
        public string Address2 { get; set; }
        public string City { get; set; }
        public string Country { get; set; }
        public string PostalCode { get; set; }
        public string Comments { get; set; }
        public virtual Customer Customer { get; set; }
        public virtual ICollection<Shipment> Shipments { get; set; }
    }
}
