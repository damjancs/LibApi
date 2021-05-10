using LibApi.Entities;
using Microsoft.AspNetCore.Authorization;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Claims;
using System.Threading.Tasks;

namespace LibApi.Authorizations
{
    //public class ResourceOperationRequirementHandler : AuthorizationHandler<ResourceOperationRequirement, Book>
    //{
    //    protected override Task HandleRequirementAsync(AuthorizationHandlerContext context, ResourceOperationRequirement requirement, Book book)
    //    {
    //        if (requirement.ResourceOperation == ResourceOperation.Read)
    //        {
    //            context.Succeed(requirement);
    //        }

    //        var userId = context.User.FindFirst(c => c.Type == ClaimTypes.NameIdentifier).Value;
    //    }
    //}
}
