using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Commerce.Shared.Models.Sales
{
    public class SalesReturnHeader : Details
    {
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int SalesReturnHeaderId { get; set; }

        public string DocumentNo { get; set; }
        public int LocationId { get; set; }
        public Location? Location { get; set; }

        public int CustomerId { get; set; }
        public Customer? Customer { get; set; }

        [JsonIgnore]
        public ICollection<SalesReturnLine>? SalesReturnLines { get; set; }
    }
}
