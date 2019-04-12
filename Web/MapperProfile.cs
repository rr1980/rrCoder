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
            CreateMap<CodeSnippet, CodeSnippetSearchResponseVievmodel>()
                .ForMember(t => t.Erstellt_User, o => o.MapFrom(s => s.Erstellt_User.ToString()))
                .ForMember(t => t.Geaendert_User, o => o.MapFrom(s => s.Geaendert_User.ToString()))
                .ForMember(t => t.CodeContents_Count, o => o.MapFrom(s => s.CodeContents.Count));


        }
    }
}
