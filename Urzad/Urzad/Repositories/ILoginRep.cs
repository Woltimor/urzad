using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Urzad.Data.Models;
using Urzad.Responses;

namespace Urzad.Repositories
{
    public interface ILoginRep
    {
        Task<LoginResponse> GetAsync(int id);
        Task<List<LoginResponse>> GetAsync();
        Task InsertAsync(Login log, Osoba os, Data.Models.DataRejestracji data);
        Task UpdateLogin(int id, Login login, Osoba osoba);

    }
}
