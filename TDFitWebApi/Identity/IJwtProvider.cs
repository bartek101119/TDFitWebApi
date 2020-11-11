using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using TDFitWebApi.Entities;

namespace TDFitWebApi.Identity
{
    public interface IJwtProvider
    {
        string GenerateJwtToken(User user);
    }
}
