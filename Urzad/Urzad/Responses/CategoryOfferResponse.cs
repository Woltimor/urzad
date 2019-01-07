using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Urzad.Responses
{
    public class CategoryOfferResponse
    {
        public string Nazwa { get; set; }
        public int IdOferty { get; set; }
        public int? IdKategorii { get; set; }
        public string OpisOferty { get; set; }
        public KategoriaOferty IdKategoriiNavigation { get; set; }
    }
}
