using CyberProject.Dtos;
using CyberProject.Entities;
using CyberProject.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace CyberProject.Interfaces
{
    public interface IAccount
    {
        Task<bool> CreateUser(ApplicationUser user, string password);

        IEnumerable<ApplicationUser> GetAll();

        Task<SignInModel> SignIn(LoginDto loginDetails);

        Task<bool> Login(LoginViewModel loginModel);

        Task<bool> UpdateUser(ApplicationUser userprofile);
    }
}
