namespace MyBackend.WebApi.DTOs;

public class ObjectUpdateDto
{
    public required string objectId { get; set; }
    public required int? scaleX { get; set; }
    public required int? scaleY { get; set; }
    public required int? positionX { get; set; }
    public required int? positionY { get; set; }
    public required int? rotation { get; set; }
}