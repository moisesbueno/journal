using Journal.Api.Models;
using Journal.Api.Repositories;
using Journal.Data;
using Microsoft.EntityFrameworkCore;
using System.Net.NetworkInformation;

namespace Journal.Repositories
{
    public class JournalRepository : IJournalRepository
    {
        private readonly JournalContext _journalContext;

        public JournalRepository(JournalContext journalContext)
        {
            _journalContext = journalContext;
        }

        public async Task AddAsync(Data.Models.Journal model)
        {
            await _journalContext.Journals.AddAsync(model);
        }

        public async Task DeleteAsync(Guid id)
        {
            var journal = await _journalContext.Journals.FindAsync(id);

            _journalContext.Journals.Remove(journal);
        }

        public async Task<(int, IEnumerable<Data.Models.Journal>)> GetAsync(string search, int pageNumber, int pageSize)
        {
            var query = _journalContext.Journals
                                       .AsNoTracking()
                                       .AsQueryable();

            if (!string.IsNullOrEmpty(search))
            {
                query = query.Where(c => c.Name.Contains(search));
            }

            var total = await query.CountAsync();

            var result = await query.Skip((pageNumber - 1) * pageSize)
                                     .Take(pageSize)
                                     .ToListAsync();

            return (total, result);
        }

        public async Task<Data.Models.Journal> GetByIdAsync(Guid id)
        {
            return await _journalContext.Journals.AsNoTracking().FirstAsync(c => c.Id == id);
        }

        public Task UpdateAsync(Data.Models.Journal journal)
        {
            throw new NotImplementedException();
        }
    }
}
