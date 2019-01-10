using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Urzad.Data.Models;
using Urzad.Helpers;

namespace Urzad.Services
{
    public class UserServ : IUserServ
    {
        private UrzadPracyContext _context;

        public UserServ(UrzadPracyContext context)
        {
            _context = context;
        }
        public Osoba Authenticate(string login, string haslo)
        {
            if (string.IsNullOrEmpty(login) || string.IsNullOrEmpty(haslo))
                return null;

            var user = _context.Osoba.SingleOrDefault(x => x.Login == login);

            // check if username exists
            if (user == null)
                return null;

            // check if password is correct
            if (!VerifyPasswordHash(haslo, user.HasłoHash, user.HasłoSalt))
                return null;

           // if (user.Dostep == 0)
            //    return null;

            // authentication successful
            return user;
        }

        public Osoba Create(Osoba osoba, string haslo)
        {
            // validation
            if (string.IsNullOrWhiteSpace(haslo))
                throw new AppException("Hasło jest wymagane");

            if (_context.Osoba.Any(x => x.Login == osoba.Login))
                throw new AppException("Login \"" + osoba.Login + "\" jest zajęty");

            byte[] passwordHash, passwordSalt;
            CreatePasswordHash(haslo, out passwordHash, out passwordSalt);

            osoba.HasłoHash = passwordHash;
            osoba.HasłoSalt = passwordSalt;
            osoba.DataRejestracji = System.DateTime.Now;
            osoba.DataKońcowa = System.DateTime.Now.AddMonths(6);
            osoba.Dostep = 0;

            _context.Osoba.Add(osoba);
            _context.SaveChanges();

            return osoba;
        }

        public void Delete(int id)
        {
            var user = _context.Osoba.Find(id);
            if (user != null)
            {
                _context.Osoba.Remove(user);
                _context.SaveChanges();
            }
        }

        public IEnumerable<Osoba> GetAll()
        {
            return _context.Osoba;
        }

        public Osoba GetById(int id)
        {
            return _context.Osoba.Find(id);
        }

        public void Update(Osoba osobaParam, string haslo = null)
        {
            var user = _context.Osoba.Find(osobaParam.IdOsoby);

            if (user == null)
                throw new AppException("User not found");

            if (osobaParam.Login != user.Login)
            {
                // username has changed so check if the new username is already taken
                if (_context.Osoba.Any(x => x.Login == osobaParam.Login))
                    throw new AppException("Login " + osobaParam.Login + " jest zajęty");
            }

            // update user properties
            user.Imie = osobaParam.Imie;
            user.Nazwisko = osobaParam.Nazwisko;
            user.Login = osobaParam.Login;
            user.DataUrodzenia = osobaParam.DataUrodzenia;
            user.Email = osobaParam.Email;
            user.Pesel = osobaParam.Pesel;
            user.Wyksztalcenie = osobaParam.Wyksztalcenie;
            user.Plec = osobaParam.Plec;
            user.Dostep = osobaParam.Dostep;

            // update password if it was entered
            if (!string.IsNullOrWhiteSpace(haslo))
            {
                byte[] passwordHash, passwordSalt;
                CreatePasswordHash(haslo, out passwordHash, out passwordSalt);

                user.HasłoHash = passwordHash;
                user.HasłoSalt = passwordSalt;
            }

            _context.Osoba.Update(user);
            _context.SaveChanges();
        }
        private static void CreatePasswordHash(string password, out byte[] passwordHash, out byte[] passwordSalt)
        {
            if (password == null) throw new ArgumentNullException("hasło");
            if (string.IsNullOrWhiteSpace(password)) throw new ArgumentException("Nie może być puste.", "hasło");

            using (var hmac = new System.Security.Cryptography.HMACSHA512())
            {
                passwordSalt = hmac.Key;
                passwordHash = hmac.ComputeHash(System.Text.Encoding.UTF8.GetBytes(password));
            }
        }

        private static bool VerifyPasswordHash(string password, byte[] storedHash, byte[] storedSalt)
        {
            if (password == null) throw new ArgumentNullException("password");
            if (string.IsNullOrWhiteSpace(password)) throw new ArgumentException("Value cannot be empty or whitespace only string.", "password");
            if (storedHash.Length != 64) throw new ArgumentException("Invalid length of password hash (64 bytes expected).", "passwordHash");
            if (storedSalt.Length != 128) throw new ArgumentException("Invalid length of password salt (128 bytes expected).", "passwordHash");

            using (var hmac = new System.Security.Cryptography.HMACSHA512(storedSalt))
            {
                var computedHash = hmac.ComputeHash(System.Text.Encoding.UTF8.GetBytes(password));
                for (int i = 0; i < computedHash.Length; i++)
                {
                    if (computedHash[i] != storedHash[i]) return false;
                }
            }

            return true;
        }

    }
}
