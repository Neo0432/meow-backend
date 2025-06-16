using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using PawsBackendDotnet.Models.Entities;

namespace PawsBackendDotnet.Services.Interfaces
{
    public interface IJwtAuthService
    {
        string GenerateToken(User user);
    }
}
