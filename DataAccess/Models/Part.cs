using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

namespace DataAccess.Models
{
    public partial class Part
    {
        public Part()
        {
            this.AltPartIDs = new List<AltPartID>();
            this.OrderParts = new List<OrderPart>();
            this.PartDependencies = new List<PartDependency>();
            this.PartInventories = new List<PartInventory>();
            this.Prices = new List<Price>();
            this.Files = new List<File>();
        }

        public int PartID { get; set; }
        public int? AltPartID { get; set; }
        [Required(ErrorMessage = "Required field Name")]
        public string Name { get; set; }
        public string Description { get; set; }
        [Required(ErrorMessage = "Required field Product Line")]
        public int ProductLineID { get; set; }
        [Required(ErrorMessage = "Required field Category")]
        public int CategoryID { get; set; }
        public int? ImageID { get; set; }
        public int? PartStatusID { get; set; }
        public bool CustomFlag { get; set; }
        public string Comments { get; set; }
        public System.DateTime CreatedDate { get; set; }
        public System.DateTime ModifiedDate { get; set; }
        public int EmployeeID { get; set; }
        [Required(ErrorMessage = "Required field Weight")]
        public double Weight { get; set; }
        public double? Height { get; set; }
        public double? Width { get; set; }
        public double? Length { get; set; }
        public int PriceID { get; set; }
        [Required(ErrorMessage = "Required field Meas Type")]
        public int MeasUnitID { get; set; }
        public int? PartInventoryID { get; set; }
        public virtual ICollection<AltPartID> AltPartIDs { get; set; }
        public virtual Category Category { get; set; }
        public virtual Employee Employee { get; set; }
        public virtual Image Image { get; set; }
        public virtual MeasUnit MeasUnit { get; set; }
        public virtual ICollection<OrderPart> OrderParts { get; set; }
        public virtual PartStatu PartStatu { get; set; }
        public virtual ProductLine ProductLine { get; set; }
        public virtual ICollection<PartDependency> PartDependencies { get; set; }
        public virtual ICollection<PartInventory> PartInventories { get; set; }
        public virtual ICollection<Price> Prices { get; set; }
        public virtual ICollection<File> Files { get; set; }
    }
}
