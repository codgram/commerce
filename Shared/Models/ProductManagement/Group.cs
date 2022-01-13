using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Commerce.Shared.Models.ProductManagement
{
    public class Group : Details
    {
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int GroupId { get; set; }

        public int CategoryId { get; set; }

        //[System.Text.Json.Serialization.JsonIgnore]
        public Category? Category { get; set; }
        public string Name { get; set; }
        public string? Description { get; set; }

        [JsonIgnore]
        public ICollection<SubGroup>? SubGroups { get; set; }
    }
}
