using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Urzad.Data.Models;
using Urzad.Repositories;
using Urzad.Responses;

namespace Urzad.Services
{
    public class LoginServ : ILoginServ
    {
        private readonly ILoginRep _loginRep;
        public LoginServ(ILoginRep loginRep)
        {
            _loginRep = loginRep;
        }
        public async Task<LoginResponse> GetAsync(int id)
        {
            var result =   _loginRep.GetAsync(id);
            return await result;
        }


        public async Task<int> insertLogin(LoginResponse loginResponse)
        {
            
            Osoba os = new Osoba()
            {
                Imie = loginResponse.Imie,
                Nazwisko = loginResponse.Nazwisko,
                Pesel = loginResponse.Pesel,
                Wykształcenie = loginResponse.Wykształcenie,
                Email = loginResponse.Email,
                DataUrodzenia = loginResponse.DataUrodzenia,
                Płeć = loginResponse.Płeć,
                Login = loginResponse.Login,
                Uprawnienia = loginResponse.Uprawnienia
            };
            Data.Models.DataRejestracji data = new Data.Models.DataRejestracji()
            {
                DataRejestracji1 = System.DateTime.Now,
                DataKońcowa = System.DateTime.Now.AddMonths(6)
            };
            await _loginRep.InsertAsync(os, data);
            return (int)os.IdOsoby;

        }
        public async Task<int> UpdateLogin(int id , LoginResponse loginResponse)
        {
            Osoba osoba = new Osoba
            {
               Imie = loginResponse.Imie,
               Nazwisko = loginResponse.Nazwisko

            };
            try
            {
               await _loginRep.UpdateLogin(id, osoba);
            }
            catch (Exception e)
            {
                return -1;
            }
            return id;
        }
    }
}
