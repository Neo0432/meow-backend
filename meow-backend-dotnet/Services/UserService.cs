using PawsBackendDotnet.Models.Entities;
using PawsBackendDotnet.Services.Interfaces;
using PawsBackendDotnet.Models.DTO.UserDTOs;
using Microsoft.AspNetCore.Identity;
using PawsBackendDotnet.Data.Repositories.Interfaces;

namespace PawsBackendDotnet.Services
{
    public class UserService : IUserService
    {
        private readonly IUserRepository _repository;
        private readonly PasswordHasher<User> _passwordHasher = new PasswordHasher<User>();

        public UserService(IUserRepository repository)
        {
            _repository = repository;
        }

        public Task<User?> GetUserAsync(Guid id)
        {
            return _repository.GetByIdAsync(id);
        }

        public async Task<User?> LoginUserAsync(AuthUserRequestDTO loginData)
        {
            User? user = await _repository.GetByEmailAsync(loginData.Email) ?? throw new Exception("User not found");
            if (user.PasswordHash == null) throw new Exception("User has no password");
            PasswordVerificationResult result = _passwordHasher.VerifyHashedPassword(user, user.PasswordHash, loginData.Password);

            if (result == PasswordVerificationResult.Failed)
                throw new Exception("Invalid password");

            return user;
        }

        public async Task<User> CreateUserAsync(AuthUserRequestDTO newUser)
        {
            ArgumentNullException.ThrowIfNull(newUser);
            if (string.IsNullOrWhiteSpace(newUser.Email)) throw new ArgumentException("Email is required");

            User? existing = await _repository.GetByEmailAsync(newUser.Email);
            if (existing != null) throw new Exception("User already exists");

            var userEntity = new User
            {
                Email = newUser.Email,
            };

            var hashedPassword = _passwordHasher.HashPassword(userEntity, newUser.Password);

            userEntity.PasswordHash = hashedPassword;

            User? createdUser = await _repository.AddAsync(userEntity);
            return createdUser;
        }

        public async Task<User?> UpdateUserAsync(Guid id, User updated)
        {
            if (id != updated.ID) throw new Exception("Id is not same with id of updated entity");

            User? existingUser = await _repository.GetByIdAsync(id)
                ?? throw new Exception("User is not exists");

            User? user = await _repository.UpdateAsync(updated);
            return user;
        }

        public async Task<User?> DeleteUserAsync(Guid id)
        {
            var user = await _repository.GetByIdAsync(id);
            if (user == null) return null;

            await _repository.DeleteAsync(user);
            return user;
        }
    }
}
