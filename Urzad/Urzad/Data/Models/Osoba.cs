using System;
using System.Collections.Generic;

namespace Urzad.Data.Models
{
    public partial class Osoba
    {
        public Osoba()
        {
            
            PosiadaneKwalifikacje = new HashSet<PosiadaneKwalifikacje>();
            Wniosek = new HashSet<Wniosek>();
        }

        public int IdOsoby { get; set; }
        public string Imie { get; set; }
        public string Nazwisko { get; set; }
        public string Pesel { get; set; }
        public string Wyksztalcenie { get; set; }
        public string Email { get; set; }
        public DateTime? DataUrodzenia { get; set; }
        public string Plec { get; set; }
        public byte[] HasłoHash { get; set; }
        public byte[] HasłoSalt { get; set; }
        public string Login { get; set; }
        public int Dostep { get; set; }
        public string Uprawnienia { get; set; }
        public DateTime? DataRejestracji { get; set; }
        public DateTime? DataKońcowa { get; set; }

        public ICollection<PosiadaneKwalifikacje> PosiadaneKwalifikacje { get; set; }
        public ICollection<Wniosek> Wniosek { get; set; }
    }
}
