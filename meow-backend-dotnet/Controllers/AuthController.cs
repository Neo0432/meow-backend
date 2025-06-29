using AutoMapper;
using Microsoft.AspNetCore.Mvc;
using PawsBackendDotnet.Models.DTO.UserDTOs;
using PawsBackendDotnet.Models.Entities;
using PawsBackendDotnet.Services.Interfaces;

namespace PawsBackendDotnet.Controllers
{
    [ApiController]
    [Route("api/auth")]
    public class AuthController : ControllerBase
    {
        private readonly IJwtAuthService _jwtService;
        private readonly IMapper _mapper;
        private readonly IUserService _userService;

        public AuthController(IJwtAuthService jwtService, IUserService userService, IMapper mapper)
        {
            _jwtService = jwtService;
            _userService = userService;
            _mapper = mapper;
        }

        [HttpPost("login")]
        public async Task<IActionResult> Login([FromBody] AuthUserRequestDTO loginData)
        {
            try
            {
                User? user = await _userService.LoginUserAsync(loginData);

                if (user == null) return Unauthorized("Invalid email or password");

                var token = _jwtService.GenerateToken(user);
                var response = new AuthUserResponseDTO { user = _mapper.Map<ResponseUserDTO>(user), token = token };

                return Ok(response);
            }
            catch (Exception ex)
            {
                return StatusCode(500, $"Error: {ex.Message}");
            }
        }

        [HttpPost("register")]
        public async Task<IActionResult> Registrate([FromBody] AuthUserRequestDTO signUpData)
        {
            try
            {
                User? user = await _userService.CreateUserAsync(signUpData);

                var token = _jwtService.GenerateToken(user);
                var response = new AuthUserResponseDTO { user = _mapper.Map<ResponseUserDTO>(user), token = token };

                return Ok(response);
            }
            catch (Exception ex)
            {
                return StatusCode(500, $"Error: {ex.Message}");
            }
        }

    }
}
