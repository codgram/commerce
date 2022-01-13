using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Commerce.Shared.Models.Procurement
{
    public class PurchaseLine : Details
    {
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int PurchaseLineId { get; set; }

        public int PurchaseHeaderId { get; set; }
        public PurchaseHeader? PurchaseHeader { get; set; }
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
