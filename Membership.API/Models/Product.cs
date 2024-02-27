namespace Membership.API.Models
{
    public class Product
    {
        public int Id { get; set; }
        public string Name { get; set; } = default!;

        public AppUser AppUser { get; set; } = default!;
        public Guid UserId { get; set; }
    }
}