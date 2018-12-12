using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Urzad.Data.Models;
using Urzad.Responses;

namespace Urzad.Repository
{
    public class PersonalAtributesRep : IPersonalAtributesRep
    {
        private readonly UrzadPracyContext _context;
        public PersonalAtributesRep(UrzadPracyContext context)
        {
            _context = context;
        }
        public async Task<List<PersonalAtributesResponse>> GetAsync()
        {
            return await _context.Osoba.Select(o => new PersonalAtributesResponse
            {

                IdOsoby = o.IdOsoby,
                Imie = o.Imie,
                Nazwisko = o.Nazwisko,
                Pesel = o.Pesel,
                Wykształcenie = o.Wykształcenie,
                Email = o.Email,
                PosiadaneKwalifikacjes = o.PosiadaneKwalifikacje.Where(k => k.IdOsoby == o.IdOsoby)
                    .Select(q => new PosiadaneKwalifikacjes
                    {
                        Opis = q.IdKwalifikacjiNavigation.Opis
                    }).ToList(),
                    Wniosek = o.Wniosek.Where(w=>w.IdOsoby==o.IdOsoby)
                   .Select(w=> new Responses.Wniosek
                {
                    IdKategorii = w.IdKategorii,
                    Nazwa = w.IdKategoriiNavigation.Nazwa
                }).ToList()
            }).ToListAsync();


        }

        public async Task<PersonalAtributesResponse> GetAsync(int id)
        {

            return await _context.Osoba.Where(p => p.IdOsoby == id)
                .Select(o => new PersonalAtributesResponse
                {
                    IdOsoby = o.IdOsoby,
                    Imie = o.Imie,
                    Nazwisko = o.Nazwisko,
                    Pesel = o.Pesel,
                    Wykształcenie = o.Wykształcenie,
                    Email = o.Email,

                    PosiadaneKwalifikacjes = o.PosiadaneKwalifikacje.Where(k => k.IdOsoby == o.IdOsoby)
                    .Select(q => new PosiadaneKwalifikacjes
                    {
                        IdKwalifikacji = q.IdKwalifikacjiNavigation.IdKwalifikacji,
                        Opis = q.IdKwalifikacjiNavigation.Opis
                    }).ToList(),
                    Wniosek = o.Wniosek.Where(w => w.IdOsoby == o.IdOsoby)
                   .Select(w => new Responses.Wniosek
                   {
                       IdKategorii = w.IdKategorii,
                       Nazwa = w.IdKategoriiNavigation.Nazwa
                   }).ToList()

                })
                .SingleOrDefaultAsync();
        }
        public void Insert(Osoba osoba)
        {
            _context.Osoba.Add(osoba);
            _context.SaveChanges();
        }
        public async Task Update(Osoba osoba)
        {
            var res = await _context.Osoba.Where(l => l.IdOsoby == osoba.IdOsoby).SingleOrDefaultAsync();
            res.Imie = osoba.Imie;
            res.Nazwisko = osoba.Nazwisko;

            _context.Entry(res).State = EntityState.Modified;
            try
            {
                await _context.SaveChangesAsync();
            }
            catch (Exception)
            {

                throw;
            }
        }
        public async Task Delete(int id)
        {
            var res = await _context.Osoba.Where(l => l.IdOsoby == id).SingleOrDefaultAsync();
            if (res == null) throw new NullReferenceException();


            _context.Remove(res);

            await _context.SaveChangesAsync();
        }
    }
}
