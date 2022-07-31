using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace AudifyProject.ViewModels
{
    public class TokenResult
    {
        public string Name { get; set; }
        public string Token { get; set; }
        public DateTime Expiration { get; set; }
    }
}
