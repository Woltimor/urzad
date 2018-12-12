using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Urzad.Data.Models;

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
        public async Task InsertAsync(KategoriaOferty kat)
        {
            _context.KategoriaOferty.Add(kat);
            await _context.SaveChangesAsync();
        }

        public async Task InsertAsync(Oferty oferty)
        {
           _context.Oferty.Add(oferty);
            await _context.SaveChangesAsync();

        }
        public async Task InsertAsync(Kwalifikacje kwalifikacje)
        {
            _context.Kwalifikacje.Add(kwalifikacje);
            await _context.SaveChangesAsync();

        }
    }
}
