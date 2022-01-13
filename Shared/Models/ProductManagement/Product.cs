using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Commerce.Shared.Models.ProductManagement
{
    public class Product : Details
    {
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int ProductId { get; set; }
        public string CompanyId { get; set; }
        public Company? Company { get; set; }
        public int SubGroupId { get; set; }
        public SubGroup? SubGroup { get; set; }

        public string Code { get; set; }
        public string Family { get; set; }
        public string Description { get; set; }

        public int BaseUOMId { get; set; }
        public UnitOfMeasure? BaseUOM { get; set; }

        public int SalesUOMId { get; set; }
        public UnitOfMeasure? SalesUOM { get; set; }

        public int PurchaseUOMId { get; set; }
        public UnitOfMeasure? PurchaseUOM { get; set; }

        public int TransferUOMId { get; set; }
        public UnitOfMeasure? TransferUOM { get; set; }


        [JsonIgnore]
        public ICollection<Variant>? Variants { get; set; }

        [JsonIgnore]
        public ICollection<PurchaseLine>? PurchaseLines { get; set; }

        [JsonIgnore]
        public ICollection<PurchaseReturnLine>? PurchaseReturnLines { get; set; }

        [JsonIgnore]
        public ICollection<SalesLine>? SalesLines { get; set; }

        [JsonIgnore]
        public ICollection<SalesReturnLine>? SalesReturnLines { get; set; }

        [JsonIgnore]
        public ICollection<TransferLine>? TransferLines { get; set; }


    }
}
