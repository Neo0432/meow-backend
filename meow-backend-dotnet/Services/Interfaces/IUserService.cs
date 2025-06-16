using PawsBackendDotnet.Models.DTO.UserDTOs;
using PawsBackendDotnet.Models.Entities;

namespace PawsBackendDotnet.Services.Interfaces
{
    public interface IUserService
    {
        Task<User?> GetUserAsync(Guid id);
        Task<User?> LoginUserAsync(AuthUserRequestDTO loginData);
        Task<User> CreateUserAsync(AuthUserRequestDTO user);
        Task<User?> UpdateUserAsync(Guid id, User updated);
        Task<User?> DeleteUserAsync(Guid id);
    }
}
