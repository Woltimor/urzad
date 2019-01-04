using System;
using System.Collections.Generic;

namespace Urzad.Data.Models
{
    public partial class KategoriaOferty
    {
        public KategoriaOferty()
        {
            Oferty = new HashSet<Oferty>();
            Wniosek = new HashSet<Wniosek>();
        }

        public int? IdKategorii { get; set; }
        public int? IdTypu { get; set; }
        public string Nazwa { get; set; }

        public TypOferty IdTypuNavigation { get; set; }
        public ICollection<Oferty> Oferty { get; set; }
        public ICollection<Wniosek> Wniosek { get; set; }
    }
}
