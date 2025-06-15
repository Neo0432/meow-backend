using PawsBackendDotnet.Models.Entities;

namespace PawsBackendDotnet.Models.DTO.UserDTOs
{
    public class AuthUserResponseDTO
    {
        public required string token { get; set; }
        public required User user { get; set; }
    }
}
