
namespace Journal.Data.Interfaces
{
    public class UnitOfWork : IUnitOfWork
    {
        private readonly JournalContext _journalContext;

        public UnitOfWork(JournalContext journalContext)
        {
            _journalContext = journalContext;
        }
        public void Dispose()
        {
            _journalContext?.Dispose();
        }

        public async Task<int> SaveChangesAsync()
        {
            return await _journalContext.SaveChangesAsync();
        }
    }
}
