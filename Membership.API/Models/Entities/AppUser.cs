using Microsoft.AspNetCore.Identity;

namespace Membership.API.Models
{
    public class AppUser : IdentityUser<Guid>
    {
        public int City { get; set; }
        public DateTime? BirthDate { get; set; }


        public List<Product>? Products { get; set; }
    }
}