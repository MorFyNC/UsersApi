using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using TestApi3K.DataBaseContext;
using TestApi3K.Interfaces;
using TestApi3K.Model;

namespace TestApi3K.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class AuthController
    {
        private IAuthService _authService;
        private ILogger<AuthController> _logger;

        public AuthController(IAuthService authService, ILogger<AuthController> logger)
        {
            _authService = authService;
            _logger = logger;
        }
        [AllowAnonymous]
        [HttpPost("login")]
        public async Task<IActionResult> Login([FromBody]LoginModel model)
        {
            return await _authService.LoginAsync(model);
        }

        [Authorize]
        [HttpPost("checkAuth")]
        public async Task<IActionResult> CheckAuthorization()
        {
            return new OkObjectResult(new { status = true });
        }
    }
}
