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
        // Zuerst prüfen, ob der Benutzer authentifiziert ist
        if (!context.HttpContext.User.Identity.IsAuthenticated)
        {
            context.Result = new UnauthorizedResult();
            return;
        }

        // Nach der Rolle mit dem korrekten Claim-Typ suchen
        var roleClaim = context.HttpContext.User.FindFirst("http://schemas.microsoft.com/ws/2008/06/identity/claims/role")?.Value;
        if (roleClaim != _role)
        {
            context.Result = new ForbidResult();
        }
    }
}