using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Urzad.Data.Models;

namespace Urzad.Repositories
{
    public interface IManagementRep
    {
        Task InsertAsync(TypOferty typ);
        Task InsertAsync(KategoriaOferty kat);
        Task InsertAsync (Oferty oferty);
        Task InsertAsync(Kwalifikacje kwalifikacje);
        //co to kurwa jest
    }
}
