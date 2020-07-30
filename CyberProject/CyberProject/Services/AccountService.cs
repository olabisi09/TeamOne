using CyberProject.Dtos;
using CyberProject.Entities;
using CyberProject.Interfaces;
using CyberProject.Models;
using Microsoft.AspNetCore.Identity;
using Microsoft.Extensions.Configuration;
using Microsoft.IdentityModel.Tokens;
using System;
using System.Collections.Generic;
using System.IdentityModel.Tokens.Jwt;
using System.Linq;
using System.Security.Claims;
using System.Text;
using System.Threading.Tasks;

namespace CyberProject.Services
{
    public class AccountService : IAccount
    {
        private readonly SignInManager<ApplicationUser> _signInManager;
        private readonly UserManager<ApplicationUser> _userManager;
        //private readonly UserManager<SignUpViewModel> _userSignUp;
        private readonly RoleManager<ApplicationRole> _roleManager;

        private IConfiguration _config;
        public AccountService(SignInManager<ApplicationUser> signInManager,
                                UserManager<ApplicationUser> userManager,
                                RoleManager<ApplicationRole> roleManager,
                                 IConfiguration config)
        {
            _signInManager = signInManager;
            _userManager = userManager;
            _roleManager = roleManager;
            _config = config;
        }

        public async Task<bool> CreateUser(ApplicationUser user, string password)
        {
            try
            {
                var checkUser = await _userManager.FindByEmailAsync(user.Email);
                if (checkUser == null)
                {

                    var userResult = await _userManager.CreateAsync(user, password);
                    if (userResult.Succeeded)
                        await _userManager.AddToRoleAsync(user, "User");
                        return true;
                }
                return false;
            }
            catch (Exception ex)
            {
                return false;
            }
        }

        public async Task<SignInModel> SignIn(LoginDto loginDetails)
        {
            SignInModel signInDetails = new SignInModel();
            try
            {
                // check if user exist
                var checkUser = await _userManager.FindByNameAsync(loginDetails.Username);

                if (checkUser != null)
                {
                    //signin user
                    var signInResult = await _signInManager.PasswordSignInAsync(checkUser, loginDetails.Password, false, false);
                    // check if signin is successful
                    if (signInResult.Succeeded)
                    {
                        var tokenHandler = new JwtSecurityTokenHandler();
                        var key = Encoding.ASCII.GetBytes(_config.GetSection("AppSettings:Secret").Value);

                        var tokenDescriptor = new SecurityTokenDescriptor
                        {
                            Subject = new ClaimsIdentity(new Claim[]
                            {
                            new Claim(ClaimTypes.NameIdentifier, checkUser.Id.ToString()),
                            new Claim(ClaimTypes.Name, checkUser.UserName),
                            new Claim(ClaimTypes.Email , checkUser.Email),
                            new Claim(ClaimTypes.GivenName, checkUser.FirstName + checkUser.LastName),
                            }),
                            Expires = DateTime.UtcNow.AddDays(7),
                            SigningCredentials = new SigningCredentials(new SymmetricSecurityKey(key), SecurityAlgorithms.HmacSha256Signature)
                        };

                        var token = tokenHandler.CreateToken(tokenDescriptor);

                        var Expires = tokenDescriptor.Expires.ToString();

                        signInDetails.Email = checkUser.Email;
                        signInDetails.FirstName = checkUser.FirstName;
                        signInDetails.LastName = checkUser.LastName;
                        signInDetails.Username = checkUser.UserName;
                        signInDetails.Token = tokenHandler.WriteToken(token);
                        signInDetails.Expires = Expires;


                    }

                }
                return signInDetails;
            }
            catch (Exception ex)
            {
                return signInDetails;
            }
        }
        public async Task<bool> Login(LoginViewModel loginDetails)
        {

            try
            {
                // check if user exist
                var checkUser = await _userManager.FindByEmailAsync(loginDetails.Email);
                if (checkUser != null)
                {
                    //signin user
                    var signInResult = await _signInManager.PasswordSignInAsync(checkUser, loginDetails.Password, false, false);
                    // check if signin is successful
                    if (signInResult.Succeeded)
                    {
                        return true;
                    }
                }
                return false;
            }
            catch (Exception ex)
            {
                return false;
            }
        }

        public async Task<IEnumerable<ApplicationUser>> GetAll()
        {
            return await _userManager.GetUsersInRoleAsync("User");
        }
    }
}
