using Dapper;
using Journal.Models;
using Microsoft.Extensions.Configuration;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Journal.Repositories
{
    public class JournalRepository
    {
        private string ConnectionString;
        public JournalRepository(IConfiguration configuration)
        {
            ConnectionString = configuration.GetConnectionString("Default");
        }

        public async Task<(int, IEnumerable<JournalModel>)> GetAll(string search, int pageNumber, int pageSize)
        {
            using var db = DB.GetInstance().GetConnection(ConnectionString);
            await db.OpenAsync();

            StringBuilder sql = GetSql();

            if (!string.IsNullOrWhiteSpace(search)) sql.Append(" WHERE name LIKE @search");

            sql.Append(" ORDER BY Name LIMIT @pageNumber,@pageSize;");

            var sqlTotal = sql.ToString().Split("LIMIT").First();

            var args = new
            {
                pageNumber,
                pageSize,
                search = $"%{search}%"
            };

            var sqlCount = $"select count(1) FROM ({ sqlTotal }) as x;";

            using var multipe = await db.QueryMultipleAsync(sql + sqlCount, args);
            var res = multipe.Read<JournalModel>();
            var total = multipe.Read<int>().First();

            return (total, res);

        }
        public async Task<JournalModel> GetById(Guid id)
        {
            using var db = DB.GetInstance().GetConnection(ConnectionString);
            await db.OpenAsync();

            StringBuilder sql = GetSql();

            sql.Append(" WHERE j.Id = @Id");

            return await db.QueryFirstAsync<JournalModel>(sql.ToString(), new { id });

        }

        private static StringBuilder GetSql()
        {
            return new StringBuilder(@"SELECT j.*, q.Description FROM journal AS j LEFT JOIN qualis AS q ON j.QualisId = q.Id ");
        }
    }
}
