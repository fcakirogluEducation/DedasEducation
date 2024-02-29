using Microsoft.AspNetCore.Authorization;

namespace Membership.API.Requirements
{
    public class BirthDateCheckRequirement : IAuthorizationRequirement
    {
        public int Age { get; set; }
    }


    public class BirthDateCheckRequirementHandler : AuthorizationHandler<BirthDateCheckRequirement>
    {
        protected override Task HandleRequirementAsync(AuthorizationHandlerContext context,
            BirthDateCheckRequirement requirement)
        {
            var claims = context.User.Claims;

            var birthDate2 = context.User.Claims.First(x => x.Type == "birthDate");

            var birthDate = context.User.FindFirst("birthDate")?.Value;


            if (string.IsNullOrEmpty(birthDate))
            {
                context.Fail();
                return Task.CompletedTask;
            }

            var date = DateTime.Parse(birthDate);
            var age = DateTime.Now.Year - date.Year;

            if (date > DateTime.Now.AddYears(-age))
            {
                age--;
            }

            if (age < requirement.Age)
            {
                context.Fail();
                return Task.CompletedTask;
            }

            context.Succeed(requirement);
            return Task.CompletedTask;
        }
    }
}