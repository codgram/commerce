using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Commerce.Shared.Models.ProductManagement
{
    public class Variant : Details
    {
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int VariantId { get; set; }

        public string Code { get; set; }
        public int ProductId { get; set; }
        public Product? Product { get; set; }
        public string? Model { get; set; }
        public string? Type { get; set; }
        public string? Color { get; set; }
        public string? Size { get; set; }
        public string? Flavor { get; set; }
        public string? Description { get; set; }

        [JsonIgnore]
        public ICollection<SalesPrice>? SalesPrices { get; set; }

    }
}
