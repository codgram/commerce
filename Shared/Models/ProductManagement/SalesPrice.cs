using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Commerce.Shared.Models.ProductManagement
{
    public class SalesPrice : Details
    {
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int SalesPriceId { get; set; }

        public DateTime Date { get; set; }
        public int VariantId { get; set; }
        public Variant? Variant { get; set; }

        [Column(TypeName = "decimal(18, 3)")]
        public decimal Price { get; set; }
    }
}
