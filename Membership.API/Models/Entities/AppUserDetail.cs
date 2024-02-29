﻿namespace Membership.API.Models.Entities
{
    public class AppUserDetail
    {
        public int Id { get; set; }
        public string Bio { get; set; } = default!;

        public AppUser? AppUser { get; set; }

        public int? AppUserId { get; set; }
    }
}