using MongoDB.Driver;
using New.Model;

namespace New.Data
{
    public class DbToDoInDay
    {
        private static string _collection = "ToDoInDay";

        // add ToDoInDay

        public static async Task<ToDoInDay> AddToDoInDay(ToDoInDay ToDoInDay)
        {
            var _db = Mongo.GetDatabase();

            var collection = _db.GetCollection<ToDoInDay>(_collection);

            var existingToDoInDay = await collection.FindAsync(x => x.date == ToDoInDay.date).Result.FirstOrDefaultAsync();

            if(existingToDoInDay != null)
            {
                return existingToDoInDay;
            }

            await collection.InsertOneAsync(ToDoInDay);

            return ToDoInDay;
        }

        //GetAllToDoInDay

        public static async Task<List<ToDoInDay>> GetAllToDoInDay()
        {
            var _db = Mongo.GetDatabase();
            var collection = _db.GetCollection<ToDoInDay>(_collection);

            var filter = Builders<ToDoInDay>.Filter.Empty; // This creates a filter that matches all documents

            var result = await collection.FindAsync(filter).Result.ToListAsync();

            return result;
        }

        // find id by date

        public static async Task<string> FindIdByDate(long date)
        {
            var _db = Mongo.GetDatabase();
            var collection = _db.GetCollection<ToDoInDay>(_collection);

            var filter = Builders<ToDoInDay>.Filter.Eq("date", date);

            var result = await collection.FindAsync(filter).Result.FirstOrDefaultAsync();

            if(result == null)
            {
                return "";
            }
            return result.id;
        }

        // Update ToDoInDay

        public static async Task<ToDoInDay> UpdateToDoInDay(ToDoInDay ToDoInDay)
        {
            var _db = Mongo.GetDatabase();
            var collection = _db.GetCollection<ToDoInDay>(_collection);

            var filter = Builders<ToDoInDay>.Filter.Eq("id", ToDoInDay.id);

            var result = await collection.ReplaceOneAsync(filter, ToDoInDay);

            return ToDoInDay;
        }

        // get ToDoInDay by date

        public static async Task<ToDoInDay> GetToDoInDayByDate(long date)
        {
            var _db = Mongo.GetDatabase();
            var collection = _db.GetCollection<ToDoInDay>(_collection);

            var filter = Builders<ToDoInDay>.Filter.Eq("date", date);

            var result = await collection.FindAsync(filter).Result.FirstOrDefaultAsync();

            return result;
        }

        // get date by id

        public static async Task<long> GetDateById(string id)
        {
            var _db = Mongo.GetDatabase();
            var collection = _db.GetCollection<ToDoInDay>(_collection);

            var filter = Builders<ToDoInDay>.Filter.Eq("id", id);

            var result = await collection.FindAsync(filter).Result.FirstOrDefaultAsync();

            return result.date;
        }

        // get ToDoInDay by userId

        public static async Task<List<ToDoInDay>> GetToDoInDayByUserId(string userId)
        {
            var _db = Mongo.GetDatabase();
            var collection = _db.GetCollection<ToDoInDay>(_collection);

            var filter = Builders<ToDoInDay>.Filter.Eq("idUser", userId);

            var result = await collection.FindAsync(filter).Result.ToListAsync();

            return result;
        }

        
    }
}