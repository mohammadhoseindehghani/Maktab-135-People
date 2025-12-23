using System.Security.Claims;

namespace Food.Framework.Web;

public static class ClaimsPrincipalExtentions
{
	public static string GetCurrentUserId(this ClaimsPrincipal user)
	{
		if (user?.Identity?.IsAuthenticated != true)
			throw new UnauthorizedAccessException("User is not authenticated");

		var userIdClaim = user.Claims.FirstOrDefault(c =>
			c.Type == "sub" || c.Type == "userId" || c.Type == "userid" || c.Type == "id" || c.Type.EndsWith("nameidentifier", StringComparison.OrdinalIgnoreCase));

		if (userIdClaim == null)
			throw new UnauthorizedAccessException("User is not authenticated");

		return userIdClaim.Value;

		//if (!int.TryParse(userIdClaim.Value, out var userId))
		//    throw new UnauthorizedAccessException("User is not authenticated");

		//return userId;
	}
}