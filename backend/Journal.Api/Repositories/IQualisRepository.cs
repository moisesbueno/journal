using Journal.Data.Models;

namespace Journal.Api.Repositories
{
    public interface IQualisRepository
    {
        Task<IEnumerable<Qualis>> ListAll();
    }
}
