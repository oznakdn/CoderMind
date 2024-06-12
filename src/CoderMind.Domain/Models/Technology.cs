using MongoDB.Bson.Serialization.Attributes;
using MongoDB.Bson;

namespace CoderMind.Domain.Models;

public class Technology
{
    [BsonId]
    [BsonRepresentation(BsonType.ObjectId)]
    public string Id { get; set; }
    public string Name { get; set; }
    public string Logo { get; set; }
    public string Description { get; set; }

    [BsonIgnore]
    public ICollection<Subject> Subjects { get; set; } = new List<Subject>();

    protected Technology() { }

    public static bool CreateTechnology(string name, string? logo, string? description)
    {
        if (string.IsNullOrWhiteSpace(name)) return false;

        var technology = new Technology
        {
            Name = name,
            Logo = logo ?? string.Empty,
            Description = description ?? string.Empty
        };
        return true;
    }
}
