using Journal.Domain.Entities;

namespace Journal.Api.Repositories
{
    public interface IQualisRepository
    {
        Task<IEnumerable<Qualis>> ListAll();
    }
}