using Dapper;
using Microsoft.Data.SqlClient;
using MyBackend.WebApi.DTOs;

namespace MyBackend.WebApi.Repositories;
public class EnvironmentRepository(string sqlConnectionString) : IEnvironmentRepository
{
    public async Task Create(EnvironmentCreateDto environmentCreateDto)
    {
        await using var sqlConnection = new SqlConnection(sqlConnectionString);
        await sqlConnection.ExecuteAsync("INSERT INTO [Environment] (Email, EnvironmentName, EnvironmentXScale, EnvironmentYScale) VALUES (@email, @environmentName, @environmentXScale, @environmentYScale)",
            new
            {
                environmentCreateDto.email,
                environmentCreateDto.environmentName,
                environmentCreateDto.environmentXScale,
                environmentCreateDto.environmentYScale
            });
    }

    public async Task<List<EnvironmentReadDto>> Read(string email)
    {
        await using var sqlConnection = new SqlConnection(sqlConnectionString);
        {
            var environmentList = await sqlConnection.QueryAsync<EnvironmentReadDto>(
                "SELECT EnvironmentName, EnvironmentXScale, EnvironmentYScale, CAST(EnvironmentId AS VARCHAR(36)) AS EnvironmentId FROM [Environment] WHERE Email = @email",
                new
                {
                    email
                });
            return environmentList.ToList();
        }
    }

    public async Task Delete(string environmentId)
    {
        await using var sqlConnection = new SqlConnection(sqlConnectionString);
        await sqlConnection.ExecuteAsync("DELETE FROM [Environment] WHERE EnvironmentId = @environmentId",
            new
            {
                environmentId = Guid.Parse(environmentId)
            });
    }
}