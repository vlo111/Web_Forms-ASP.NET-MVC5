using System;
using System.Collections.Generic;

namespace DataAccess.Models
{
    public partial class GroupUrgency
    {
        public GroupUrgency()
        {
            this.OrderParts = new List<OrderPart>();
        }

        public int GroupUrgencyID { get; set; }
        public string Number { get; set; }
        public string Description { get; set; }
        public virtual ICollection<OrderPart> OrderParts { get; set; }
    }
}
