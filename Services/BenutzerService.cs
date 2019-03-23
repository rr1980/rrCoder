using AutoMapper;
using Common;
using DB;
using Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Options;
using Microsoft.IdentityModel.Tokens;
using Services.Interfaces;
using System;
using System.Collections.Generic;
using System.IdentityModel.Tokens.Jwt;
using System.Security.Claims;
using System.Text;
using System.Threading.Tasks;
using VievModels;

namespace Services
{
    public class BenutzerService : IBenutzerService
    {
        private readonly IRepository _repository;
        private readonly AppSettings _appSettings;
        private readonly IMapper _mapper;

        public BenutzerService(IOptions<AppSettings> appSettings, IRepository repository, IMapper mapper)
        {
            _appSettings = appSettings.Value;
            _repository = repository;
            _mapper = mapper;
        }

        public async Task<BenutzerVievmodel> Authenticate(string username, string password)
        {
            var benutzer = await _repository.GetAll<Benutzer>().FirstOrDefaultAsync(x => x.Username == username && x.Password == password);

            if (benutzer == null)
                return null;

            var tokenHandler = new JwtSecurityTokenHandler();
            var key = Encoding.ASCII.GetBytes(_appSettings.Secret);
            var tokenDescriptor = new SecurityTokenDescriptor
            {
                Audience = "http://localhost:5000",
                Issuer = "http://localhost:5000",
                Subject = new ClaimsIdentity(new Claim[]
                {
                    new Claim(ClaimTypes.Name, benutzer.Id.ToString()),
                    new Claim(ClaimTypes.Role, benutzer.Role)
                }),
                Expires = DateTime.Now.AddHours(2),
                SigningCredentials = new SigningCredentials(new SymmetricSecurityKey(key), SecurityAlgorithms.HmacSha256Signature)
            };
            var token = tokenHandler.CreateToken(tokenDescriptor);
            benutzer.Token = tokenHandler.WriteToken(token);

            benutzer.Password = null;

            return _mapper.Map<BenutzerVievmodel>(benutzer);
        }

        public async Task<List<BenutzerVievmodel>> GetAll()
        {
            var results = await _repository.GetAll<Benutzer>().ToListAsync();

            foreach (var item in results)
            {
                item.Password = null;
            }

            return _mapper.Map<List<BenutzerVievmodel>>(results);
        }

        public async Task<BenutzerVievmodel> GetById(int id)
        {
            var benutzer = await _repository.GetById<Benutzer>(id);

            if (benutzer != null)
                benutzer.Password = null;

            return _mapper.Map<BenutzerVievmodel>(benutzer);
        }
    }
}
