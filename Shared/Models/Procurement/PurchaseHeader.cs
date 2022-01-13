using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Commerce.Shared.Models.Procurement
{
    public class PurchaseHeader : Details
    {
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int PurchaseHeaderId { get; set; }

        public DateTime ReleaseDate { get; set; }
        public DateTime PostingDate { get; set; }
        public string DocumentNo { get; set; }
        public int LocationId { get; set; }
        public Location? Location { get; set; }

        public int SupplierId { get; set; }
        public Supplier? Supplier { get; set; }

        [JsonIgnore]
        public ICollection<PurchaseLine>? PurchaseLines { get; set; }
    }
}
