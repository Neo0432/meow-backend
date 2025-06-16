using Microsoft.AspNetCore.Mvc;
using PawsBackendDotnet.Services.Interfaces;
using Microsoft.AspNetCore.Authorization;
using AutoMapper;
using PawsBackendDotnet.Models.DTO.UserDTOs;
using PawsBackendDotnet.Models.DTO.User;

namespace PawsBackendDotnet.Controllers
{
    [Authorize]
    [ApiController]
    [Route("api/users")]
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


        [HttpGet("{id}")]
        public async Task<IActionResult> UserProfile([FromRoute] Guid id)
        {
            try
            {
                var user = await _service.GetUserAsync(id);
                if (user == null) return NotFound();

                return Ok(_mapper.Map<ResponseUserDTO>(user));
            }
            catch (Exception ex)
            {
                return StatusCode(500, $"Error: {ex.Message}");
            }
        }

        [HttpPatch("update/{id}")]
        public async Task<IActionResult> UpdateUserProfile([FromRoute] Guid id, UpdateUserRequesDto updateUserDto)
        {
            try
            {
                var existedUser = await _service.GetUserAsync(id);
                if (existedUser == null) return NotFound();

                existedUser.Username = updateUserDto.Username;
                existedUser.Email = updateUserDto.Email;
                existedUser.PhoneNumber = updateUserDto.PhoneNumber;
                existedUser.ImageUrl = updateUserDto.ImageUrl;

                var updatedUser = await _service.UpdateUserAsync(id, existedUser);
                return Ok(_mapper.Map<ResponseUserDTO>(existedUser));
            }
            catch (Exception ex)
            {
                return StatusCode(500, $"Error: {ex.Message}");
            }
        }

        [HttpDelete("delete/{id}")]
        public async Task<IActionResult> DeleteUserProfile([FromRoute] Guid id)
        {
            try
            {
                await _service.DeleteUserAsync(id);
                return Ok(id);
            }
            catch (Exception ex)
            {
                return StatusCode(500, $"Error: {ex.Message}");
            }
        }

    }
}
