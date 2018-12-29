using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Urzad.Responses;

namespace Urzad.Repositories
{
    public interface IOffersRep
    {
        Task<List<OffersResponse>> GetAsync();
        Task<List<OffersResponse>> GetAsync(int id);
        Task<List<Oferty>> GetAllAsync();
    }
}
