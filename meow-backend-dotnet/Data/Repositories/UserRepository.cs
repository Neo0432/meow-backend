using Microsoft.EntityFrameworkCore;
using PawsBackendDotnet.Data.Repositories.Interfaces;
using PawsBackendDotnet.Models.Entities;

namespace PawsBackendDotnet.Data.Repositories
{
    public class UserRepository : IUserRepository
    {
        private readonly PawsContext _context;
        public UserRepository(PawsContext context)
        {
            _context = context;
        }

        public async Task<User?> GetByEmailAsync(string? email)
        {
            if (email == null) return null;
            return await _context.Users.FirstOrDefaultAsync(u => u.Email == email); ;
        }

        public async Task<User?> GetByIdAsync(Guid id) =>
        await _context.Users.FindAsync(id);

        public async Task<User> AddAsync(User user)
        {
            _context.Users.Add(user);
            await _context.SaveChangesAsync();
            return user;
        }

        public async Task<User?> UpdateAsync(User user)
        {
            _context.Entry(user).State = EntityState.Modified;
            await _context.SaveChangesAsync();
            return await _context.Users.FindAsync(user.ID);
        }

        public async Task DeleteAsync(User deletedUser)
        {
            _context.Users.Remove(deletedUser);
            await _context.SaveChangesAsync();
        }

    }
}
