using Microsoft.AspNetCore.Mvc;
using System.Threading.Tasks;
using LoanManagementSystem.Models;
using LoanManagementSystem.Repository;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Configuration;
using Microsoft.IdentityModel.Tokens;
using System;
using System.IdentityModel.Tokens.Jwt;
using System.Text;


namespace LMS_Api.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class LoginsController : ControllerBase
    {
        private readonly ILoginRepository _loginRepository;
        private readonly IConfiguration _config;

        public LoginsController(IConfiguration config, ILoginRepository loginRepository)
        {
            _config = config;
            _loginRepository = loginRepository;
        }

        [HttpGet("{username}/{password}")]
        public async Task<IActionResult> Users(string username, string password)
        {
            IActionResult response = Unauthorized();
            User user = await _loginRepository.ValidateUser(username, password);

            if (user != null)
            {
                var tokenString = GenerateJWTToken(user);
                response = Ok(new
                {
                    uName = user.Username,
                    roleId = user.RoleId,
                    userId = user.UserId,
                    token = tokenString
                });
            }
            return response;
        }

        private object GenerateJWTToken(User user)
        {
            var securityKey = new SymmetricSecurityKey(Encoding.UTF8.GetBytes(_config["Jwt:Key"]));
            var credentials = new SigningCredentials(securityKey, SecurityAlgorithms.HmacSha256);

            var token = new JwtSecurityToken(
                _config["Jwt:Issuer"],
                _config["Jwt:Issuer"],
                null,
                expires: DateTime.Now.AddMinutes(20),
                signingCredentials: credentials
            );

            return new JwtSecurityTokenHandler().WriteToken(token);
        }
    }
}