namespace MyBackend.WebApi.DTOs;

public class EnvironmentReadDto
{
    public required string environmentName { get; set; }
    public required int environmentXScale { get; set; }
    public required int environmentYScale { get; set; }
    public required string environmentId { get; set; }
}