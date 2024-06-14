using MongoDB.Driver;

namespace CoderMind.Persistence.Database;

public class MongoContext<T> where T : class
{
    protected IMongoCollection<T> Collection { get; set; }

    public MongoContext(MongoOptions options)
    {
        var client = new MongoClient(options.ConnectionString);
        var database = client.GetDatabase(options.DatabaseName);
        Collection = database.GetCollection<T>(typeof(T).Name);
    }
}
