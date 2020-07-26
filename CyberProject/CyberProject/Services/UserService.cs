using CyberProject.Data;
using CyberProject.Entities;
using CyberProject.Interfaces;
using Microsoft.AspNetCore.Authorization;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace CyberProject.Services
{
    public class UserService : IUser
    {
        public CyberProjectDataContext _context;

        public UserService(CyberProjectDataContext context)
        {
            _context = context;
        }

        public User Authenticate(string username, string password)
        {
            if (string.IsNullOrEmpty(username) || string.IsNullOrEmpty(password))
                return null;

            var user = _context.WebUsers.SingleOrDefault(x => x.Username == username || x.Email == username);

            // check if username exists
            if (user == null)
                return null;

            // check if password is correct
            if (!VerifyPasswordHash(password, user.PasswordHash, user.PasswordSalt))
                return null;

            // authentication successful
            return user;
        }

        public async Task<IEnumerable<User>> GetAll()
        {
            return await _context.WebUsers.ToListAsync();
        }

        public async Task<User> GetById(int Id)
        {
            var user = await _context.WebUsers.FindAsync(Id);

            return user;
        }

        public async Task<bool> GetSalary(User user)
        {
            var us = await _context.WebUsers.FindAsync(user.Id);
            if (us != null)
            {
                if (us.Grade == "1")
                {
                    us.Salary = 50000; 
                    us.TaxOnSalary = 5;
                    us.NetSalary = us.Salary - ((us.TaxOnSalary / 100) * us.Salary);
                }
                if (us.Grade == "2")
                {
                    us.Salary = 100000;
                    us.TaxOnSalary = 10;
                    us.NetSalary = us.Salary - ((us.TaxOnSalary / 100) * us.Salary);
                }
                if (us.Grade == "3")
                {
                    us.Salary = 150000;
                    us.TaxOnSalary = 5;
                    us.NetSalary = us.Salary - ((us.TaxOnSalary / 100) * us.Salary);
                }
                await _context.SaveChangesAsync();
                return true;
            }

            return false;
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

        private static void CreatePasswordHash(string password, out byte[] passwordHash, out byte[] passwordSalt)
        {
            //if (password == null) throw new ArgumentNullException("password");
            if (string.IsNullOrWhiteSpace(password)) throw new ArgumentException("Value cannot be empty or whitespace only string.", "password");

            using (var hmac = new System.Security.Cryptography.HMACSHA512())
            {
                passwordSalt = hmac.Key;
                passwordHash = hmac.ComputeHash(System.Text.Encoding.UTF8.GetBytes(password));
            }
        }

        public User Create(User user, string password)
        {
            if (string.IsNullOrWhiteSpace(password))
                throw new Exception("Password is required");

            if (_context.WebUsers.Any(x => x.Username == user.Username || x.Email == user.Email))
                throw new Exception("Username \"" + user.Username + "\" or Email \"" + user.Email + " is already taken");

            byte[] passwordHash, passwordSalt;
            CreatePasswordHash(password, out passwordHash, out passwordSalt);

            user.PasswordHash = passwordHash;
            user.PasswordSalt = passwordSalt;

            _context.WebUsers.Add(user);
            _context.SaveChanges();

            return user;
        }

        public async Task<bool> Update(User user)
        {
            var us = await _context.WebUsers.FindAsync(user.Id);
            if (us != null)
            {
                us.FirstName = user.FirstName;
                us.LastName = user.LastName;
                us.Username = user.Username;
                us.Email = user.Email;
                us.PhoneNo = user.PhoneNo;

                await _context.SaveChangesAsync();
                return true;
            }

            return false;
        }

        public async Task<bool> AddAsync(User user)
        {
            try
            {
                if (user.Grade == "1")
                {
                    user.Salary = 50000;
                    user.TaxOnSalary = 5;
                    user.NetSalary = user.Salary - ((user.TaxOnSalary / 100) * user.Salary);
                }
                if (user.Grade == "2")
                {
                    user.Salary = 100000;
                    user.TaxOnSalary = 10;
                    user.NetSalary = user.Salary - ((user.TaxOnSalary / 100) * user.Salary);
                }
                if (user.Grade == "3")
                {
                    user.Salary = 150000;
                    user.TaxOnSalary = 5;
                    user.NetSalary = user.Salary - ((user.TaxOnSalary / 100) * user.Salary);
                }
                await _context.AddAsync(user);
                await _context.SaveChangesAsync();
            }
            catch (Exception)
            {
                return false;
            }
            return true;
        }

        public async Task<bool> Delete(int Id)
        {
            var user = await _context.WebUsers.FindAsync(Id);

            if (user != null)
            {
                _context.WebUsers.Remove(user);
                _context.SaveChanges();
                return true;
            }

            return false;
        }
    }
}
