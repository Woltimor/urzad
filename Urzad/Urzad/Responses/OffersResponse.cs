using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Urzad.Data.Models;

namespace Urzad.Responses
{
    public class OffersResponse
    {
        public int IdTypu { get; set; }
        public string Opis { get; set; }
        public ICollection<KategoriaOferty> KategoriaOferty { get; set; }

    }
    
    public class Oferty
    {
        public int IdOferty { get; set; }
        public int? IdTypu { get; set; }
        public string Opis { get; set; }
        public string OpisTypu { get; set; }
        public int? Pensja { get; set; }
        public string AdresFirmy { get; set; }
        public string Email { get; set; }
        public int? IdKategorii { get; set; }
        public string Nazwa { get; set; }
        public string OpisOferty { get; set; }
        public KategoriaOferty IdKategoriiNavigation { get; set; }
        public ICollection<WymaganeOsiągnięcia> WymaganeOsiągnięcia { get; set; }
    }

    public class KategoriaOferty
    {
        public int IdKategorii { get; set; }
        public int? IdTypu { get; set; }
        public string Nazwa { get; set; }
        public ICollection<Oferty> Oferty { get; set; }
        public TypOferty IdTypuNavigation { get; set; }

    }
    public class WymaganeOsiągnięcia
    {
        public int IdKwalifikacji { get; set; }
        public int IdOferty { get; set; }
        public Kwalifikacje IdKwalifikacjiNavigation { get; set; }
        public string Opis { get; set; }

    }

}

