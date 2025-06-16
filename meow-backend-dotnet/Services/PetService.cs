using AutoMapper;
using PawsBackendDotnet.Data.Repositories.Interfaces;
using PawsBackendDotnet.Models.DTO.PetsDtos;
using PawsBackendDotnet.Models.Entities;
using PawsBackendDotnet.Services.Interfaces;

namespace PawsBackendDotnet.Services
{
    public class PetService(IPetRepository repository, IMapper mapper) : IPetService
    {
        private readonly IPetRepository _repository = repository;
        private readonly IMapper _mapper = mapper;

        public async Task<Pet[]> GetAllPetsAsync(Guid? userId)
        {
            ArgumentNullException.ThrowIfNull(userId);
            return await _repository.GetAllPetsAsync(userId.Value);
        }

        public async Task<Pet?> GetPetByIdAsync(Guid? userId, Guid petId)
        {
            ArgumentNullException.ThrowIfNull(userId);
            return await _repository.GetPetByIdAsync(userId.Value, petId);
        }

        public async Task<Pet?> CreatePetAsync(Guid? userId, CreatePetRequestDto createPetDto)
        {
            ArgumentNullException.ThrowIfNull(userId);
            createPetDto.UserID = userId;

            return await _repository.CreatePetAsync(createPetDto);
        }

        public async Task<Pet?> UpdatePetAsync(Guid? userId, Guid petId, UpdatePetRequestDto updatePetDto)
        {
            ArgumentNullException.ThrowIfNull(userId);
            Pet pet = await _repository.GetPetByIdAsync(userId.Value, petId)
                ?? throw new Exception($"[status 404] Pet with id {petId} not found");

            pet.Name = updatePetDto.Name;
            pet.Type = updatePetDto.Type;
            pet.Breed = updatePetDto.Breed;
            pet.Sex = updatePetDto.Sex;
            pet.ChipNumber = updatePetDto.ChipNumber;
            pet.ImageUrl = updatePetDto.ImageUrl;
            pet.BirthDate = updatePetDto.BirthDate;
            pet.IsVaccine = updatePetDto.IsVaccine;

            return await _repository.UpdatePetAsync(pet);
        }

        public async Task DeletePetAsync(Guid? userId, Guid petId)
        {
            ArgumentNullException.ThrowIfNull(userId);
            Pet pet = await _repository.GetPetByIdAsync(userId.Value, petId)
                ?? throw new Exception($"[status 404] Pet with id {petId} not found");

            await _repository.DeletePetAsync(pet);
        }
        public async Task<Pet?> UpdatePetActionsAsync(Guid? userId, Guid petId, Action<Pet> updateAction)
        {
            ArgumentNullException.ThrowIfNull(userId);
            var pet = await _repository.GetPetByIdAsync(userId.Value, petId)
                ?? throw new Exception($"[status 404] Pet with id {petId} not found");

            updateAction(pet);
            return await _repository.UpdatePetAsync(pet);
        }
    }
}
