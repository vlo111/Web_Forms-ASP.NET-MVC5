using System;
using System.Collections.Generic;

namespace DataAccess.Models
{
    public partial class PartDependency
    {
        public int PartDependencyID { get; set; }
        public int PartID { get; set; }
        public int DependendPart { get; set; }
        public bool Required { get; set; }
        public Nullable<double> Number { get; set; }
        public virtual Part Part { get; set; }
    }
}
