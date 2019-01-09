using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Urzad.Data.Models;

namespace Urzad.Responses
{
    public class PersonalAtributesResponse
    {
        public int IdOsoby { get; set; }
        public string Imie { get; set; }
        public string Nazwisko { get; set; }
        public string Pesel { get; set; }
        public string Wykształcenie { get; set; }
        public string Email { get; set; }
        public string Uprawnienia { get; set; }
        public ICollection<PosiadaneKwalifikacjes> PosiadaneKwalifikacjes { get; set; }
        public ICollection<Wniosek> Wniosek { get; set; }
     

        
    }
    public class PosiadaneKwalifikacjes
    {
        public string Opis;
        public int IdOsoby { get; set; }
        public int IdKwalifikacji { get; set; }
        public Kwalifikacje IdKwalifikacjiNavigation { get; set; }
    }
    public class Wniosek
    {
        public int IdOsoby { get; set; }
        public int IdKategorii { get; set; }

        public KategoriaOferty IdKategoriiNavigation { get; set; }
        public Osoba IdOsobyNavigation { get; set; }
        public string Nazwa { get; set; }
    }


}
