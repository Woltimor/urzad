using System;
using System.Collections.Generic;

namespace Urzad.Data.Models
{
    public partial class Login
    {
        public int IdLogin { get; set; }
        public int? IdOsoby { get; set; }
        public string Login1 { get; set; }
        public string Hasło { get; set; }
        public string Uprawnienia { get; set; }

        public Osoba IdOsobyNavigation { get; set; }
    }
}
