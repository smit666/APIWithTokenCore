using Microsoft.AspNetCore.Mvc;
using Microsoft.IdentityModel.Tokens;
using System;
using System.Collections.Generic;
using System.IdentityModel.Tokens.Jwt;
using System.Linq;
using System.Security.Claims;
using System.Text;
using System.Threading.Tasks;

namespace APIWithToken.Controllers
{
    
    public class TokenController:Controller
    {
        private const string SECRET_KEY = "smitthakur666palghar";
        public static readonly SymmetricSecurityKey SIGNING_KEY = new
                      SymmetricSecurityKey(Encoding.UTF8.GetBytes(SECRET_KEY));


        [HttpGet]
        [Route("api/Token/{username}/{password}")]
    public IActionResult Get(string username, string password)
{
    if (username == password)
        return new ObjectResult(GenerateToken(username));
    else
        return BadRequest();
}


        // Generate a Token with expiration date and Claim meta-data.
        // And sign the token with the SIGNING_KEY
        private string GenerateToken(string username)
        {
            var token = new JwtSecurityToken(
                issuer: "Blinkingcaret",
                audience: "Everyone",
                claims: new Claim[] { new Claim(ClaimTypes.Name, username) },
                notBefore: DateTime.Now,
                expires: DateTime.Now.AddMinutes(5),
                signingCredentials: new SigningCredentials(SIGNING_KEY,
                                                    SecurityAlgorithms.HmacSha256)
       
                );
          //  var a = DateTime.Now;
            return new JwtSecurityTokenHandler().WriteToken(token);
        }
    }
}
