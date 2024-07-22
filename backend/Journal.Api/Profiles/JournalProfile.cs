using AutoMapper;
using Journal.Api.Models;
using Journal.MessageBus;
namespace Journal.Api.Profiles
{
    public class JournalProfile : Profile
    {
        public JournalProfile()
        {
            CreateMap<JournalRequest, JournalQueue>();

            CreateMap<JournalQueue, Data.Models.Journal>();

        }
    }
}
