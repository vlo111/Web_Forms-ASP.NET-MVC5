using System;
using System.Collections.Generic;

namespace DataAccess.Models
{
    public partial class AltPartID
    {
        public int AltPartID1 { get; set; }
        public int PartID { get; set; }
        public string PartNo { get; set; }
        public virtual Part Part { get; set; }
    }
}
