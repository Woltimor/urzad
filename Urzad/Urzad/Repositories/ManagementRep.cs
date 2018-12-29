using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Urzad.Data.Models;
using Urzad.Responses;

namespace Urzad.Repositories
{
    public class ManagementRep : IManagementRep
    {
        private readonly UrzadPracyContext _context;
        public ManagementRep(UrzadPracyContext context)
        {
            _context = context;
        }
        public async Task InsertAsync(TypOferty typ)
        {
            _context.TypOferty.Add(typ);
           await _context.SaveChangesAsync();
        }
        public async Task InsertAsync(Data.Models.KategoriaOferty kat)
        {
            _context.KategoriaOferty.Add(kat);
            await _context.SaveChangesAsync();
        }

        public async Task InsertAsync(Data.Models.Oferty oferty)
        {
           _context.Oferty.Add(oferty);
            await _context.SaveChangesAsync();

        }
        public async Task InsertAsync(Kwalifikacje kwalifikacje)
        {
            _context.Kwalifikacje.Add(kwalifikacje);
            await _context.SaveChangesAsync();

        }
        public async Task UpdateType(int id, TypOferty typ)
        {
            var typx = _context.TypOferty.Find(id);
            typx.Opis = typ.Opis;
            _context.Entry(typx).State = EntityState.Modified;
            await _context.SaveChangesAsync();

        }
        public async Task UpdateCategory(int id, Data.Models.KategoriaOferty kategoria)
        {
            var katx = _context.KategoriaOferty.Find(id);
            katx.Nazwa = kategoria.Nazwa;
            _context.Entry(katx).State = EntityState.Modified;
            await _context.SaveChangesAsync();

        }
        public async Task UpdateOffer(int id, Data.Models.Oferty oferty)
        {
            var ofx = _context.Oferty.Find(id);
            ofx.OpisOferty = oferty.OpisOferty;
            _context.Entry(ofx).State = EntityState.Modified;
            await _context.SaveChangesAsync();

        }
        public async Task<List<ManagementResponse>> GetTypeAsync()
        {
            return await _context.TypOferty.Select(z => new ManagementResponse
            {
                Opis = z.Opis,
                IdTypu = z.IdTypu
            }).ToListAsync();
        }
        public async Task<List<CategoryResponse>> GetCategoryAsync()
        {
            return await _context.KategoriaOferty.Select(z => new CategoryResponse
            {
                IdKategorii= z.IdKategorii,
                IdTypu = z.IdTypu,
                Nazwa = z.Nazwa
            }).ToListAsync();
        }
        public async Task<List<OfferResponse>> GetOfferAsync()
        {
            return await _context.Oferty.Select(z => new OfferResponse
            {
                IdKategorii = z.IdKategorii,
                IdOferty = z.IdOferty,
                OpisOferty = z.OpisOferty
            }).ToListAsync();
        }

    }
}
