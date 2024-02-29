namespace Membership.API.Models.DTOs
{
    public class SigninDto
    {
        public string Email { get; set; } = default!;
        public string Password { get; set; } = default!;
    }
}