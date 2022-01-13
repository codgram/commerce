using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

using System.Threading.Tasks;

namespace Commerce.Shared.Models.ProductManagement
{
    public class Category : Details
    {
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int CategoryId { get; set; }

        public string CompanyId { get; set; }
        public Company? Company { get; set; }
        public string Name { get; set; }
        public string? Description { get; set; }


        [JsonIgnore]
        public ICollection<Group>? Groups { get; set; }
    }
}
