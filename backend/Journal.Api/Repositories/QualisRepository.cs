using Journal.Data;
using Journal.Data.Models;
using Microsoft.EntityFrameworkCore;

namespace Journal.Api.Repositories
{
    public class QualisRepository : IQualisRepository
    {
        private readonly JournalContext _journalContext;

        public QualisRepository(JournalContext journalContext)
        {
            _journalContext = journalContext;
        }

        public async Task<IEnumerable<Qualis>> ListAll()
        {
            var result = await _journalContext.Qualis
                                              .AsNoTracking()
                                              .ToListAsync();

            return result;
        }
    }
}
