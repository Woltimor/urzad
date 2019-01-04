using System;
using System.Collections.Generic;

namespace Urzad.Data.Models
{
    public partial class Oferty
    {
        public Oferty()
        {
            WymaganeOsiągnięcia = new HashSet<WymaganeOsiągnięcia>();
        }

        public int IdOferty { get; set; }
        public int? IdKategorii { get; set; }
        public string OpisOferty { get; set; }
        public DateTime? DataRejestracji1 { get; set; }
        public DateTime? DataKońcowa { get; set; }
        public KategoriaOferty IdKategoriiNavigation { get; set; }
        public ICollection<WymaganeOsiągnięcia> WymaganeOsiągnięcia { get; set; }
    }
}
