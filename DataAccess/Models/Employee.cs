using System;
using System.Collections.Generic;

namespace DataAccess.Models
{
    public partial class Employee
    {
        public Employee()
        {
            this.CustOrders = new List<CustOrder>();
            this.CustOrders1 = new List<CustOrder>();
            this.Parts = new List<Part>();
            this.Prices = new List<Price>();
        }

        public int EmployeeID { get; set; }
        public string EmployeeLookupID { get; set; }
        public string FirstName { get; set; }
        public string LastName { get; set; }
        public string EmailAddress { get; set; }
        public virtual ICollection<CustOrder> CustOrders { get; set; }
        public virtual ICollection<CustOrder> CustOrders1 { get; set; }
        public virtual ICollection<Part> Parts { get; set; }
        public virtual ICollection<Price> Prices { get; set; }
    }
}
