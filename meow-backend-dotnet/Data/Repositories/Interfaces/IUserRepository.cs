using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using PawsBackendDotnet.Models.Entities;

namespace PawsBackendDotnet.Data.Repositories.Interfaces
{
    public interface IUserRepository
    {
        Task<User?> GetByEmailAsync(string email);
        Task<User?> GetByIdAsync(Guid id);
        Task<User> AddAsync(User user);
        Task<User?> UpdateAsync(User user);
        Task DeleteAsync(User user);
    }
}
