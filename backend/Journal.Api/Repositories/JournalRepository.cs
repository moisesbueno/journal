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

        public async Task<(int, IEnumerable<JournalModel>)> GetAsync(string search, int pageNumber, int pageSize)
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
                                     .Select(journal => new JournalModel
                                     {
                                         Apc = journal.Apc,
                                         Description = journal.Name,
                                         Id = journal.Id,
                                         Image = journal.Url,
                                         Issn = journal.Issn,
                                         Name = journal.Name,
                                         Url = journal.Url,
                                         QualisId = journal.Qualisid.HasValue ? journal.Qualisid.Value : 0,
                                     })
                                     .ToListAsync();

            return (total, result);

        }

        public Task UpdateAsync(JournalModel journal)
        {
            throw new NotImplementedException();
        }

        public async Task DeleteAsync(Guid id)
        {
            var journal = await _journalContext.Journals.FindAsync(id);

            _journalContext.Journals.Remove(journal);
        }

        public async Task<JournalModel> GetByIdAsync(Guid id)
        {
            return await _journalContext.Journals.AsNoTracking()
                                            .Select(journal => new JournalModel()
                                            {
                                                Apc = journal.Apc,
                                                Description = journal.Name,
                                                Id = id,
                                                Image = journal.Url,
                                                Issn = journal.Issn,
                                                Name = journal.Name,
                                                Url = journal.Url,
                                                QualisId = journal.Qualisid.Value
                                            })
                                            .FirstAsync(j => j.Id == id);

        }

        public async Task AddAsync(JournalModel model)
        {
            await _journalContext.Journals.AddAsync(new Data.Models.Journal()
            {

            });
        }
    }
}
