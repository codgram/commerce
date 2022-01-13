using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Commerce.Shared.Models.Setup
{
    public class UnitOfMeasure : Details
    {
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int UnitOfMeasureId { get; set; }

        public string CompanyId { get; set; }
        public Company? Company { get; set; }
        public string Code { get; set; }

        [Column(TypeName = "decimal(18, 3)")]
        public decimal Quantity { get; set; }

        [JsonIgnore]
        public ICollection<Product>? ProductBases { get; set; }

        [JsonIgnore]
        public ICollection<Product>? ProductPurchases { get; set; }

        [JsonIgnore]
        public ICollection<Product>? ProductSales { get; set; }

        [JsonIgnore]
        public ICollection<Product>? ProductTransfers { get; set; }
    }
}
