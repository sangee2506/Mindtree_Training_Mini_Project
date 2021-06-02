using FruitUserApi.Data;
using FruitUserApi.Models;
using IdentityService.custom_Exceptions;
using Microsoft.IdentityModel.Tokens;
using System;
using System.Collections.Generic;
using System.IdentityModel.Tokens.Jwt;
using System.Linq;
using System.Security.Claims;
using System.Text;
using System.Threading.Tasks;


namespace IdentityService.Repository
{
    public class SignInRepository 
    {
        private readonly FruitVendorContext db = null;
        public SignInRepository()
        {
            db = new FruitVendorContext();
        }

        public async Task<string> GenerateJwtTokenAsync(Person person)
        {
            var key = Encoding.ASCII.GetBytes(SiteKeys.Key);
            var JWToken = new JwtSecurityToken(
                 issuer: SiteKeys.WebSiteDomain,
                 audience: SiteKeys.WebSiteDomain,
                 claims: await GetUserClaims(person),
                 notBefore: new DateTimeOffset(DateTime.Now).DateTime,
                 expires: new DateTimeOffset(DateTime.Now.AddDays(1)).DateTime,
                 signingCredentials: new SigningCredentials(new SymmetricSecurityKey(key), SecurityAlgorithms.HmacSha256Signature)
        );

            var token = new JwtSecurityTokenHandler().WriteToken(JWToken);
            return token;
        }

        public async Task<IEnumerable<Claim>> GetUserClaims(Person person)
        {
            List<Claim> claims = new List<Claim>();
            Claim _claim;
            _claim = new Claim(ClaimTypes.Name, person.PersonName);
            claims.Add(_claim);

            _claim = new Claim(ClaimTypes.Role,person.Role);
            claims.Add(_claim);

            return claims.AsEnumerable<Claim>();
        }

        public async Task<Values> LoginUserAsync(Person model)
         {
          
            Person person = db.Persons.Where(x => x.PersonName == model.PersonName.Trim() && x.PersonPasswd == model.PersonPasswd.Trim()).SingleOrDefault();
            if (person == null)
            {
                throw new UserNotFoundException("UserName or Password is incorrect");
            }
            var tokenstring = await GenerateJwtTokenAsync(person);
            Values obj = new Values()
            {
                Person = person,
                Token = tokenstring

            };
            return obj;
        }
    }
}
