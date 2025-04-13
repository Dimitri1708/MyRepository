namespace MyBackend.WebApi.DTOs;

public class ObjectCreateDto
{
    public required string environmentId { get; set; }
    public required int scaleX { get; set; }
    public required int scaleY { get; set; }
    public required int positionX { get; set; }
    public required int positionY { get; set; }
    public required int rotation { get; set; }
    public required string shape { get; set; }
}