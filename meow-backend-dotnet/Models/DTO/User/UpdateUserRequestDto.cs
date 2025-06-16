using System.ComponentModel.DataAnnotations;

namespace PawsBackendDotnet.Models.DTO.User
{
    public class UpdateUserRequesDto
    {
        public string Username { get; set; } = "User";

        [Required]
        public required string Email { get; set; }
        public string? PhoneNumber { get; set; }
        public string? ImageUrl { get; set; }
    }
}
