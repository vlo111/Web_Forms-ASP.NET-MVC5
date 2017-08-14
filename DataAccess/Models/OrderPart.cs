using System;
using System.Collections.Generic;

namespace DataAccess.Models
{
    public partial class OrderPart
    {
        public OrderPart()
        {
            this.Files = new List<File>();
            this.Tags = new List<Tag>();
        }

        public int OrderPartID { get; set; }
        public int PartID { get; set; }
        public double Quantity { get; set; }
        public int PriceID { get; set; }
        public Nullable<int> GroupUrgencyID { get; set; }
        public string ColourID { get; set; }
        public string Comments { get; set; }
        public virtual GroupUrgency GroupUrgency { get; set; }
        public virtual Part Part { get; set; }
        public virtual ICollection<File> Files { get; set; }
        public virtual ICollection<Tag> Tags { get; set; }
    }
}
