using System;
using System.Collections.Generic;

namespace DataAccess.Models
{
    public partial class CustomerContact
    {
        public int CustomerContactID { get; set; }
        public int CustomerID { get; set; }
        public string Name { get; set; }
        public virtual Customer Customer { get; set; }
    }
}
