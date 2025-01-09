namespace Journal.Data.Interfaces
{
    public class UnitOfWork(JournalContext journalContext) : IUnitOfWork
    {
        private bool _disposed;
        private readonly JournalContext _journalContext = journalContext;

        protected virtual void Dispose(bool disposing)
        {
            if (!_disposed)
            {
                if (disposing)
                {
                    _journalContext?.Dispose();
                }

                _disposed = true;
            }
        }

        ~UnitOfWork()
        {
            Dispose(false);
        }

        public void Dispose()
        {
            Dispose(true);
            GC.SuppressFinalize(this);
        }

        public async Task<int> SaveChangesAsync()
        {
            return await _journalContext.SaveChangesAsync();
        }
    }
}