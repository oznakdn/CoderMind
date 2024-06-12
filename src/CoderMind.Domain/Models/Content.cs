using MongoDB.Bson.Serialization.Attributes;
using MongoDB.Bson;

namespace CoderMind.Domain.Models;

public class Content
{
    [BsonId]
    [BsonRepresentation(BsonType.ObjectId)]
    public string Id { get; set; }
    public string SubjectId { get; set; }
    public string Text { get; set; }
    public string[]? Files { get; set; }

    protected Content() { }

    public static bool CreateContent(string subjectId, string text, string[]? files)
    {
        if (string.IsNullOrWhiteSpace(subjectId) || string.IsNullOrWhiteSpace(text)) return false;

        var content = new Content
        {
            SubjectId = subjectId,
            Text = text,
            Files = files
        };
        return true;
    }

}
