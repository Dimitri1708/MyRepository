namespace MyBackend.WebApi.DTOs;

public class EnvironmentCreateDto
{
    public string email { get; set; }
    public required string environmentName { get; set; }
    public required int environmentXScale { get; set; }
    public required int environmentYScale { get; set; }
}