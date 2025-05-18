using AutoMapper;
using Journal.Api.Models;
using Journal.Infrastructure.MessageBus.Queues;

namespace Journal.Api.Profiles;

public class JournalProfile : Profile
{
    public JournalProfile()
    {
        CreateMap<JournalRequest, JournalMessage>()
            .ForMember(c => c.Qualis2019, c => c.MapFrom(c => c.Qualis));

        CreateMap<Domain.Entities.Journal, JournalResponse>();
    }
}