using Dapper;
using Microsoft.Data.SqlClient;
using MyBackend.WebApi.DTOs;

namespace MyBackend.WebApi.Repositories;

public class ObjectRepository(string sqlConnectionString) : IObjectRepository
{
    public async Task Create(List<ObjectCreateDto> objectList)
    {
        await using var sqlConnection = new SqlConnection(sqlConnectionString);
        foreach (var objectCreateDto in objectList)
        {
            await sqlConnection.ExecuteAsync("INSERT INTO [Object] (EnvironmentId, ScaleX, ScaleY, PositionX, PositionY, Rotation, Shape) VALUES (@environmentId, @scaleX, @scaleY, @positionX, @positionY, @rotation, @shape)",
                new
                {
                    environmentId = Guid.Parse(objectCreateDto.environmentId),
                    objectCreateDto.scaleX,
                    objectCreateDto.scaleY,
                    objectCreateDto.positionX,
                    objectCreateDto.positionY,
                    objectCreateDto.rotation,
                    objectCreateDto.shape
                });
        }
    }

    public async Task<List<ObjectReadDto>> Read(string environmentId)
    {
        await using var sqlConnection = new SqlConnection(sqlConnectionString);
        var result = await sqlConnection.QueryAsync<ObjectReadDto>("SELECT CAST(ObjectId AS VARCHAR(36)) AS objectId, CAST(EnvironmentId AS VARCHAR(36)) AS environmentId, ScaleX AS scaleX, ScaleY AS scaleY, PositionX AS positionX, PositionY AS positionY, Rotation AS rotation, Shape AS shape FROM [Object] WHERE EnvironmentId = @environmentId",
            new
            {
                environmentId = Guid.Parse(environmentId)
            });
        return result.ToList();
    }

    public async Task Update(List<ObjectUpdateDto> updatedObjectList)
    {
        await using var sqlConnection = new SqlConnection(sqlConnectionString);
        foreach (var objectUpdateDto in updatedObjectList)
        {
            await sqlConnection.ExecuteAsync("UPDATE [Object] SET ScaleX = @scaleX, ScaleY = @scaleY, PositionX = @positionX, PositionY = @positionY, Rotation = @rotation WHERE ObjectId = @objectId",
               new
               {
                   objectUpdateDto.scaleX,
                   objectUpdateDto.scaleY,
                   objectUpdateDto.positionX,
                   objectUpdateDto.positionY,
                   objectUpdateDto.rotation,
                   objectId = Guid.Parse(objectUpdateDto.objectId)
               });
        }
    }

    public async Task Delete(List<string> objectIdList)
    {
        await using var sqlConnection = new SqlConnection(sqlConnectionString);
        foreach (var objectId in objectIdList)
        {
            await sqlConnection.ExecuteAsync("DELETE FROM [Object] WHERE ObjectId = @objectId",
                new
                {
                    objectId = Guid.Parse(objectId)
                });
        }
    }
}