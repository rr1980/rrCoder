using AutoMapper;
using Entities;
using VievModels;

namespace Mapper
{
    public class BenutzerProfile : Profile
    {
        public BenutzerProfile()
        {
            CreateMap<Benutzer, BenutzerVievmodel>();
        }
    }

    public class CodeContentProfile : Profile
    {
        public CodeContentProfile()
        {
            CreateMap<CodeContent, CodeContentVievmodel>();
        }
    }
}
