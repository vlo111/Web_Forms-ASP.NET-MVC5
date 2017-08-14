using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

namespace DataAccess.Models
{
    public partial class Category
    {
        public Category()
        {
            this.Parts = new List<Part>();
        }

        public int CategoryID { get; set; }
        [Required(ErrorMessage = "Required field Name")]
        public string Name { get; set; }
        public string CategoryParentID { get; set; }
        public virtual ICollection<Part> Parts { get; set; }
    }
}
