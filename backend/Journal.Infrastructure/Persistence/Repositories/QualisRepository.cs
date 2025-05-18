using Journal.Domain.Abstractions;
using Journal.Domain.Entities;
using Journal.Infrastructure.Persistence.Context;
using Microsoft.EntityFrameworkCore;

<<<<<<<< HEAD:backend/Journal.Infrastructure/Persistence/Repositories/QualisRepository.cs
namespace Journal.Infrastructure.Persistence.Repositories
========
namespace Journal.Api.Repositories;

public class QualisRepository : IQualisRepository
>>>>>>>> develop:backend/Journal.Api/Repositories/QualisRepository.cs
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