using System.Security.Claims;
using Megasave.Application.Contracts;

namespace Megasave.Web.Services
{
    public class LoggedInUserService : ILoggedInUserService
    {
        public LoggedInUserService(IHttpContextAccessor httpContextAccessor)
        {
            var claims = httpContextAccessor.HttpContext?.User?.Identities.FirstOrDefault()?.Claims.ToList();
            if (claims != null) UserId = claims.FirstOrDefault(c => c.Type == ClaimTypes.NameIdentifier)?.Value;
        }

        public string UserId { get; }
    }
}