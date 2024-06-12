using MongoDB.Bson.Serialization.Attributes;
using MongoDB.Bson;

namespace CoderMind.Domain.Models;

public class Subject
{
    [BsonId]
    [BsonRepresentation(BsonType.ObjectId)]
    public string Id { get; set; }
    public string TechnologyId { get; set; }
    public string Title { get; set; }
    public string[]? Tags { get; set; }
    public DateTime CreatedDate { get; set; }

    protected Subject() { }

    public static bool CreateSubject(string technologyId, string title, string[]? tags)
    {
        if (string.IsNullOrWhiteSpace(technologyId) || string.IsNullOrWhiteSpace(title)) return false;

        var subject = new Subject
        {
            TechnologyId = technologyId,
            Title = title,
            Tags = tags,
            CreatedDate = DateTime.Now
        };
        return true;
    }

}
