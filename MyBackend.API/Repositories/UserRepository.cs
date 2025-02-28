using Dapper;
using Microsoft.Data.SqlClient;
using schoolProject.WebApi.Models;

namespace schoolProject.WebApi.Repositories
{
    public class UserRepository
    {
        private readonly string _sqlConnectionString;
        public UserRepository(string sqlConnectionString)
        {
            _sqlConnectionString = sqlConnectionString;
        }

        public async Task<User> InsertAsync(User user)
        {
            using (var SqlConnection = new SqlConnection(_sqlConnectionString))
            {
                var environmentId = await SqlConnection.ExecuteAsync("INSERT INTO [WeatherForecast] (Id, TemperatureC, Summary) VALUES (@Id, @TemperatureC, @Summary)", user);
                return user;
            }
        }
    }
}
