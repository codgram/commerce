using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Text.Json.Serialization;
using System.Threading.Tasks;

namespace Commerce.Shared.Models.Organization
{
    public class Location : Details
    {
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int LocationId { get; set; }
        public string CompanyId { get; set; }
        public Company? Company { get; set; }

        public string Code { get; set; }
        public string Name { get; set; }
        public string? Description { get; set; }
        public string? Entity { get; set; }

        [JsonIgnore]
        public ICollection<PurchaseHeader>? PurchaseHeaders { get; set; }

        [JsonIgnore]
        public ICollection<PurchaseReturnHeader>? PurchaseReturnHeaders { get; set; }

        [JsonIgnore]
        public ICollection<SalesHeader>? SalesHeaders { get; set; }

        [JsonIgnore]
        public ICollection<SalesReturnHeader>? SalesReturnHeaders { get; set; }

        [JsonIgnore]
        public ICollection<TransferHeader>? FromTransferHeaders { get; set; }

        [JsonIgnore]
        public ICollection<TransferHeader>? ToTransferHeaders { get; set; }
    }
}
