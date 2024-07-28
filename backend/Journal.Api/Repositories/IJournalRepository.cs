
using JournalModel = Journal.Data.Models.Journal;

namespace Journal.Api.Repositories
{
    public interface IJournalRepository
    {
        string Search { get; }
        Task UpdateAsync(JournalModel journal);
        Task<bool> DeleteAsync(Guid id);
        Task<JournalModel> GetByIdAsync(Guid id);
        Task<IEnumerable<JournalModel>> GetAsync(string search, int pageNumber, int pageSize);
        Task<int> CountAsync();
        Task AddAsync(JournalModel model);
    }
}
