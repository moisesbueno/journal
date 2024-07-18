using AutoMapper;
using Journal.Api.Models;
using JournalModel = Journal.Data.Models.Journal;

namespace Journal.Api.Profiles
{
    public class JournalProfile : Profile
    {
        public JournalProfile()
        {
            CreateMap<JournalRequest, JournalModel>();

            CreateMap<JournalModel, JournalResponse>();
        }
    }
}
