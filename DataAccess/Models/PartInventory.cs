using System;
using System.Collections.Generic;

namespace DataAccess.Models
{
    public partial class PartInventory
    {
        public int PartInventoryID { get; set; }
        public int PartID { get; set; }
        public virtual Part Part { get; set; }
    }
}
