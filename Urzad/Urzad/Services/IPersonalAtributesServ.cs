using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Urzad.Data.Models;
using Urzad.Responses;

namespace Urzad.Services
{
    public interface IPersonalAtributesServ
    {

        Task<PersonalAtributesResponse> GetAsync(int id);
        Task<List<PersonalAtributesResponse>> GetAsync();
        //lol sdfsdf
    }
}
