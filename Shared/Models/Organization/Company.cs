using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Text.Json.Serialization;
using System.Threading.Tasks;

namespace Commerce.Shared.Models.Organization
{
    public class Company : Details
    {
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public string? CompanyId { get; set; }
        public string Slug { get; set; }
        public string Name { get; set; }
        public string? Description { get; set; }
        public int CountryId { get; set; } = 1;
        public Country? Country { get; set; }
        public string? City { get; set; }
        public string? Address { get; set; }

        public bool IsDefault { get; set; }

        [JsonIgnore]
        public ICollection<Category>? Categories { get; set; }

        [JsonIgnore]
        public ICollection<Customer>? Customers { get; set; }

        [JsonIgnore]
        public ICollection<Supplier>? Suppliers { get; set; }

        [JsonIgnore]
        public ICollection<Member>? Members { get; set; }

        [JsonIgnore]
        public ICollection<Product>? Products { get; set; }

        [JsonIgnore]
        public ICollection<UnitOfMeasure>? UnitOfMeasures { get; set; }

        [JsonIgnore]
        public ICollection<Location>? Locations { get; set; }
    }
}
