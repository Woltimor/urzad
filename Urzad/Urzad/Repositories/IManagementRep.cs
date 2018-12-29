using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Urzad.Data.Models;
using Urzad.Responses;

namespace Urzad.Repositories
{
    public interface IManagementRep
    {
        Task InsertAsync(TypOferty typ);
        Task InsertAsync(Data.Models.KategoriaOferty kat);
        Task InsertAsync (Data.Models.Oferty oferty);
        Task InsertAsync(Kwalifikacje kwalifikacje);
        Task UpdateType(int id, TypOferty typ);
        Task UpdateCategory(int id, Data.Models.KategoriaOferty kat);
        Task UpdateOffer(int id, Data.Models.Oferty off);
        Task<List<ManagementResponse>> GetTypeAsync();
        Task<List<CategoryResponse>> GetCategoryAsync();
        Task<List<OfferResponse>> GetOfferAsync();
    }
}
