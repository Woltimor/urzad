using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Urzad.Data.Models;

namespace Urzad.Responses
{
    public class TypeCategoryResponse
    {
        public int IdKategorii { get; set; }
        public int? IdTypu { get; set; }
        public string Nazwa { get; set; }
        public TypOferty IdTypuNavigation { get; set; }
        public string Opis { get; set; }
        public ICollection<KategoriaOferty> KategoriaOferty { get; set; }
    }
}
