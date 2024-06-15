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

    public static Subject CreateSubject(string technologyId, string title, string[]? tags)
    {
        
        var subject = new Subject
        {
            TechnologyId = technologyId,
            Title = title,
            Tags = tags,
            CreatedDate = DateTime.Now
        };
        return subject;
    }

}
