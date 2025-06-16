using System.ComponentModel.DataAnnotations;

namespace PawsBackendDotnet.Models.Entities
{
    public class User : EntityBase
    {
        public string Username { get; set; } = "User";

        [Required]
        public required string Email { get; set; }
        [Required]
        public string? PasswordHash { get; set; }
        public string? PhoneNumber { get; set; }
        public string? ImageUrl { get; set; }

        public List<Pet> Pets { get; set; } = [];
    }

}
