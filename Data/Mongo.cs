using MongoDB.Driver;

namespace New.Data
{
    public class Mongo
    {
        public static IMongoDatabase GetDatabase()
        {
            var mongoClient = new MongoClient();

            try
            {
                return mongoClient.GetDatabase("new");
            }
            catch
            {
                var databaseSettings = new MongoDatabaseSettings();
                var database = mongoClient.GetDatabase("new", databaseSettings);
                return database;
            }
        }
    }
}

