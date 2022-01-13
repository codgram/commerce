using Microsoft.AspNetCore.Identity;

namespace Commerce.Shared.Models
{
    public class CommerceUser : IdentityUser
    {
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public DateTime CreatedOn { get; set; } = DateTime.Now;

        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public DateTime UpdatedOn { get; set; } = DateTime.Now;
        public string? FirstName { get; set; }
        public string? LastName { get; set; }
        public int CountryId { get; set; } = 334;
        public Country Country { get; set; }
        public bool IsDeleted { get; set; }

        [JsonIgnore]
        public ICollection<Member> Members { get; set; }
    }
}