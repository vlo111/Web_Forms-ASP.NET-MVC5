using System;
using System.Collections.Generic;

namespace DataAccess.Models
{
    public partial class CustOrder
    {
        public CustOrder()
        {
            this.Files = new List<File>();
        }

        public int CustOrderID { get; set; }
        public int Revision { get; set; }
        public int CustomerID { get; set; }
        public string PONum { get; set; }
        public string InvoiceNo { get; set; }
        public System.DateTime CreatedDate { get; set; }
        public int EmployeeID { get; set; }
        public Nullable<int> ApproverID { get; set; }
        public Nullable<decimal> CostTotal { get; set; }
        public Nullable<int> CostCurrencyID { get; set; }
        public Nullable<decimal> SellTotal { get; set; }
        public Nullable<int> SellCurrencyID { get; set; }
        public int GroupUrgencyID { get; set; }
        public Nullable<double> DiscountAmountPercentage { get; set; }
        public string CommentsCentury { get; set; }
        public virtual Currency Currency { get; set; }
        public virtual Currency Currency1 { get; set; }
        public virtual Customer Customer { get; set; }
        public virtual Employee Employee { get; set; }
        public virtual Employee Employee1 { get; set; }
        public virtual ICollection<File> Files { get; set; }
    }
}
