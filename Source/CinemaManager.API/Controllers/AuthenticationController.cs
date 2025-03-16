using CinemaManager.Application.Authentication;
using CinemaManger.Contracts.Authentication;
using Microsoft.AspNetCore.Mvc;
using System.Security.Cryptography.X509Certificates;

namespace CinemaManager.API.Controllers
{
    [Route("auth")]
    public class AuthenticationController : ControllerBase
    {
        private readonly IHandleRegisterRequest _handleRegisterRequest;

        public AuthenticationController(IHandleRegisterRequest handleRegisterRequest)
        {
            _handleRegisterRequest = handleRegisterRequest;
        }

        [HttpPost("register")]
        public IActionResult Register([FromBody] RegisterRequest request)
        {
            var response = _handleRegisterRequest.Handle(request);

            return Ok(response);
        }
    }
}
