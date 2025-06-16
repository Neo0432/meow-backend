using PawsBackendDotnet.Models.Entities;
using Microsoft.EntityFrameworkCore;

namespace PawsBackendDotnet.Data
{
    public class PawsContext : DbContext
    {
        public PawsContext(DbContextOptions<PawsContext> options) : base(options) { }

        public DbSet<User> Users { get; set; }
        public DbSet<Pet> Pets { get; set; }
    }
}
