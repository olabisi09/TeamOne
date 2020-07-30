using CyberProject.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace CyberProject.Interfaces
{
    public interface IUser
    {
        Task<IEnumerable<User>> GetAll();
        Task<User> GetById(int id);
        Task<bool> Update(User user);
        Task<bool> Delete(int Id);
        void Add(User user);
        Task<bool> AddAsync(User user);
    }
}
