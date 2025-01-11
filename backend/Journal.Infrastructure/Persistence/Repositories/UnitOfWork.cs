using Journal.Domain.Abstractions;
using Journal.Infrastructure.Persistence.Context;

namespace Journal.Infrastructure.Persistence.Repositories
{
    public class UnitOfWork : IUnitOfWork
    {
        private bool _disposed;
        private readonly JournalContext _journalContext;
        public IUserRepository UserRepository { get; }

        public UnitOfWork(JournalContext journalContext, IUserRepository userRepository)
        {
            _journalContext = journalContext;
            UserRepository = userRepository;
        }

        public async Task<int> CommitAsync(CancellationToken cancellationToken = default)
        {
            return await _journalContext.SaveChangesAsync(cancellationToken);
        }

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
    }
}