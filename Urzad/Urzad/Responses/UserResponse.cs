using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Urzad.Responses
{
    public class UserResponse
    {
        public string Imie { get; set; }
        public string Nazwisko { get; set; }
        public string Login { get; set; }
        public string Haslo { get; set; }
        public string Uprawnienia { get; set; }
        public string Pesel { get; set; }
        public string Wyksztalcenie { get; set; }
        public int Dostep { get; set; }
        public string Email { get; set; }
        public string Plec { get; set; }
        public DateTime? DataUrodzenia { get; set; }

    }
}
