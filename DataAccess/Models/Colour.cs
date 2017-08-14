using System;
using System.Collections.Generic;

namespace DataAccess.Models
{
    public partial class Colour
    {
        public int ColourID { get; set; }
        public string Name { get; set; }
        public string Hex { get; set; }
        public string ShopColour { get; set; }
    }
}
