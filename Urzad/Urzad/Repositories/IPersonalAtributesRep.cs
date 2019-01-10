using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Urzad.Data.Models;
using Urzad.Responses;

namespace Urzad.Repository
{
    public interface IPersonalAtributesRep
    {
        Task<List<PersonalAtributesResponse>> GetAsync();
        Task<PersonalAtributesResponse> GetAsync(int id);
        Task<List<ExpextedAchievementsResponse>> GetAchievementsAsync(int id);
    }
}
