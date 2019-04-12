using AutoMapper;
using Common;
using DB;
using Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Options;
using Services.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using VievModels;

namespace Services
{
    public class CodeViewerService : ICodeViewerService
    {
        private readonly IRepository _repository;
        private readonly AppSettings _appSettings;
        private readonly IMapper _mapper;

        public CodeViewerService(IOptions<AppSettings> appSettings, IRepository repository, IMapper mapper)
        {
            _appSettings = appSettings.Value;
            _repository = repository;
            _mapper = mapper;
        }

        public async Task<IEnumerable<CodeSnippetVievmodel>> Search(CodeViewerSearchRequest request)
        {
            var searchValues = request.SearchValue.Split(' ').Select(x => x.ToLower().Trim());

            var query = _repository.GetAll<CodeSnippet>()

                .Include(x => x.Erstellt_User).AsNoTracking()
                .Include(x => x.Geaendert_User).AsNoTracking()

                .Include(x => x.Bemerkungen)
                .ThenInclude(x => x.Erstellt_User).AsNoTracking()

                .Include(x => x.Bemerkungen)
                .ThenInclude(x => x.Geaendert_User).AsNoTracking()

                .Include(x => x.CodeContents)
                .ThenInclude(x => x.Erstellt_User).AsNoTracking()

                .Include(x => x.CodeContents)
                .ThenInclude(x => x.Geaendert_User).AsNoTracking()

                .Include(x => x.CodeContents)
                .ThenInclude(x => x.Bemerkungen)
                .ThenInclude(x => x.Erstellt_User).AsNoTracking()

                .Include(x => x.CodeContents)
                .ThenInclude(x => x.Bemerkungen)
                .ThenInclude(x => x.Geaendert_User).AsNoTracking();
                

            List<IQueryable<CodeSnippet>> preresults = new List<IQueryable<CodeSnippet>>();
            foreach (var value in searchValues)
            {
                preresults.Add(query.Where(x =>
                    EF.Functions.Like(x.Name.ToLower().Trim(), $"%{value}%") ||
                    EF.Functions.Like(x.Beschreibung.ToLower().Trim(), $"%{value}%") ||
                    x.Bemerkungen.Any(b =>
                        EF.Functions.Like(b.Betreff.ToLower().Trim(), $"%{value}%") ||
                        EF.Functions.Like(b.Text.ToLower().Trim(), $"%{value}%")
                    ) ||
                    x.CodeContents.Any(c =>
                        EF.Functions.Like(c.Name.ToLower().Trim(), $"%{value}%") ||
                        EF.Functions.Like(c.Beschreibung.ToLower().Trim(), $"%{value}%") ||
                        EF.Functions.Like(c.Content.ToLower().Trim(), $"%{value}%") ||
                        x.Bemerkungen.Any(b =>
                            EF.Functions.Like(b.Betreff.ToLower().Trim(), $"%{value}%") ||
                            EF.Functions.Like(b.Text.ToLower().Trim(), $"%{value}%")
                        )
                    )
                ));
            }


            return _mapper.Map<List<CodeSnippetVievmodel>>(preresults.SelectMany(x => x));
        }


        public async Task Add()
        {

            await _repository.Create(new CodeContent
            {
                Name = DateTime.Now.ToString(),
                Beschreibung = "abc",
                Content = "Test",
            });
        }

        public async Task<List<CodeSnippetVievmodel>> GetAllCodeSnippets()
        {
            var results = await _repository.GetAll<CodeSnippet>()

                .Include(x => x.Erstellt_User)
                .Include(x => x.Geaendert_User)

                .Include(x => x.Bemerkungen)
                .ThenInclude(x => x.Erstellt_User)

                .Include(x => x.Bemerkungen)
                .ThenInclude(x => x.Geaendert_User)

                .Include(x => x.CodeContents)
                .ThenInclude(x => x.Erstellt_User)

                .Include(x => x.CodeContents)
                .ThenInclude(x => x.Geaendert_User)

                .Include(x => x.CodeContents)
                .ThenInclude(x => x.Bemerkungen)
                .ThenInclude(x => x.Erstellt_User)

                .Include(x => x.CodeContents)
                .ThenInclude(x => x.Bemerkungen)
                .ThenInclude(x => x.Geaendert_User)

                .ToListAsync();

            return _mapper.Map<List<CodeSnippetVievmodel>>(results);
        }
    }
}
