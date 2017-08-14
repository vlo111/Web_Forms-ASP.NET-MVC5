using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

namespace DataAccess.Models
{
    public partial class Price
    {
        public int PriceID { get; set; }
        public int PartID { get; set; }
        [Required(ErrorMessage = "Required field Start Date")]
        public System.DateTime ValidStart { get; set; }
        [Required(ErrorMessage = "Required field End Date")]
        public System.DateTime ValidEnd { get; set; }
        public System.DateTime DateCreated { get; set; }
        [Required(ErrorMessage = "Required field Cost")]
        public decimal CostValue { get; set; }
        [Required(ErrorMessage = "Required field Cost Currency")]
        public int CostCurrencyID { get; set; }
        [Required(ErrorMessage = "Required field Sell")]
        public decimal SellValue { get; set; }
        [Required(ErrorMessage = "Required field Sell Currency")]
        public int SellCurrencyID { get; set; }
        public int EmployeeID { get; set; }
        public virtual Currency Currency { get; set; }
        public virtual Currency Currency1 { get; set; }
        public virtual Employee Employee { get; set; }
        public virtual Part Part { get; set; }
    }
}
