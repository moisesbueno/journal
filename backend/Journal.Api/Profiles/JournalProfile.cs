using AutoMapper;
using Journal.Api.Models;
using Journal.MessageBus.Messages;
namespace Journal.Api.Profiles
{
    public class JournalProfile : Profile
    {
        public JournalProfile()
        {
            CreateMap<JournalRequest, JournalMessage>()
                                .ForMember(c => c.Qualis2019, c => c.MapFrom(c => c.Qualis));

            CreateMap<Data.Models.Journal, JournalResponse>();
        }
    }
}
