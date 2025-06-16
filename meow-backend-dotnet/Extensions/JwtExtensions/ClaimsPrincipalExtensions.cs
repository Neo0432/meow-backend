using System.Security.Claims;

namespace PawsBackendDotnet.Extensions.JwtExtensions
{
    public static class ClaimsPrincipalExtensions
    {
        public static Guid? GetUserId(this ClaimsPrincipal user)
        {
            var userIdString = user.FindFirstValue(ClaimTypes.NameIdentifier);
            if (Guid.TryParse(userIdString, out var userId))
                return userId;
            return null;
        }
    }
}
