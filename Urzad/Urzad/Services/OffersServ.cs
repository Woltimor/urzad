using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Urzad.Repositories;
using Urzad.Responses;

namespace Urzad.Services
{
    public class OffersServ : IOffersServ
    {

            private readonly IOffersRep _offersRep;

            public OffersServ(IOffersRep offersRep)
            {
                 _offersRep = offersRep;
            }

            public async Task<List<OffersResponse>> GetAsync(int id)
            {
                var result = await _offersRep.GetAsync(id);
                return result;
            }

            public async Task<List<OffersResponse>> GetAsync()
            {
                var result = await _offersRep.GetAsync();
                return result;
            }
        
    }
}
