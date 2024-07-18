
using JournalModel = Journal.Data.Models.Journal;

namespace Journal.Api.Repositories
{
    public interface IJournalRepository
    {
        Task UpdateAsync(JournalModel journal);
        Task DeleteAsync(Guid id);
        Task<JournalModel> GetByIdAsync(Guid id);
        Task<(int, IEnumerable<JournalModel>)> GetAsync(string search, int pageNumber, int pageSize);
        Task AddAsync(JournalModel model);
    }
}
