using AutoMapper;
using PawsBackendDotnet.Models.DTO.UserDTOs;
using PawsBackendDotnet.Models.Entities;

namespace PawsBackendDotnet.Helpers
{
    public class MappingUser : Profile
    {
        public MappingUser()
        {
            CreateMap<User, ResponseUserDTO>();
        }
    }
}
