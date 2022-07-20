using AutoMapper;
using SpeakerMgmtApp.ViewModels;

namespace SpeakerMgmtApp.Models.Mapping
{
    public class MappingProfile : Profile
    {
        public MappingProfile()
        {
            // Create a mapping from one type to another
            // Service Layer to View Layer and the reverse
            // <source, destination>
            CreateMap<Speaker, SpeakerViewModel>();
            CreateMap<SpeakerViewModel, Speaker>();
        }

    }
}
