using ContactAppBackend.Database.Models;
using ContactAppBackend.Dto;
using ContactAppBackend.Services;
using Microsoft.AspNetCore.Mvc;

namespace ContactAppBackend.Controllers
{

    [Route("api/[Controller]")]
    [ApiController]
    public class AuthController
    {
        private readonly AuthService authService;

        public AuthController()
        {
            this.authService = new AuthService();

        }
        [HttpPost("login")]
        public ActionResult<LoginResponseDto> Login([FromBody] LoginRequestDto dto)
        {
            return this.authService.Login(dto);
        }

        [HttpPost("register")]
        public ActionResult<APIResult> Register([FromBody] CreateUserDto dto)
        {
            return this.authService.Register(dto);
        }
    }
}
