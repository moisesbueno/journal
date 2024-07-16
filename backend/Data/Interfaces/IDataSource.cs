using System.Data;

namespace Journal.Data.Interfaces
{
    public interface IDataSource
    {
        Task<IDbConnection> OpenConnectionAsync();
    }
}
