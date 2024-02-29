using Membership.API.Models.Entities;
using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;

namespace Membership.API.Models
{
    public class AppDbContext(DbContextOptions<AppDbContext> options)
        : IdentityDbContext<AppUser, AppRole, Guid>(options)
    {
        public DbSet<AppUserDetail> AppUserDetails { get; set; } = default!;

        public DbSet<Product> Products { get; set; } = default!;
    }
}