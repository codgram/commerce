using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Commerce.Shared.Models.Sales
{
    public class Customer : Details
    {
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int CustomerId { get; set; }

        public string CompanyId { get; set; }
        public Company? Company { get; set; }

        public string FirstName { get; set; }
        public string? LastName { get; set; }

        public string? Comment { get; set; }

        [JsonIgnore]
        public ICollection<SalesHeader>? SalesHeaders { get; set; }

        [JsonIgnore]
        public ICollection<SalesReturnHeader>? SalesReturnHeaders { get; set; }

    }
}
