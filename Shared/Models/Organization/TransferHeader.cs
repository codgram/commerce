using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Commerce.Shared.Models.Organization
{
    public class TransferHeader : Details
    {
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int TransferHeaderId { get; set; }

        public string DocumentNo { get; set; }

        public int FromLocationId { get; set; }
        public Location? FromLocation { get; set; }

        public int ToLocationId { get; set; }
        public Location? ToLocation { get; set; }

        [JsonIgnore]
        public ICollection<TransferLine>? TransferLines { get; set; }
    }
}
