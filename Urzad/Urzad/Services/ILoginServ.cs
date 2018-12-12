using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Urzad.Data.Models;
using Urzad.Responses;

namespace Urzad.Services
{
    public interface ILoginServ
    {
        Task<LoginResponse> GetAsync(int id);
        Task<List<LoginResponse>> GetAsync();
        Task<int> insertLogin(LoginResponse loginResponse);
    }
}
