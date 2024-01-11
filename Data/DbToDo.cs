using New.Model;
using MongoDB.Driver;

namespace New.Data
{
    public class DbToDo
    {
        private static string _collection = "ToDo";

    
        public static async Task<List<ToDo>> GetAllToDo()
        {
            var _db = Mongo.GetDatabase();
            var collection = _db.GetCollection<ToDo>(_collection);

            var filter = Builders<ToDo>.Filter.Empty; // This creates a filter that matches all documents

            var result = await collection.FindAsync(filter).Result.ToListAsync();



            return result;
        }

        public static async Task<ToDo> GetToDoById(string id)
        {
            var _db = Mongo.GetDatabase();

            var collection = _db.GetCollection<ToDo>(_collection);

            var result = await collection.FindAsync(x => x.id == id).Result.FirstOrDefaultAsync();

            return result;
        }

        // add ToDo

        public static async Task<ToDo> AddToDo(ToDo ToDo)
        {
            var _db = Mongo.GetDatabase();

            var collection = _db.GetCollection<ToDo>(_collection);

            await collection.InsertOneAsync(ToDo);

            return ToDo;
        }
    }
}
