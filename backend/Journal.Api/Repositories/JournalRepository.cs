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
            Search = string.Empty;
        }

        public string Search { get; }

        public async Task AddAsync(Data.Models.Journal model)
        {
            await _journalContext.Journals.AddAsync(model);
        }

        public async Task<int> CountAsync()
        {
            var query = _journalContext.Journals
                                       .AsNoTracking()
                                       .AsQueryable();

            if (!string.IsNullOrEmpty(Search))
            {
                query = query.Where(c => c.Name.Contains(Search));
            }

            var total = await query.CountAsync();

            return total;
          
        }

        public async Task DeleteAsync(Guid id)
        {
            var journal = await _journalContext.Journals.FindAsync(id);

            _journalContext.Journals.Remove(journal);
        }

        public async Task<IEnumerable<Data.Models.Journal>> GetAsync(string search, int pageNumber, int pageSize)
        {
            var query = _journalContext.Journals
                                       .AsNoTracking()
                                       .AsQueryable();

            if (!string.IsNullOrEmpty(search))
            {
                query = query.Where(c => c.Name.Contains(search));
            }

            var result = await query.Skip((pageNumber - 1) * pageSize)
                                     .Take(pageSize)
                                     .ToListAsync();

            return result;
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
