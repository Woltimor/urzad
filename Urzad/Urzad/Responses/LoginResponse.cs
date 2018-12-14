using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Urzad.Responses
{
    public class LoginResponse
    {

        public int IdOsoby { get; set; }
        public string Imie { get; set; }
        public string Nazwisko { get; set; }
        public string Pesel { get; set; }
        public string Wykształcenie { get; set; }
        public string Email { get; set; }
        public DateTime? DataUrodzenia { get; set; }
        public string Płeć { get; set; }
        public string Login1 { get; set; }
        public string Hasło { get; set; }

        public ICollection<Logins> Login { get; set; }
        public ICollection<DataRejestracji> DataRejestracjis { get; set; }
    }
        
        public  class Logins
        {
            public int IdLogin { get; set; }
            public int? IdOsoby { get; set; }
            public string Login1 { get; set; }
            public string Hasło { get; set; }
            public string Uprawnienia { get; set; }
           

        public LoginResponse IdOsobyNavigation { get; set; }
        }
    public class DataRejestracji
    {
        public int IdDaty { get; set; }
        public int? IdOsoby { get; set; }
        public DateTime? DataRejestracji1 { get; set; }
        public DateTime? DataKońcowa { get; set; }

        public LoginResponse IdOsobyNavigation { get; set; }
    }


}

