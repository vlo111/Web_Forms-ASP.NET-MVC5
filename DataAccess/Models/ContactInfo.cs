using System;
using System.Collections.Generic;

namespace DataAccess.Models
{
    public partial class ContactInfo
    {
        public int ContactInfoID { get; set; }
        public int ContactInfoTypeID { get; set; }
        public int CustomerContactID { get; set; }
        public string Name { get; set; }
        public string Contact { get; set; }
        public bool PrimaryContact { get; set; }
    }
}
