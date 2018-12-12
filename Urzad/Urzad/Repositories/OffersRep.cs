using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Urzad.Data.Models;
using Urzad.Responses;

namespace Urzad.Repositories
{
    public class OffersRep : IOffersRep

    {
        private readonly UrzadPracyContext _context;
        public OffersRep(UrzadPracyContext context)
        {
            _context = context;
        }

        public async Task<List<OffersResponse>> GetAsync()
        {
            return await _context.TypOferty.Select(z => new OffersResponse
            {
                IdTypu = z.IdTypu,
                Opis = z.Opis,
                KategoriaOferty = z.KategoriaOferty.Where(p => p.IdTypu == z.IdTypu)
              .Select(p => new Responses.KategoriaOferty
              {
                  Nazwa = p.Nazwa,
                  Oferty = p.Oferty.Where(u => u.IdKategorii == p.IdKategorii)
                .Select(u => new Responses.Oferty
                {
                    OpisOferty = u.OpisOferty,
                    WymaganeOsiągnięcia = u.WymaganeOsiągnięcia.Where(j => j.IdKwalifikacji == u.IdKategorii)
                    .Select(j => new Responses.WymaganeOsiągnięcia
                    {
                        IdKwalifikacji = j.IdKwalifikacji,
                        Opis = j.IdKwalifikacjiNavigation.Opis
                    }).ToList()
                }).ToList()
              }).ToList()
            }).ToListAsync();
        }

        public async Task<List<OffersResponse>> GetAsync(int id)
        {
            return await _context.TypOferty.Where(z=>z.IdTypu == id).Select(z => new OffersResponse
            {
                IdTypu = z.IdTypu,
                Opis = z.Opis,
                KategoriaOferty = z.KategoriaOferty.Where(p => p.IdTypu == z.IdTypu)
              .Select(p => new Responses.KategoriaOferty
              {
                  Nazwa = p.Nazwa,
                  Oferty = p.Oferty.Where(u => u.IdKategorii == p.IdKategorii)
                .Select(u => new Responses.Oferty
                {
                    OpisOferty = u.OpisOferty,
                    WymaganeOsiągnięcia = u.WymaganeOsiągnięcia.Where(j => j.IdKwalifikacji == u.IdKategorii)
                    .Select(j => new Responses.WymaganeOsiągnięcia
                    {
                        IdKwalifikacji = j.IdKwalifikacji,
                        Opis = j.IdKwalifikacjiNavigation.Opis
                    }).ToList()
                }).ToList()
              }).ToList()
            }).ToListAsync();
        }
    }
}
