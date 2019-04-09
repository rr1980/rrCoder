using AutoMapper;
using Entities;
using VievModels;

namespace Web
{
    public class MapperProfile : Profile
    {
        public MapperProfile()
        {
            CreateMap<Benutzer, BenutzerVievmodel>().ReverseMap().IncludeAllDerived();
            CreateMap<Bemerkung, BemerkungenVievmodel>().ReverseMap().IncludeAllDerived();
            CreateMap<CodeContent, CodeContentVievmodel>().ReverseMap().IncludeAllDerived();
            CreateMap<CodeSnippet, CodeSnippetVievmodel>().ReverseMap().IncludeAllDerived();
        }
    }
}
