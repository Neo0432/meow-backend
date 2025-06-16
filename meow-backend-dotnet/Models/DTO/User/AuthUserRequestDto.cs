using System.ComponentModel.DataAnnotations;

namespace PawsBackendDotnet.Models.DTO.UserDTOs
{
    public class AuthUserRequestDTO
    {
        [Required]
        public required string Email { get; set; }
        [Required]
        public required string Password { get; set; }
    }
}
