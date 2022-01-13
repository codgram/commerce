using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Commerce.Shared.Models
{
    public class Country : Details
    {
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int CountryId { get; set; }

        public string Code { get; set; }
        public string Name { get; set; }
        public string ZipCode { get; set; }


        [JsonIgnore]
        public ICollection<Company>? Companies { get; set; }

        [JsonIgnore]
        public ICollection<CommerceUser>? CommerceUsers { get; set; }
    }
}
