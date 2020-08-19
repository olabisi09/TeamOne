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



        public async Task<IEnumerable<User>> GetAll()
        {
            return await _context.WebUsers.Include(d => d.Department).Include(g => g.Grade).Include(s => s.ApplicationUser).ToListAsync();
        }

        public async Task<User> GetById(int Id)
        {
            await _context.WebUsers.Include(d => d.Department).Include(g => g.Grade).Include(s => s.ApplicationUser).ToListAsync();
            var user = await _context.WebUsers.FindAsync(Id);

            return user;
        }

 
        public async Task<bool> Update(User user)
        {
            var us = await _context.WebUsers.FindAsync(user.Id);
            if (us != null)
            {
                us.FirstName = user.FirstName;
                us.LastName = user.LastName;
                us.DepartmentID = user.DepartmentID;
                us.gradeID = user.gradeID;

                await _context.SaveChangesAsync();
                return true;
            }

            return false;
        }

        public void Add(User user)
        {
            _context.Add(user);
            _context.SaveChanges();
        }

        public async Task<bool> AddAsync(User user)
        {
            try
            {
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
