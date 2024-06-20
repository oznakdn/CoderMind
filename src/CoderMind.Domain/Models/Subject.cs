using MongoDB.Bson.Serialization.Attributes;
using MongoDB.Bson;

namespace CoderMind.Domain.Models;

public class Subject : IModel
{
    public string Id { get; set; }
    public string TechnologyId { get; set; }
    public string Title { get; set; }
    public string? Tags { get; set; }
    public DateTime CreatedDate { get; set; }

    [BsonIgnore]
    public Technology? Technology { get; set; }

    [BsonIgnore]
    public Content Content { get; set; }


    protected Subject() { }

    public static Subject CreateMongoSubject(string technologyId, string title, string? tags)
    {
        
        var subject = new Subject
        {
            Id = ObjectId.GenerateNewId().ToString(),
            TechnologyId = technologyId,
            Title = title,
            Tags = tags,
            CreatedDate = DateTime.Now
        };
        return subject;
    }

    public static Subject CreateEfSubject(string technologyId, string title, string? tags)
    {

        var subject = new Subject
        {
            Id = Guid.NewGuid().ToString(),
            TechnologyId = technologyId,
            Title = title,
            Tags = tags,
            CreatedDate = DateTime.Now
        };
        return subject;
    }

}
