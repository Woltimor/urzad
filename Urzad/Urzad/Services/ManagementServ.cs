using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Urzad.Data.Models;
using Urzad.Repositories;
using Urzad.Responses;

namespace Urzad.Services
{
    public class ManagementServ : IManagementServ
    {
        private readonly IManagementRep _managementRep;
        public ManagementServ(IManagementRep managementRep)
        {
            _managementRep = managementRep;
        }

        public async Task<int> insert(ManagementResponse managementResponse) //opis do TypOferty
        {
            TypOferty typ = new TypOferty()
            {
                Opis = managementResponse.Opis
            };
            await _managementRep.InsertAsync(typ);
            return (int)typ.IdTypu;
        }
        public async Task<int> insert(Responses.KategoriaOferty kategoriaOferty) //dane do Kategorii oferty
        {
            Data.Models.KategoriaOferty kat = new Data.Models.KategoriaOferty()
            {
                IdTypu = kategoriaOferty.IdTypu,
                Nazwa = kategoriaOferty.Nazwa
            };
            await _managementRep.InsertAsync(kat);
            return (int)kat.IdKategorii;
        }
        public async Task<int> insert(Responses.Oferty oferty) //dane do Oferty
        {
            Data.Models.Oferty of = new Data.Models.Oferty()
            {
                IdKategorii = oferty.IdKategorii,
                OpisOferty = oferty.OpisOferty
            };
            await _managementRep.InsertAsync(of);
            return (int)oferty.IdOferty;
        }
        public async Task<int> insert(Responses.PosiadaneKwalifikacjes kwalifikacje) //dane do Kwalifikacji
        {
            Data.Models.Kwalifikacje kw = new Data.Models.Kwalifikacje()
            {
                Opis = kwalifikacje.Opis
            };
            await _managementRep.InsertAsync(kw);
            return (int)kwalifikacje.IdKwalifikacji;
            //xD
        }
        public async Task<int> UpdateType(int id, ManagementResponse types)
        {
            TypOferty typ = new TypOferty
            {
                Opis = types.Opis
            };
            try
            {
                await _managementRep.UpdateType(id, typ);
            }
            catch (Exception e)
            {
                return -1;
            }
            return id;
        }
        public async Task<int> UpdateCategory(int id, CategoryResponse categories) {
            Data.Models.KategoriaOferty kat = new Data.Models.KategoriaOferty
            {
                Nazwa = categories.Nazwa
            };
            try
            {
                await _managementRep.UpdateCategory(id, kat);
            }
            catch (Exception e)
            {
                return -1;
            }
            return id;
        }

        public async Task<int> UpdateOffer(int id, OfferResponse offers) {
            Data.Models.Oferty off = new Data.Models.Oferty
            {
                OpisOferty = offers.OpisOferty
            };
            try
            {
                await _managementRep.UpdateOffer(id, off);
            }
            catch (Exception e)
            {
                return -1;
            }
            return id;
        }
        public async Task<List<ManagementResponse>> GetTypeAsync()
        {
            var result = await _managementRep.GetTypeAsync();
            return result;
        }
        public async Task<List<CategoryResponse>> GetCategoryAsync()
        {
            var result = await _managementRep.GetCategoryAsync();
            return result;
        }
        public async Task<List<OfferResponse>> GetOfferAsync()
        {
            var result = await _managementRep.GetOfferAsync();
            return result;
        }



    }
}
