using System;
using System.Collections.Generic;

namespace Urzad.Data.Models
{
    public partial class Wniosek
    {
        public int IdOsoby { get; set; }
        public int IdKategorii { get; set; }

        public KategoriaOferty IdKategoriiNavigation { get; set; }
        public Osoba IdOsobyNavigation { get; set; }
    }
}
