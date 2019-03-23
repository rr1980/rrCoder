using AutoMapper;
using Common;
using DB;
using Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Options;
using Services.Interfaces;
using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using VievModels;

namespace Services
{
    public class CodeContentService : ICodeContentService
    {
        private readonly IRepository _repository;
        private readonly AppSettings _appSettings;
        private readonly IMapper _mapper;

        public CodeContentService(IOptions<AppSettings> appSettings, IRepository repository, IMapper mapper)
        {
            _appSettings = appSettings.Value;
            _repository = repository;
            _mapper = mapper;
        }

        public async Task Add()
        {

            await _repository.Create(new CodeContent
            {
                Betreff = DateTime.Now.ToString(),
                Text = "Test",
            });
        }

        public async Task<List<CodeContentVievmodel>> GetAllCodeContent()
        {
            var results = await _repository.GetAll<CodeContent>().ToListAsync();

            return _mapper.Map<List<CodeContentVievmodel>>(results);
        }
    }
}
