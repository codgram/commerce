using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Commerce.Shared.Models.Procurement
{
    public class Supplier : Details
    {
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int SupplierId { get; set; }
        public string FirstName { get; set; }
        public string LastName { get; set; }
        public string CompanyId { get; set; }
        public Company? Company { get; set; }

        [JsonIgnore]
        public ICollection<PurchaseHeader>? PurchaseHeaders { get; set; }

        [JsonIgnore]
        public ICollection<PurchaseReturnHeader>? PurchaseReturnHeaders { get; set; }
    }
}
