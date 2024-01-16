using MongoDB.Driver;
using New.Data;

namespace New.Model
{
    public class DbUser
    {
        private static string _collectionName = "User";

        // add new user

        public static async Task<User> AddUser(User user)
        {
            var _db = Mongo.GetDatabase();

            var collection = _db.GetCollection<User>(_collectionName);

            await collection.InsertOneAsync(user);

            return user;
        }

        // find user by username

        public static async Task<User> FindUserByUsername(string username)
        {
            var _db = Mongo.GetDatabase();

            var collection = _db.GetCollection<User>(_collectionName);

            var filter = Builders<User>.Filter.Eq(x => x.username, username);
            var result = await collection.FindAsync(filter).Result.FirstOrDefaultAsync();

            return result;
        }

        // get all user

        public static async Task<List<User>> GetAllUser()
        {
            var _db = Mongo.GetDatabase();

            var collection = _db.GetCollection<User>(_collectionName);

            var result = await collection.FindAsync(x => true).Result.ToListAsync();

            return result;
        }

        // getid by username


        public static async Task<string> GetIdByUsername(string username)
        {
            var _db = Mongo.GetDatabase();

            var collection = _db.GetCollection<User>(_collectionName);

            var filter = Builders<User>.Filter.Eq(x => x.username, username);
            var result = await collection.FindAsync(filter).Result.FirstOrDefaultAsync();

            return result.idUser;
        }
        // get user by id


        public static async Task<User> GetUserById(string id)
        {
            var _db = Mongo.GetDatabase();

            var collection = _db.GetCollection<User>(_collectionName);

            var filter = Builders<User>.Filter.Eq(x => x.idUser, id);
            var result = await collection.FindAsync(filter).Result.FirstOrDefaultAsync();

            return result;
        }
    }
}