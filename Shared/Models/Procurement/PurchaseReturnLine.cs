using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Commerce.Shared.Models.Procurement
{
    public class PurchaseReturnLine : Details
    {
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int PurchaseReturnLineId { get; set; }

        public int PurchaseReturnHeaderId { get; set; }
        public PurchaseReturnHeader? PurchaseReturnHeader { get; set; }
        public int LineNo { get; set; }
        public int ProductId { get; set; }
        public Product? Product { get; set; }

        [Column(TypeName = "decimal(18, 3)")]
        public decimal Quantity { get; set; }

        [Column(TypeName = "decimal(18, 3)")]
        public decimal Price { get; set; }

        public decimal Amount
        {
            get
            {
                return Quantity * Price;
            }
        }
    }
}
