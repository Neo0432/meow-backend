using AutoMapper;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using PawsBackendDotnet.Extensions.JwtExtensions;
using PawsBackendDotnet.Models.DTO.PetsDtos;
using PawsBackendDotnet.Services.Interfaces;

namespace PawsBackendDotnet.Controllers
{
    [Authorize]
    [ApiController]
    [Route("api/pets")]
    public class PetsController(ILogger<UserController> logger, IMapper mapper, IPetService service) : ControllerBase
    {
        private readonly ILogger<UserController> _logger = logger;
        private readonly IMapper _mapper = mapper;
        private readonly IPetService _service = service;

        [HttpGet]
        public async Task<IActionResult> GetAllPets()
        {
            try
            {
                Guid? userId = User.GetUserId();
                if (userId is null) return Unauthorized();

                var pets = await _service.GetAllPetsAsync(userId);
                return Ok(pets);
            }
            catch (Exception ex)
            {
                return StatusCode(500, $"Error: {ex.Message}");
            }
        }

        [HttpGet("{id}")]
        public async Task<IActionResult> GetPetById([FromRoute] Guid id)
        {
            try
            {
                Guid? userId = User.GetUserId();
                if (userId is null) return Unauthorized();

                var pet = await _service.GetPetByIdAsync(userId, id);
                if (pet == null) return NotFound();

                return Ok(pet);
            }
            catch (Exception ex)
            {
                return StatusCode(500, $"Error: {ex.Message}");
            }
        }

        [HttpPost("create")]
        public async Task<IActionResult> CreateNewPet([FromBody] CreatePetRequestDto petRequestDto)
        {
            try
            {
                Guid? userId = User.GetUserId();
                if (userId is null) return Unauthorized();

                var pet = await _service.CreatePetAsync(userId, petRequestDto);
                return Ok(pet);
            }
            catch (Exception ex)
            {
                return StatusCode(500, $"Error: {ex.Message}");
            }
        }

        [HttpPatch("update/{id}")]
        public async Task<IActionResult> UpdatePet([FromRoute] Guid id, [FromBody] UpdatePetRequestDto updatedPetDto)
        {
            try
            {
                Guid? userId = User.GetUserId();
                if (userId is null) return Unauthorized();

                var pet = await _service.UpdatePetAsync(userId, id, updatedPetDto);
                return Ok(pet);
            }
            catch (Exception ex)
            {
                return StatusCode(500, $"Error: {ex.Message}");
            }
        }

        [HttpPatch("update/{id}/feed")]
        public async Task<IActionResult> UpdatePetLastFeedTime([FromRoute] Guid id)
        {
            try
            {
                Guid? userId = User.GetUserId();
                if (userId is null) return Unauthorized();

                var updatedPet = await _service.UpdatePetActionsAsync(userId, id, p => p.LastFeed = DateTime.UtcNow);
                if (updatedPet == null) return NotFound();

                return Ok(new { lastFeed = updatedPet.LastFeed });

            }
            catch (Exception ex)
            {
                return StatusCode(500, $"Error: {ex.Message}");
            }
        }

        [HttpPatch("update/{id}/walk")]
        public async Task<IActionResult> UpdatePetLastWalkTime([FromRoute] Guid id)
        {
            try
            {
                Guid? userId = User.GetUserId();
                if (userId is null) return Unauthorized();

                var updatedPet = await _service.UpdatePetActionsAsync(userId, id, p => p.LastWalk = DateTime.UtcNow);
                if (updatedPet == null) return NotFound();

                return Ok(new { lastWalk = updatedPet.LastWalk });

            }
            catch (Exception ex)
            {
                return StatusCode(500, $"Error: {ex.Message}");
            }
        }

        [HttpPatch("update/{id}/medication")]
        public async Task<IActionResult> UpdatePetLastMedicationTime([FromRoute] Guid id)
        {
            try
            {
                Guid? userId = User.GetUserId();
                if (userId is null) return Unauthorized();

                var updatedPet = await _service.UpdatePetActionsAsync(userId, id, p => p.LastMedication = DateTime.UtcNow);
                if (updatedPet == null) return NotFound();
                return Ok(new { lastMedication = updatedPet.LastMedication });

            }
            catch (Exception ex)
            {
                return StatusCode(500, $"Error: {ex.Message}");
            }
        }

        [HttpDelete("delete/{id}")]
        public async Task<IActionResult> DeletePet([FromRoute] Guid id)
        {
            try
            {
                Guid? userId = User.GetUserId();
                if (userId is null) return Unauthorized();

                await _service.DeletePetAsync(userId, id);
                return Ok(new { deletedPet = id });
            }
            catch (Exception ex)
            {
                return StatusCode(500, $"Error: {ex.Message}");
            }
        }
    }
}
