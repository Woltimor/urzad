using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Urzad.Responses;

namespace Urzad.Services
{
    public interface IManagementServ
    {
        Task<int> insert(ManagementResponse managementResponse);
        Task<int> insert(KategoriaOferty kat);
        Task<int> insert(Responses.Oferty oferty);
        Task<int> insert(Responses.PosiadaneKwalifikacjes kwalifikacje);
        Task<int> UpdateType(int id, ManagementResponse types);
        Task<int> UpdateCategory(int id, CategoryResponse categories);

        Task<int> UpdateOffer(int id, OfferResponse offers);
        Task<List<ManagementResponse>> GetTypeAsync();
        Task<List<CategoryResponse>> GetCategoryAsync();
        Task<List<OfferResponse>> GetOfferAsync();


    }
}
