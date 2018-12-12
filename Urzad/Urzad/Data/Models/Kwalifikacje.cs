using System;
using System.Collections.Generic;

namespace Urzad.Data.Models
{
    public partial class Kwalifikacje
    {
        public Kwalifikacje()
        {
            PosiadaneKwalifikacje = new HashSet<PosiadaneKwalifikacje>();
            WymaganeOsiągnięcia = new HashSet<WymaganeOsiągnięcia>();
        }

        public int IdKwalifikacji { get; set; }
        public string Opis { get; set; }

        public ICollection<PosiadaneKwalifikacje> PosiadaneKwalifikacje { get; set; }
        public ICollection<WymaganeOsiągnięcia> WymaganeOsiągnięcia { get; set; }
    }
}
