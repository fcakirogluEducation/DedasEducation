﻿namespace Membership.API.DTOs
{
    public class UserCreateDto
    {
        public string Email { get; set; } = default!;
        public string Password { get; set; } = default!;
    }
}