using MongoDB.Bson;
using MongoDB.Bson.Serialization.Attributes;

namespace CoderMind.Domain.Models;

public class User
{
    [BsonId]
    [BsonRepresentation(BsonType.ObjectId)]
    public string Id { get; set; }
    public string Username { get; set; }
    public string Password { get; set; }

    protected User() { }

    public static User CreateUser(string username, string password)
    {
        if(string.IsNullOrWhiteSpace(username) || string.IsNullOrWhiteSpace(password)) return null;

        var user = new User
        {
            Username = username,
            Password = password
        };

        return user;
    }
   
}
