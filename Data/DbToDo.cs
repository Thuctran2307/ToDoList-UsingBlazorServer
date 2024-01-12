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

        // check id is exist

        public static async Task<bool> CheckId(string id)
        {
            var _db = Mongo.GetDatabase();

            var collection = _db.GetCollection<ToDo>(_collection);

            var result = await collection.FindAsync(x => x.id == id).Result.FirstOrDefaultAsync();

            if (result == null)
            {
                return false;
            }
            else
            {
                return true;
            }
        }
        // Update ToDo

        public static async Task<ToDo> UpdateToDo(ToDo ToDo)
        {
            var _db = Mongo.GetDatabase();

            var collection = _db.GetCollection<ToDo>(_collection);

            var filter = Builders<ToDo>.Filter.Eq("id", ToDo.id);

            var update = Builders<ToDo>.Update
                .Set("title", ToDo.title)
                .Set("description", ToDo.description)
                .Set("status", ToDo.status)
                .Set("timeStart", ToDo.timeStart)
                .Set("timeEnd", ToDo.timeEnd)
                .Set("priority", ToDo.priority);

            var result = await collection.UpdateOneAsync(filter, update);

            return ToDo;
        }

        // DeleteToDoById

        public static async Task<bool> DeleteToDoById(string id)
        {
            var _db = Mongo.GetDatabase();

            var collection = _db.GetCollection<ToDo>(_collection);

            var filter = Builders<ToDo>.Filter.Eq("id", id);

            var result = await collection.DeleteOneAsync(filter);

            if (result.DeletedCount == 1)
            {
                return true;
            }
            else
            {
                return false;
            }
        }
    }
}
