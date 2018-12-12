using System;
using System.Collections.Generic;

namespace Urzad.Data.Models
{
    public partial class TypOferty
    {
        public TypOferty()
        {
            KategoriaOferty = new HashSet<KategoriaOferty>();
        }

        public int IdTypu { get; set; }
        public string Opis { get; set; }

        public ICollection<KategoriaOferty> KategoriaOferty { get; set; }
    }
}
