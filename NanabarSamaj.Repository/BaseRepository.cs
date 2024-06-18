using Npgsql;
using System.Data;
using Microsoft.Extensions.Configuration;


namespace NanabarSamaj.Repository
{
    public class BaseRepository : IDisposable
    {
        protected IDbConnection con;
        private readonly IConfiguration _configuration;

        public IDbConnection CreateConnection()
              => new NpgsqlConnection(_configuration["ApplicationSettings:ConnectionString"].ToString());

        public IDbConnection CreateMasterConnection()
              => new NpgsqlConnection(_configuration["ApplicationSettings:ConnectionString"].ToString());

        public BaseRepository(IConfiguration configuration)
        {
            _configuration = configuration;
            string connectionString = configuration["ApplicationSettings:ConnectionString"].ToString();
            con = new NpgsqlConnection(connectionString);
        }

        public void Dispose()
        {
            throw new NotImplementedException();
        }
    }
}
