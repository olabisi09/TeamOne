﻿using CyberProject.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace CyberProject.Interfaces
{
    public interface IUser
    {
        User Authenticate(string username, string password);
        Task<IEnumerable<User>> GetAll();
        Task<User> GetById(int id);
        User Create(User user, string password);
        Task<bool> Update(User user, string password = null);
        Task<bool> Delete(int Id);
    }
}
