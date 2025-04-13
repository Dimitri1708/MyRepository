using MyBackend.WebApi.DTOs;

namespace MyBackend.WebApi.Repositories;

public interface IEnvironmentRepository
{
    Task Create(EnvironmentCreateDto environmentCreateDto);
    Task<List<EnvironmentReadDto>> Read(string email);
    Task Delete(string environmentId);
}