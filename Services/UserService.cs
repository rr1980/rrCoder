using Common;
using DB;
using Entities;
using Microsoft.AspNetCore.Http;
using Microsoft.Extensions.Options;
using Microsoft.IdentityModel.Tokens;
using Services.Interfaces;
using System;
using System.Collections.Generic;
using System.IdentityModel.Tokens.Jwt;
using System.Linq;
using System.Security.Claims;
using System.Text;
using System.Threading.Tasks;

namespace Services
{
    public class UserService : IUserService
    {
        private IHttpContextAccessor _httpContextAccessor;
        private readonly IRepository _repository;
        private readonly AppSettings _appSettings;

        public UserService(IOptions<AppSettings> appSettings, IRepository repository, IHttpContextAccessor httpContextAccessor)
        {
            _appSettings = appSettings.Value;
            _repository = repository;
            _httpContextAccessor = httpContextAccessor;
        }

        public Benutzer Authenticate(string username, string password)
        {
            var user = _repository.GetAll<Benutzer>().SingleOrDefault(x => x.Username == username && x.Password == password);

            // return null if user not found
            if (user == null)
                return null;

            // authentication successful so generate jwt token
            var tokenHandler = new JwtSecurityTokenHandler();
            var key = Encoding.ASCII.GetBytes(_appSettings.Secret);
            var tokenDescriptor = new SecurityTokenDescriptor
            {
                Audience = "http://localhost:5000",
                Issuer = "http://localhost:5000",
                Subject = new ClaimsIdentity(new Claim[]
                {
                    new Claim(ClaimTypes.Name, user.Id.ToString()),
                    new Claim(ClaimTypes.Role, user.Role)
                }),
                Expires = DateTime.Now.AddHours(2),
                SigningCredentials = new SigningCredentials(new SymmetricSecurityKey(key), SecurityAlgorithms.HmacSha256Signature)
            };
            var token = tokenHandler.CreateToken(tokenDescriptor);
            user.Token = tokenHandler.WriteToken(token);

            // remove password before returning
            user.Password = null;

            return user;
        }

        public IEnumerable<Bemerkung> GetAllBemerkungen()
        {
            return _repository.GetAll<Bemerkung>();
        }

        public IEnumerable<Benutzer> GetAll()
        {
            var users = _repository.GetAll<Benutzer>();

            foreach (var item in users)
            {
                item.Password = null;
            }

            return users;
        }

        public async Task<Benutzer> GetById(int id)
        {
            var user = await _repository.GetById<Benutzer>(id);

            if (user != null)
                user.Password = null;

            return user;
        }

        public async Task Add()
        {
            Benutzer user = null;
            var _uId = _httpContextAccessor.HttpContext.User.FindFirst(ClaimTypes.Name).Value;
            if (!string.IsNullOrEmpty(_uId))
            {
                var uId = long.Parse(_uId);
                user = await _repository.GetById<Benutzer>(uId);
            }


            var cc = _repository.GetAll<CodeContent>().FirstOrDefault();

            cc.Bemerkungen.Add(new Bemerkung
            {
                Betreff = DateTime.Now.ToString(),
                Text = "Test",
                User = user
            });

            await _repository.Update(cc);
        }
    }
}
