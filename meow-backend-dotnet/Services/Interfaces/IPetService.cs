using PawsBackendDotnet.Models.DTO.PetsDtos;
using PawsBackendDotnet.Models.Entities;

namespace PawsBackendDotnet.Services.Interfaces
{
    public interface IPetService
    {
        Task<Pet[]> GetAllPetsAsync(Guid? userId);
        Task<Pet?> GetPetByIdAsync(Guid? userId, Guid petId);
        Task<Pet?> CreatePetAsync(Guid? userId, CreatePetRequestDto createPetDto);
        Task<Pet?> UpdatePetAsync(Guid? userId, Guid petId, UpdatePetRequestDto updatePetDto);
        Task DeletePetAsync(Guid? userId, Guid id);

        Task<Pet?> UpdatePetActionsAsync(Guid? userId, Guid petId, Action<Pet> updateAction);
    }
}
