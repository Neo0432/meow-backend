using System.ComponentModel.DataAnnotations;
using PawsBackendDotnet.Models.Entities;

namespace PawsBackendDotnet.Models.DTO.UserDTOs
{
    public class AuthUserResponseDTO
    {
        public required string token { get; set; }
        public required ResponseUserDTO user { get; set; }
    }

    public class ResponseUserDTO : EntityBase
    {
        public string Username { get; set; } = "User";

        [Required]
        public required string Email { get; set; }
        [Required]
        public string? PhoneNumber { get; set; }
        public string? ImageUrl { get; set; } = "";

        public List<Pet> Pets { get; set; } = [];
    }
}
