using MyBackend.WebApi.DTOs;

namespace MyBackend.WebApi.Repositories;

public interface IObjectRepository
{
    Task Create(List<ObjectCreateDto> objectList);
    Task<List<ObjectReadDto>> Read(string environmentId);
    Task Update(List<ObjectUpdateDto> updatedObjectList);
    Task Delete(List<string> objectIdList);
}