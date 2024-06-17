namespace CoderMind.Shared.Dtos.ContentDtos;

public class CreateContentDto
{
    public string SubjectId { get; set; }
    public string Text { get; set; }
    public string? Files { get; set; }
    public string? Links { get; set; }

}
