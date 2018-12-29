using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Urzad.Responses;

namespace Urzad.Services
{
   public  interface IOffersServ
    {

        Task<List<OffersResponse>> GetAsync(int id);
        Task<List<OffersResponse>> GetAsync();
        Task<List<Oferty>> GetAllAsync();

    }
}
