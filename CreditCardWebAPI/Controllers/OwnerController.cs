using CreditCardManagement.Models;
using CreditCardWebAPI.DTO;
using CreditCardWebAPI.Interface;
using Microsoft.AspNetCore.Cors;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Microsoft.IdentityModel.Tokens;
using System.IdentityModel.Tokens.Jwt;
using System.Security.Claims;
using System.Text;

namespace CreditCardWebAPI.Controllers
{
    [EnableCors("AllowAngularOrigins")]
    [Route("api/[controller]")]
    [ApiController]
    public class OwnerController : ControllerBase
    {
        private readonly IOwnerReg _Iowner;
        public IConfiguration _configuration;
        public OwnerController(IOwnerReg Iowner, IConfiguration configuration)
        {
            _Iowner = Iowner;
            _configuration = configuration;
        }

        [HttpPost]
        public async Task<ActionResult<OwnerDTO>> AddOwner(OwnerDTO owner)
        {
            //owner.hashId = Guid.NewGuid();
            _Iowner.AddOwner(owner);
            //return Ok(emp);
            return await Task.FromResult(owner);
        }

        [HttpPost]
        [Route("Login")]

        public async Task<IActionResult> Post(ownerLogin _userData)
        {
            if (_userData != null && _userData.email != null && _userData.password != null)
            {
                var user = _Iowner.GetUser(_userData.email, _userData.password);
                return Ok(user);
                if (user != null)
                {
                    //create claims details based on the user information
                    var claims = new[] {
                        new Claim(JwtRegisteredClaimNames.Sub, _configuration["Jwt:Subject"]),
                        new Claim(JwtRegisteredClaimNames.Jti, Guid.NewGuid().ToString()),
                        new Claim(JwtRegisteredClaimNames.Iat, DateTime.UtcNow.ToString()),
                        new Claim("UserId", user.id.ToString()),
                        new Claim("BusinessName", user.businessName),
                        new Claim("UserName", user.ownerName),
                        new Claim("Email", user.email)
                    };

                    var key = new SymmetricSecurityKey(Encoding.UTF8.GetBytes(_configuration["Jwt:key"]));
                    var signIn = new SigningCredentials(key, SecurityAlgorithms.HmacSha256);
                    var token = new JwtSecurityToken(
                        _configuration["Jwt:Issuer"],
                        _configuration["Jwt:Audience"],
                        claims,
                        expires: DateTime.UtcNow.AddMinutes(10),
                        signingCredentials: signIn);
                
                    return Ok(new JwtSecurityTokenHandler().WriteToken(token));
                }
                else
                {
                    return BadRequest("Invalid credentials");
                }
            }
            else
            {
                return BadRequest();
            }
        }

        //private async Task<OwnerRegisteration> GetUser(string email, string password)
        //{
        //    return await _context.UserInfos.FirstOrDefaultAsync(u => u.Email == email && u.Password == password);
        //}
    }
}
