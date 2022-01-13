using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Commerce.Shared.Models.Organization
{
    public enum MemberType
    {
        Owner,
        Admin,
        Coordinator,
        Editor,
        Viewer
    }

    public class Member : Details
    {
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int MemberId { get; set; }

        public string CommerceUserId { get; set; }

        public CommerceUser CommerceUser { get; set; }
        public string CompanyId { get; set; }

        public Company Company { get; set; }

        public MemberType Type { get; set; }
    }
}
