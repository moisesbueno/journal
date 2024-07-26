using Dapper;
using Journal.Data.Interfaces;
using Quartz;

namespace Journal.Api.Jobs
{
    public class CleanLogJob : IJob
    {
        private readonly IDataSource _dataSource;
        private readonly ILogger<CleanLogJob> _logger;
        public CleanLogJob(IDataSource dataSource, ILogger<CleanLogJob> logger)
        {
            _dataSource = dataSource;
            _logger = logger;
        }
        public async Task Execute(IJobExecutionContext context)
        {
            using var connection = await _dataSource.OpenConnectionAsync();

            var result = await connection.ExecuteAsync("DElETE FROM Logs WHERE Timestamp <= @Timestamp", new { Timestamp = DateTime.UtcNow });

            _logger.LogInformation("Clean log table with result {result}", result);
        }
    }
}