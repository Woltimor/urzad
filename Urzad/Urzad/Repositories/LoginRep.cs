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
                    Login = l.Login,
                    Uprawnienia = l.Uprawnienia
            }).SingleOrDefaultAsync();
        }



      //  public async Task InsertAsync(Osoba os, Data.Models.DataRejestracji data)
      //  {
      //   _context.Osoba.Add(os);
      //   await _context.SaveChangesAsync();
      //   await _context.SaveChangesAsync();
      //   data.IdOsoby = os.IdOsoby;
      ////   _context.DataRejestracji.Add(data);
      //   await _context.SaveChangesAsync();
      //  }
      //  public async Task UpdateLogin(int id, Osoba osoba)
      //  {
      //      var osobaX = _context.Osoba.Find(id);
      //      osobaX.Imie = osoba.Imie;
      //      osobaX.Nazwisko = osoba.Nazwisko;

      //      _context.Entry(osobaX).State = EntityState.Modified;
      //      await _context.SaveChangesAsync();
  
      //  }
    }
}
