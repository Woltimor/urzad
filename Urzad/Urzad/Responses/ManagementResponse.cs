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
    }
    public class CategoryResponse // Kategoria
    {
        public int IdKategorii { get; set; }
        public int? IdTypu { get; set; }
        public string Nazwa { get; set; }
    }

    public class OfferResponse // Oferta
    {

         public int IdOferty { get; set; }
         public int? IdKategorii { get; set; }
         public string OpisOferty { get; set; }

    }
    public class QualificationResponse
    {
        public int IdKwalifikacji { get; set; }
        public string Opis { get; set; }
    }
    public class RolesResponse
    {
        public string Uprawnienia { get; set; }
    }


}
