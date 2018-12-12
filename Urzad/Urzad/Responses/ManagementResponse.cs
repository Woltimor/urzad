using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Urzad.Responses
{
    public class ManagementResponse // typ oferty
    {

        public int IdTypu { get; set; }
        public string Opis { get; set; }
        public ICollection<KategoriaOferty> KategoriaOferty { get; set; }
    }

}
