using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Application.Services.Interfaces
{
    public interface IAuthenticationService
    {
        string GenerateToken(Guid userId);
        Guid GetUserIdFromToken(string token);

    }
}
