using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.IdentityModel.Tokens;
using System.IdentityModel.Tokens.Jwt;
using System.Security.Claims;
using System.Text;
using user_service.Models;
using user_service.Dto;
namespace user_service.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class LoginController : ControllerBase
    {
        public IConfiguration _configuration;
        public readonly T2004_Group_1Context _context;
        public LoginController(IConfiguration configuration, T2004_Group_1Context context)
        {
            _configuration = configuration;
            _context = context;

        }  
        [HttpPost]
        public async Task<IActionResult> Post(AppUserDto _user)
        {
            if(_user != null && _user.Username != null && _user.Password != null)
            {
                // return token in login success
                var user = await _context.AppUsers.FirstOrDefaultAsync(u => u.Username == _user.Username && u.Password == _user.Password);
                if(user != null)
                {
                    // set token
                 
                       var claims = new[] {
                        new Claim(JwtRegisteredClaimNames.Sub,_configuration["Jwt:Subject"]),
                        new Claim(JwtRegisteredClaimNames.Jti,Guid.NewGuid().ToString()),
                        new Claim(JwtRegisteredClaimNames.Iat,DateTime.Now.ToString()),
                        new Claim("Id",user.Id.ToString()),
                        new Claim("Username",user.Username),
                        new Claim("Email",user.Username),
                           };
                    var key = new SymmetricSecurityKey(Encoding.UTF8.GetBytes(_configuration["Jwt:Key"]));
                    var sign = new SigningCredentials(key, SecurityAlgorithms.HmacSha256);
                    var token = new JwtSecurityToken(_configuration["Jwt:Issuer"], _configuration["Jwt:Audience"], claims, expires: DateTime.UtcNow.AddDays(1), signingCredentials: sign);
                    // return token
                    System.Diagnostics.Debug.WriteLine("token"+ token);
                    return Ok(new JwtSecurityTokenHandler().WriteToken(token));
                }
                else
                {
                    return BadRequest("Email hoặc mật khẩu không đúng");
                }
            }
            return BadRequest("Tài khoản không tồn tại");
        }
            
                 
     }
}
