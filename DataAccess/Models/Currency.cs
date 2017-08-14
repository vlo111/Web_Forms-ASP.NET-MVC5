using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

namespace DataAccess.Models
{
    public partial class Currency
    {
        public Currency()
        {
            this.CustOrders = new List<CustOrder>();
            this.CustOrders1 = new List<CustOrder>();
            this.Prices = new List<Price>();
            this.Prices1 = new List<Price>();
        }

        public int CurrencyID { get; set; }
        [Required(ErrorMessage = "Required field Code")]
        [MaxLength(3)]
        public string Code { get; set; }
        [Required(ErrorMessage = "Required field Name")]
        public string Name { get; set; }
        public virtual ICollection<CustOrder> CustOrders { get; set; }
        public virtual ICollection<CustOrder> CustOrders1 { get; set; }
        public virtual ICollection<Price> Prices { get; set; }
        public virtual ICollection<Price> Prices1 { get; set; }
    }
}
