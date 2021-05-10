using Microsoft.AspNetCore.Authorization;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace LibApi.Authorizations
{
    public class MinimumAgeRequirementHandler : AuthorizationHandler<MinimumAgeRequirement>
    {
        protected override Task HandleRequirementAsync(AuthorizationHandlerContext context, MinimumAgeRequirement requirement)
        {
            var birthDate =  DateTime.Parse(context.User.FindFirst(c => c.Type == "BirthDate").Value);
            if (birthDate.AddYears(requirement.MinimumAge) <= DateTime.Today)
            {
                context.Succeed(requirement);
            }

            return Task.CompletedTask;
        }
    }
}
