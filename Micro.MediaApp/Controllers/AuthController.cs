using Micro.Business.Concrates;
using Micro.Dal.Concrates.EF;
using Micro.Dal.Concrates.Repo;
using Micro.Model;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Microsoft.IdentityModel.Tokens;
using System.IdentityModel.Tokens.Jwt;
using System.Security.Claims;
using System.Text;

namespace Micro.MediaApp.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class AuthController : ControllerBase
    {
        IConfiguration configuration;
        MicroMediaContext _MicroMediaContext;
        public AuthController(IConfiguration configuration,MicroMediaContext MicroMediaContext)
        {
            this._MicroMediaContext = MicroMediaContext;
            this.configuration = configuration;
        }

        [HttpPost]
        [AllowAnonymous]
        public IActionResult Auth([FromBody] User user)
        {
            IActionResult response = Unauthorized();
            if (user != null)
            {
                UserManager userManager = new UserManager(new UserRepository(_MicroMediaContext));
                User _user = userManager.Find(x=>x.UserName == "test" && x.Password == "test").FirstOrDefault();

                if (user.UserName == "test" && user.Password == "test")
                {
                    var issuer = configuration["Jwt:Issuer"];
                    var audience = configuration["Jwt:Audience"];
                    var key = Encoding.UTF8.GetBytes(configuration["Jwt:Key"]);
                    var signingCredentials = new SigningCredentials(
                                            new SymmetricSecurityKey(key),
                                            SecurityAlgorithms.HmacSha512Signature
                                        );

                    var subject = new ClaimsIdentity(new[]
                    {
                    new Claim(JwtRegisteredClaimNames.Sub, user.UserName),
                    new Claim(JwtRegisteredClaimNames.Email, user.UserName),
                    });

                    var expires = DateTime.UtcNow.AddMinutes(10);

                    var tokenDescriptor = new SecurityTokenDescriptor
                    {
                        Subject = subject,
                        Expires = DateTime.UtcNow.AddMinutes(10),
                        Issuer = issuer,
                        Audience = audience,
                        SigningCredentials = signingCredentials
                    };
                    var tokenHandler = new JwtSecurityTokenHandler();
                    var token = tokenHandler.CreateToken(tokenDescriptor);
                    var jwtToken = tokenHandler.WriteToken(token);

                    return Ok(jwtToken);
                }
            }
            return response;
        }


    }
}
