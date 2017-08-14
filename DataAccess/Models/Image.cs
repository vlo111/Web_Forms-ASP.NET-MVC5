using System;
using System.Collections.Generic;

namespace DataAccess.Models
{
    public partial class Image
    {
        public Image()
        {
            this.Parts = new List<Part>();
        }

        public int ImageID { get; set; }
        public string Name { get; set; }
        public string Ext { get; set; }
        public byte[] Image1 { get; set; }
        public virtual ICollection<Part> Parts { get; set; }
    }
}
