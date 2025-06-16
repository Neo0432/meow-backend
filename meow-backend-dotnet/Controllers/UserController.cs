using Microsoft.AspNetCore.Mvc;
using PawsBackendDotnet.Services.Interfaces;
using Microsoft.AspNetCore.Authorization;
using AutoMapper;
using PawsBackendDotnet.Models.DTO.UserDTOs;

namespace PawsBackendDotnet.Controllers
{
    [Authorize]
    [ApiController]
    [Route("api/[controller]")]
    public class UserController : ControllerBase
    {
        private readonly ILogger<UserController> _logger;
        private readonly IUserService _service;
        private readonly IMapper _mapper;
        public UserController(IUserService service, ILogger<UserController> logger, IMapper mapper)
        {
            _service = service;
            _logger = logger;
            _mapper = mapper;
        }


        [HttpGet("user")]
        public async Task<IActionResult> UserProfile([FromQuery] Guid id)
        {
            try
            {
                var user = await _service.GetUserAsync(id);
                if (user == null) return NotFound();

                return Ok(_mapper.Map<ResponseUserDTO>(user));

            }
            catch (Exception ex)
            {
                return StatusCode(500, $"Error: {ex.Message}"); ;
            }

        }

    }
}
