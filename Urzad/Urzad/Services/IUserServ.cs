using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Urzad.Data.Models;

namespace Urzad.Services
{
   public interface IUserServ
    {
        Osoba Authenticate(string login, string haslo);
        IEnumerable<Osoba> GetAll();
        Osoba GetById(int id);
        Osoba Create(Osoba osoba, string haslo);
        void Update(Osoba osobaParam, string haslo = null);
        void Delete(int id);
    }
}
