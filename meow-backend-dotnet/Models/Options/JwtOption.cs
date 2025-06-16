using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace PawsBackendDotnet.Models.Options
{
    public class JwtOptions
    {
        public string Issuer { get; set; } = null!;
        public string Audience { get; set; } = null!;
        public string SecretKey { get; set; } = null!;
        public int ExpirationMinutes { get; set; }
    }

}
