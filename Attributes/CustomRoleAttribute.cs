using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Filters;

namespace BookStoreApi.Attributes;

public class CustomRoleAttribute : Attribute, IAuthorizationFilter
{
    private readonly string _role;

    public CustomRoleAttribute(string role)
    {
        _role = role;
    }

    public void OnAuthorization(AuthorizationFilterContext context)
    {
        var roleClaim = context.HttpContext.User.FindFirst("role")?.Value;

        if (roleClaim != _role)
        {
            context.Result = new ForbidResult();
        }
    }
}