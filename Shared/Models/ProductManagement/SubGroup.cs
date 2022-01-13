using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Commerce.Shared.Models.ProductManagement
{
    public class SubGroup : Details
    {
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int SubGroupId { get; set; }
        public int GroupId { get; set; }
        public Group? Group { get; set; }
        public string Name { get; set; }
        public string? Description { get; set; }

        [JsonIgnore]
        public ICollection<Product>? Products { get; set;}
    }
}
