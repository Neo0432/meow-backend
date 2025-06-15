using PawsBackendDotnet.Models.Entities;
using PawsBackendDotnet.Models.DTO.UserDTOs;
using Microsoft.AspNetCore.Mvc;
using PawsBackendDotnet.Data;
using PawsBackendDotnet.Services.Interfaces;

namespace PawsBackendDotnet.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class UserController : ControllerBase
    {
        private readonly ILogger<UserController> _logger;
        private readonly IUserService _service;
        public UserController(IUserService service, ILogger<UserController> logger)
        {
            _service = service;
            _logger = logger;
        }

    }
}
