using PawsBackendDotnet.Models.Entities;

namespace PawsBackendDotnet.Models.DTO.PetsDtos
{
    public class UpdatePetRequestDto
    {
        public required string Name { get; set; }
        public string? Type { get; set; }
        public string? Breed { get; set; }
        public Sex Sex { get; set; } = Sex.Male;
        public string? ChipNumber { get; set; }
        public string? ImageUrl { get; set; }
        public DateTime? BirthDate { get; set; }
        public bool IsVaccine { get; set; } = false;
    }
}
