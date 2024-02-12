using Microsoft.AspNetCore.Mvc;

namespace UmkaSignalR.Zitadel.Contollers
{
    [Route("unauthed")]
    [ApiController]
    public class UnauthorizedApiController : ControllerBase
    {
        [HttpGet]
        public object UnAuthedGet()
        => new { Ping = "Pong", Timestamp = DateTime.Now };
    }
}
