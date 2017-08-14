using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

namespace DataAccess.Models
{
    public partial class PartStatu
    {
        public PartStatu()
        {
            this.Parts = new List<Part>();
        }

        public int PartStatusID { get; set; }
        [Required(ErrorMessage = "Required field Status")]
        public string Status { get; set; }
        public virtual ICollection<Part> Parts { get; set; }
    }
}
