using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

namespace DataAccess.Models
{
    public partial class MeasUnit
    {
        public MeasUnit()
        {
            this.Parts = new List<Part>();
        }

        public int MeasUnitID { get; set; }
        [Required(ErrorMessage = "Required field Short")]
        public string ShortDescription { get; set; }
        [Required(ErrorMessage = "Required field Long")]
        public string LongDescription { get; set; }
        public virtual ICollection<Part> Parts { get; set; }
    }
}
