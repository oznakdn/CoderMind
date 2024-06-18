namespace CoderMind.Shared.Dtos.ContentDtos;

public class UpdateContentDto
{
    public string Id { get; set; }
    public string Text { get; set; }
    public string? Files { get; set; }
    public string? Links { get; set; }
}
