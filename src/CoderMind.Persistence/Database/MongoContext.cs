using MongoDB.Driver;

namespace CoderMind.Persistence.Database;

public class MongoContext<T> where T : class
{
    protected IMongoCollection<T> Collection { get; set; }
    protected MongoClient MongoClient { get; set; }
    protected IMongoDatabase Database { get; set; }

    public MongoContext(MongoOptions options)
    {
        MongoClient = new MongoClient(options.ConnectionString);
        Database = MongoClient.GetDatabase(options.DatabaseName);
        Collection = Database.GetCollection<T>(typeof(T).Name);
    }
}
