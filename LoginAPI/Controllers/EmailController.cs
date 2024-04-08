using LoginAPI.Repositories.Interfaces;
using Microsoft.AspNetCore.Mvc;

namespace LoginAPI.Controllers
{
    [Route("api/[controller]")]//attribute routing
    [ApiController]
    public class EmailController : Controller
    {
        private readonly IEmail _email;

        public EmailController(IEmail email)
        {
            _email = email;
        }

        [HttpPost("Send Email")]
        public async Task<ActionResult> SendEmail(string body)
        {
            var result = _email.SendEmail(body);
            return Ok(result);
        }
    }
}
