using MongoDB.Bson.Serialization.Attributes;
using MongoDB.Bson;

namespace CoderMind.Domain.Models;

public class Content : IModel
{
    public string Id { get; set; }
    public string SubjectId { get; set; }
    public string Text { get; set; }
    public string? Files { get; set; }
    public string? Links { get; set; }

    [BsonIgnore]
    public Subject? Subject { get; set; }

    protected Content() { }

    public static Content CreateMongoContent(string subjectId, string text, string? files, string? links)
    {
        var content = new Content
        {
            Id = ObjectId.GenerateNewId().ToString(),
            SubjectId = subjectId,
            Text = text,
            Files = files,
            Links = links
        };
        return content;
    }

    public static Content CreateEfContent(string subjectId, string text, string? files, string? links)
    {
        var content = new Content
        {
            Id = Guid.NewGuid().ToString(),
            SubjectId = subjectId,
            Text = text,
            Files = files,
            Links = links
        };
        return content;
    }

}
