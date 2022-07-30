using MySql.Data.MySqlClient;

namespace Journal
{
    public class DB
    {
        private static readonly DB dB = new DB();

        private DB() { }

        public static DB GetInstance()
        {
            return dB;
        }

        public MySqlConnection GetConnection(string connectionString)
        {
            return new MySqlConnection(connectionString);
        }
    }


}
