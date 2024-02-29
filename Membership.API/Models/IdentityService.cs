using System.IdentityModel.Tokens.Jwt;
using System.Security.Claims;
using System.Text;
using Membership.API.Models.DTOs;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using Microsoft.IdentityModel.Tokens;

namespace Membership.API.Models
{
    public class IdentityService(UserManager<AppUser> userManager, IConfiguration configuration)
    {
        public async Task<(bool, string)> Signin(SigninDto signinDto)
        {
            var hasUser = await userManager.FindByEmailAsync(signinDto.Email);

            if (hasUser is null)
            {
                return (false, "email veya password yanlış");
                //return Tuple.Create(false, "email veya password yanlış");
            }

            var checkPassword = await userManager.CheckPasswordAsync(hasUser, signinDto.Password);

            if (checkPassword == false)
            {
                return (false, "email veya password yanlış");
            }

            var tokenExpire = configuration.GetSection("TokenOptions")["AccessTokenExpire"]!;
            var securityKey = configuration.GetSection("TokenOptions")["SecurityKey"]!;
            var audience = configuration.GetSection("TokenOptions")["Audience"]!;
            var issuer = configuration.GetSection("TokenOptions")["Issuer"]!;
            SigningCredentials signingCredentials = new(new SymmetricSecurityKey(Encoding.UTF8.GetBytes(securityKey)),
                SecurityAlgorithms.HmacSha256Signature);

            var claims = new List<Claim>
            {
                new Claim(ClaimTypes.NameIdentifier, hasUser.Id.ToString()),
                new Claim(ClaimTypes.Email, hasUser.Email!),
                new Claim(ClaimTypes.Name, hasUser.UserName!),
            };
            // audience => aud => http://

            var token = new JwtSecurityToken(
                expires: DateTime.Now.AddHours(Convert.ToDouble(tokenExpire)),
                signingCredentials: signingCredentials,
                claims: claims,
                issuer: issuer,
                audience: audience
            );

            var tokenHandler = new JwtSecurityTokenHandler();

            var tokenAsString = tokenHandler.WriteToken(token);

            return (true, tokenAsString);
        }
    }
}