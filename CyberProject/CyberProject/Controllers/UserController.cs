using CyberProject.Dtos;
using CyberProject.Entities;
using CyberProject.Enums;
using CyberProject.Interfaces;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.Extensions.Configuration;
using Microsoft.IdentityModel.Tokens;
using System;
using System.Collections.Generic;
using System.IdentityModel.Tokens.Jwt;
using System.Linq;
using System.Security.Claims;
using System.Text;
using System.Threading.Tasks;

namespace CyberProject.Controllers
{
    public class UserController : BaseController
    {
        private IAccount _account;
        private IFaculty _faculty;
        private IDepartment _department;
        private IUser _userService;
        private IConfiguration _config;

        public UserController(IUser userService, IConfiguration config, IAccount account, IFaculty faculty, IDepartment department)
        {
            _account = account;
            _userService = userService;
            _config = config;
            _faculty = faculty;
            _department = department;
        }

        [HttpPost]
        public async Task<IActionResult> Register([FromBody] UserDto registerUser)
        {
            ApplicationUser user = new ApplicationUser();

            user.FirstName = registerUser.FirstName;
            user.LastName = registerUser.LastName;
            user.UserName = registerUser.Username;
            user.Email = registerUser.Email;
            user.PhoneNumber = registerUser.PhoneNo;

            var newUser = await _account.CreateUser(user, registerUser.Password);
            if (newUser)
                return RedirectToAction("Index");

            return View();
        }

        [HttpPost("authenticate")]
        public IActionResult Authenticate([FromBody] LoginDto userDto)
        {
            var user = _userService.Authenticate(userDto.Username, userDto.Password);

            if (user == null)
                return BadRequest(new { message = "Username or password is incorrect" });



            var tokenHandler = new JwtSecurityTokenHandler();
            var key = Encoding.ASCII.GetBytes(_config.GetSection("AppSettings:Secret").Value);

            var tokenDescriptor = new SecurityTokenDescriptor
            {
                Subject = new ClaimsIdentity(new Claim[]
                {
                    new Claim(ClaimTypes.NameIdentifier, user.Id.ToString()),
                    new Claim(ClaimTypes.Name, user.Username),
                    new Claim(ClaimTypes.GivenName, user.FirstName + " " + user.LastName),
                }),
                Expires = DateTime.UtcNow.AddDays(7),
                SigningCredentials = new SigningCredentials(new SymmetricSecurityKey(key), SecurityAlgorithms.HmacSha256Signature)
            };
            //var claims = new List<Claim>
            //        {
            //        new Claim(JwtRegisteredClaimNames.Sub, user.Username),
            //        new Claim(ClaimTypes.NameIdentifier, user.Id.ToString()),
            //        new Claim(JwtRegisteredClaimNames.Jti, Guid.NewGuid().ToString())
            //        };

            //var tokenDescriptor = new JwtSecurityToken(
            //        issuer: "http://cyberinterns.slack.com",
            //        audience: "http://api.cyberinterns.com",
            //        expires: DateTime.UtcNow.AddDays(7),
            //        cliams: claims,
            //        signingCredentials: new SigningCredentials(new SymmetricSecurityKey(key), SecurityAlgorithms.HmacSha256)
            //        );






            var token = tokenHandler.CreateToken(tokenDescriptor);

            var Expires = tokenDescriptor.Expires.ToString();





            // return basic user info (without password) and token to store client side
            return Ok(new
            {
                Id = user.Id,
                Username = user.Username,
                FirstName = user.FirstName,
                LastName = user.LastName,
                Email = user.Email,
                access_token = tokenHandler.WriteToken(token),
                expires = Expires
            });
        }

        [HttpGet]
        public async Task<IActionResult> Create()
        {
            var fac = await _faculty.GetAll();
            var dept = await _department.GetAll();
            var facList = fac.Select(f => new SelectListItem()
            {
                Value = f.facultyID.ToString(),
                Text = f.facultyName
            });
            var deptList = dept.Select(d => new SelectListItem()
            {
                Value = d.deptID.ToString(),
                Text = d.deptName
            });
            ViewBag.fac = facList;
            ViewBag.dept = deptList;
            return View();
        }

        [HttpPost]
        public async Task<IActionResult> Create(User user)
        {
            var createUser = await _userService.AddAsync(user);

            if (createUser)
            {
                Alert("User created successfully.", NotificationType.success);
                return RedirectToAction("Index");
            }
            else
            {
                Alert("User not created!", NotificationType.error);
            }


            return View();
        }

        [HttpGet]
        public async Task<IActionResult> ListUsers()
        {
            var model = await _userService.GetAll();

            if (model != null)
                return View(model);
            return View();
        }

        
    }
}
