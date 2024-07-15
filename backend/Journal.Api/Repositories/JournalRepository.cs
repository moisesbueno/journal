using Dapper;
using Journal.Api.Models;
using Journal.Data;
using Journal.Data.Models;
using Microsoft.EntityFrameworkCore;
using System.Linq;
using System.Text;

namespace Journal.Repositories
{
    public class JournalRepository
    {
        private readonly JournalContext _journalContext;
        public JournalRepository(JournalContext journalContext)
        {
            _journalContext = journalContext;
        }

        public async Task<(int, IEnumerable<JournalModel>)> GetAll(string search, int pageNumber, int pageSize)
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
                                         QualisId = journal.Qualisid.HasValue? journal.Qualisid.Value: 0,
                                     })
                                     .ToListAsync();

            return (total, result);

        }
        public async Task<JournalModel> GetById(Guid id)
        {
            var result = await (from journal in _journalContext.Journals.AsNoTracking()
                                select new JournalModel
                                {
                                    Apc = journal.Apc,
                                    Description = journal.Name,
                                    Id = id,
                                    Image = journal.Url,
                                    Issn = journal.Issn,
                                    Name = journal.Name,
                                    Url = journal.Url,
                                    QualisId = journal.Qualisid.Value
                                }).FirstAsync();

            return result;

        }

        private static StringBuilder GetSql()
        {
            return new StringBuilder(@"SELECT j.*, q.Description FROM journal AS j LEFT JOIN qualis AS q ON j.QualisId = q.Id ");
        }
    }
}
