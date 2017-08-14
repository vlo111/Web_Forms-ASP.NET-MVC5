using System;
using System.Collections.Generic;

namespace DataAccess.Models
{
    public partial class Customer
    {
        public Customer()
        {
            this.CustomerContacts = new List<CustomerContact>();
            this.CustOrders = new List<CustOrder>();
            this.ShippingAddresses = new List<ShippingAddress>();
        }

        public int CustomerID { get; set; }
        public string First { get; set; }
        public string Last { get; set; }
        public string Company { get; set; }
        public string ContactEmail { get; set; }
        public string PhoneNo { get; set; }
        public string CellNo { get; set; }
        public string Fax { get; set; }
        public System.DateTime Created { get; set; }
        public Nullable<System.DateTime> Modified { get; set; }
        public int EmployeeID { get; set; }
        public string Address1 { get; set; }
        public string Address2 { get; set; }
        public string City { get; set; }
        public string Country { get; set; }
        public string PostalCode { get; set; }
        public string Comments { get; set; }
        public bool GSTExempt { get; set; }
        public bool PSTExempt { get; set; }
        public virtual ICollection<CustomerContact> CustomerContacts { get; set; }
        public virtual ICollection<CustOrder> CustOrders { get; set; }
        public virtual ICollection<ShippingAddress> ShippingAddresses { get; set; }
    }
}
