using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using System.Security.Claims;
using Zitadel.Authentication;

namespace UmkaSignalR.Zitadel.Contollers
{
    [Route("authed")]
    [ApiController]
    public class AuthorizedApiController : ControllerBase
    {
        [HttpGet("jwt")]
        [Authorize(AuthenticationSchemes = "ZITADEL_JWT")]
        public object JetGet()
        => Result();

        [HttpGet("basic")]
        [Authorize(AuthenticationSchemes = "ZITADEL_BASIC")]
        public object BasicGet()
            => Result();

        [HttpGet("mock")]
        [Authorize(AuthenticationSchemes = "ZITADEL_FAKE")]
        public object FakeGet()
            => Result();

        private object Result() => new
        {
            Ping = "Pong",
            Timestamp = DateTime.Now,
            AuthType = User.Identity?.AuthenticationType,
            UserName = User.Identity?.Name,
            UserId = User.FindFirstValue(OidcClaimTypes.Subject),
            Claims = User.Claims.Select(c => new { c.Type, c.Value }).ToList(),
            IsInAdminRole = User.IsInRole("Admin"),
            IsInUserRole = User.IsInRole("User"),
        };
    }
}
