using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Urzad.Data.Models;
using Urzad.Repository;
using Urzad.Responses;

namespace Urzad.Services
{
    public class PersonalAtributesServ : IPersonalAtributesServ
    {

        private readonly IPersonalAtributesRep _personalAtributes;

        public PersonalAtributesServ (IPersonalAtributesRep personalAtributes)
        {
            _personalAtributes = personalAtributes;
        }

    public async Task<PersonalAtributesResponse> GetAsync(int id)
        {
            var result =  await _personalAtributes.GetAsync(id);
            return result;
        }

    public async Task<List<PersonalAtributesResponse>> GetAsync()
        {
            var result = await _personalAtributes.GetAsync();
            return result;
        }
    }
}
