using System.Security.Claims;
using Microsoft.AspNetCore.Mvc;

namespace Motoca.Interfaces.Http.Api.Common.Controllers;

public class CoreController : ControllerBase
{
    protected Claim? GetClaims(string key)
    {
        var claimsIdentity = HttpContext.User.Identity as ClaimsIdentity;

        var claim = claimsIdentity.FindFirst(key);
            
        return claim;
    }

    protected long GetDeliverymanId()
    {
        var userIdClaim = GetClaims("DeliverymanId");

        if (userIdClaim is not null)
        {
            return Convert.ToInt64(userIdClaim.Value);    
        }

        return 0;
    }
    
    protected long GetAdministratorId()
    {
        var userIdClaim = GetClaims("AdministratorId");

        if (userIdClaim is not null)
        {
            return Convert.ToInt64(userIdClaim.Value);    
        }

        return 0;
    }
}