using AutoMapper;
using Microsoft.EntityFrameworkCore;
using PawsBackendDotnet.Data.Repositories.Interfaces;
using PawsBackendDotnet.Models.DTO.PetsDtos;
using PawsBackendDotnet.Models.Entities;

namespace PawsBackendDotnet.Data.Repositories
{
    public class PetRepository(PawsContext context, IMapper mapper) : IPetRepository
    {
        private readonly PawsContext _context = context;
        private readonly IMapper _mapper = mapper;

        public async Task<Pet[]> GetAllPetsAsync(Guid userId)
        {
            return await _context.Pets.Where(pet => pet.UserID == userId).ToArrayAsync();
        }

        public async Task<Pet?> GetPetByIdAsync(Guid userId, Guid petId)
        {
            return await _context.Pets
                .FirstOrDefaultAsync(p => p.ID == petId && p.UserID == userId);
        }

        public async Task<Pet?> CreatePetAsync(CreatePetRequestDto createPetDto)
        {
            var petToCreate = _mapper.Map<Pet>(createPetDto);

            _context.Pets.Add(petToCreate);
            await _context.SaveChangesAsync();
            return petToCreate;
        }

        public async Task<Pet?> UpdatePetAsync(Pet updatedPet)
        {
            _context.Pets.Entry(updatedPet).State = EntityState.Modified;
            await _context.SaveChangesAsync();
            return await _context.Pets.FindAsync(updatedPet.ID);
        }

        public async Task DeletePetAsync(Pet pet)
        {
            _context.Pets.Remove(pet);
            await _context.SaveChangesAsync();
        }
    }
}
