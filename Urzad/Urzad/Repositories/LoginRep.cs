using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Urzad.Data.Models;
using Urzad.Responses;

namespace Urzad.Repositories
{
    public class LoginRep : ILoginRep
    {
        private readonly UrzadPracyContext _context;

        public LoginRep(UrzadPracyContext context)
        {
            _context = context;
        }
        public async Task<LoginResponse> GetAsync(int id)
        {
            return await _context.Osoba.Where(o => o.IdOsoby == id)
                .Select(l => new LoginResponse
                {
                    IdOsoby = l.IdOsoby,
                    Imie = l.Imie,
                    Nazwisko = l.Nazwisko,
                    Pesel = l.Pesel,
                    Wykształcenie = l.Wykształcenie,
                    Login = l.Login.Where(z => z.IdOsoby == l.IdOsoby).Select(c => new Logins
                    {
                        Login1 = c.Login1,
                        Hasło = c.Hasło,
                        Uprawnienia = c.Uprawnienia
                    }).ToList()
            }).SingleOrDefaultAsync();
        }

        public Task<List<LoginResponse>> GetAsync()
        {
            throw new NotImplementedException();
        }


        public async Task InsertAsync(Login log, Osoba os, Data.Models.DataRejestracji data)
        {
         _context.Osoba.Add(os);
         await _context.SaveChangesAsync();
         log.IdOsoby = os.IdOsoby;
         _context.Login.Add(log);
         await _context.SaveChangesAsync();
         data.IdOsoby = os.IdOsoby;
         _context.DataRejestracji.Add(data);
         await _context.SaveChangesAsync();
        }
    }
}
