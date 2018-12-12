using System;
using System.Collections.Generic;

namespace Urzad.Data.Models
{
    public partial class DataRejestracji
    {
        public int IdDaty { get; set; }
        public int? IdOsoby { get; set; }
        public DateTime? DataRejestracji1 { get; set; }
        public DateTime? DataKońcowa { get; set; }

        public Osoba IdOsobyNavigation { get; set; }
    }
}
