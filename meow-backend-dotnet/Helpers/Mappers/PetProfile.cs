using AutoMapper;
using PawsBackendDotnet.Models.DTO.PetsDtos;
using PawsBackendDotnet.Models.Entities;

namespace PawsBackendDotnet.Helpers.Mappers
{
    public class PetProfile : Profile
    {
        public PetProfile()
        {
            CreateMap<CreatePetRequestDto, Pet>();

            CreateMap<UpdatePetRequestDto, Pet>()
                .ForAllMembers(opt =>
                    opt.Condition((src, dest, srcMember) => srcMember != null));
        }
    }
}
