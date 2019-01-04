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
        private DataContext _context;

        public UserServ(DataContext context)
        {
            _context = context;
        }
        public Osoba Authenticate(string login, string haslo)
        {
            if (string.IsNullOrEmpty(login) || string.IsNullOrEmpty(haslo))
                return null;

            var user = _context.Osoby.SingleOrDefault(x => x.Login == login);

            // check if username exists
            if (user == null)
                return null;

            // check if password is correct
            if (!VerifyPasswordHash(haslo, user.HasłoHash, user.HasłoSalt))
                return null;

            // authentication successful
            return user;
        }

        public Osoba Create(Osoba osoba, string haslo)
        {
            // validation
            if (string.IsNullOrWhiteSpace(haslo))
                throw new AppException("Password is required");

            if (_context.Osoby.Any(x => x.Login == osoba.Login))
                throw new AppException("Username \"" + osoba.Login + "\" is already taken");

            byte[] passwordHash, passwordSalt;
            CreatePasswordHash(haslo, out passwordHash, out passwordSalt);

            osoba.HasłoHash = passwordHash;
            osoba.HasłoSalt = passwordSalt;

            _context.Osoby.Add(osoba);
            _context.SaveChanges();

            return osoba;
        }

        public void Delete(int id)
        {
            var user = _context.Osoby.Find(id);
            if (user != null)
            {
                _context.Osoby.Remove(user);
                _context.SaveChanges();
            }
        }

        public IEnumerable<Osoba> GetAll()
        {
            return _context.Osoby;
        }

        public Osoba GetById(int id)
        {
            return _context.Osoby.Find(id);
        }

        public void Update(Osoba osobaParam, string haslo = null)
        {
            var user = _context.Osoby.Find(osobaParam.IdOsoby);

            if (user == null)
                throw new AppException("User not found");

            if (osobaParam.Login != user.Login)
            {
                // username has changed so check if the new username is already taken
                if (_context.Osoby.Any(x => x.Login == osobaParam.Login))
                    throw new AppException("Username " + osobaParam.Login + " is already taken");
            }

            // update user properties
            user.Imie = osobaParam.Imie;
            user.Nazwisko = osobaParam.Nazwisko;
            user.Login = osobaParam.Login;

            // update password if it was entered
            if (!string.IsNullOrWhiteSpace(haslo))
            {
                byte[] passwordHash, passwordSalt;
                CreatePasswordHash(haslo, out passwordHash, out passwordSalt);

                user.HasłoHash = passwordHash;
                user.HasłoSalt = passwordSalt;
            }

            _context.Osoby.Update(user);
            _context.SaveChanges();
        }
        private static void CreatePasswordHash(string password, out byte[] passwordHash, out byte[] passwordSalt)
        {
            if (password == null) throw new ArgumentNullException("password");
            if (string.IsNullOrWhiteSpace(password)) throw new ArgumentException("Value cannot be empty or whitespace only string.", "password");

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
