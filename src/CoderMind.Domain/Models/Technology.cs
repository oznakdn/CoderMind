using MongoDB.Bson.Serialization.Attributes;
using MongoDB.Bson;

namespace CoderMind.Domain.Models;

public class Technology : IModel
{

    public string Id { get; set; }
    public string Name { get; set; }
    public string Logo { get; set; }
    public string Description { get; set; }

    [BsonIgnore]
    public ICollection<Subject> Subjects { get; set; } = new List<Subject>();

    protected Technology() { }

    public static Technology CreateMongoTechnology(string name, string? logo, string? description)
    {
        var technology = new Technology
        {
            Id = ObjectId.GenerateNewId().ToString(),
            Name = name,
            Logo = logo ?? string.Empty,
            Description = description ?? string.Empty
        };
        return technology;
    }

    public static Technology CreateEfTechnology(string name, string? logo, string? description)
    {
        var technology = new Technology
        {
            Id = Guid.NewGuid().ToString(),
            Name = name,
            Logo = logo ?? string.Empty,
            Description = description ?? string.Empty
        };
        return technology;
    }
}
