using System;
using System.Collections.Generic;

namespace Urzad.Data.Models
{
    public partial class PosiadaneKwalifikacje
    {
        public int IdOsoby { get; set; }
        public int IdKwalifikacji { get; set; }

        public Kwalifikacje IdKwalifikacjiNavigation { get; set; }
        public Osoba IdOsobyNavigation { get; set; }
    }
}
