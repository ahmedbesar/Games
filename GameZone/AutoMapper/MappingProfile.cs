using Microsoft.Extensions.Logging;

namespace GameZone.AutoMapper
{
    public class MappingProfile : Profile
    {
        public MappingProfile()
        {

            // CreateMap<Tb,Model>();
            CreateMap<Game, CreateGameFormViewModel>()
                .ReverseMap();
           
        }

    }
}
