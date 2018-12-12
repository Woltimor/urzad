using System;
using System.Collections.Generic;

namespace Urzad.Data.Models
{
    public partial class WymaganeOsiągnięcia
    {
        public int IdKwalifikacji { get; set; }
        public int IdOferty { get; set; }

        public Kwalifikacje IdKwalifikacjiNavigation { get; set; }
        public Oferty IdOfertyNavigation { get; set; }
    }
}
