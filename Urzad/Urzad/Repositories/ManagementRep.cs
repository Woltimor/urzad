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
        public async Task InsertAsync(Data.Models.PosiadaneKwalifikacje kw)
        {
            _context.PosiadaneKwalifikacje.Add(kw);
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
        public async Task InsertAsync(Data.Models.Wniosek wniosek)
        {
            _context.Wniosek.Add(wniosek);
            await _context.SaveChangesAsync();

        }
        public async Task InsertAsync(Data.Models.WymaganeOsiągnięcia wymaganeOsiągnięcia)
        {
            _context.WymaganeOsiągnięcia.Add(wymaganeOsiągnięcia);
            await _context.SaveChangesAsync();

        }
        public async Task UpdateType(int id, TypOferty typ)
        {
            var typx = _context.TypOferty.Find(id);
            typx.Opis = typ.Opis;
            _context.Entry(typx).State = EntityState.Modified;
            await _context.SaveChangesAsync();

        }
        public async Task UpdateAccess(int id, Osoba osoba)
        {
            var osx = _context.Osoba.Find(id);
            osx.Dostep = osoba.Dostep;
            _context.Entry(osx).State = EntityState.Modified;
            await _context.SaveChangesAsync();

        }
        public async Task UpdateRoles(int id, Osoba os)
        {
            var osx = _context.Osoba.Find(id);
            osx.Uprawnienia = os.Uprawnienia;
            _context.Entry(osx).State = EntityState.Modified;
            await _context.SaveChangesAsync();

        }
        public async Task UpdateCategory(int id, Data.Models.KategoriaOferty kategoria)
        {
            var katx = _context.KategoriaOferty.Find(id);
            katx.Nazwa = kategoria.Nazwa;
            katx.IdTypu = kategoria.IdTypu;
            _context.Entry(katx).State = EntityState.Modified;
            await _context.SaveChangesAsync();

        }
        public async Task UpdateOffer(int id, Data.Models.Oferty oferty)
        {
            var ofx = _context.Oferty.Find(id);
            ofx.OpisOferty = oferty.OpisOferty;
            ofx.IdKategorii = oferty.IdKategorii;
            ofx.AdresFirmy = oferty.AdresFirmy;
            ofx.Email = oferty.Email;
            ofx.Pensja = oferty.Pensja;
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
        public async Task<List<QualificationResponse>> GetQualificationsAsync()
        {
            return await _context.Kwalifikacje.Select(z => new QualificationResponse
            {
                IdKwalifikacji = z.IdKwalifikacji,
                Opis = z.Opis
            }).ToListAsync();
        }
        public async Task<List<CategoryResponse>> GetCategoryAsync()
        {
            return await _context.KategoriaOferty.Select(z => new CategoryResponse
            {
                IdKategorii= z.IdKategorii,
                IdTypu = z.IdTypu,
                Nazwa = z.Nazwa,
            }).ToListAsync();
        }
        public async Task<List<OfferResponse>> GetOfferAsync()
        {
            return await _context.Oferty.Select(z => new OfferResponse
            {
                IdKategorii = (int)z.IdKategorii,
                IdOferty = z.IdOferty,
                OpisOferty = z.OpisOferty
            }).ToListAsync();
        }
        public async Task<List<TypeCategoryResponse>> GetTypeCategoryAsync()
        {
            return await _context.KategoriaOferty.Select(z => new TypeCategoryResponse
            {
                IdKategorii = z.IdKategorii,
                Nazwa = z.Nazwa,
                IdTypu =z.IdTypuNavigation.IdTypu,
                Opis = z.IdTypuNavigation.Opis

            }).ToListAsync();
        }
        public async Task<List<CategoryOfferResponse>> GetCategoryOfferAsync()
        {
            return await _context.Oferty.Select(z => new CategoryOfferResponse
            {
                IdOferty= z.IdOferty,
                OpisOferty = z.OpisOferty,
                IdKategorii = z.IdKategoriiNavigation.IdKategorii,
                Nazwa = z.IdKategoriiNavigation.Nazwa
            }).ToListAsync();
        }

    }
}
