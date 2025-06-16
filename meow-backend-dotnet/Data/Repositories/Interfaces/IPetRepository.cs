using PawsBackendDotnet.Models.DTO.PetsDtos;
using PawsBackendDotnet.Models.Entities;

namespace PawsBackendDotnet.Data.Repositories.Interfaces
{
    public interface IPetRepository
    {
        Task<Pet[]> GetAllPetsAsync(Guid userId);
        Task<Pet?> GetPetByIdAsync(Guid userId, Guid petId);
        Task<Pet?> CreatePetAsync(CreatePetRequestDto createPetDto);
        Task<Pet?> UpdatePetAsync(Pet petUpdate);
        Task DeletePetAsync(Pet pet);
    }
}
