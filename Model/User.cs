using MongoDB.Bson;
using MongoDB.Bson.Serialization.Attributes;

namespace New.Model
{
    public class User
    {
        [BsonId]
        public string idUser { get; set; }

        public string username { get; set; }

        public string password { get; set; }

        // contructor
        public User(string username, string password)
        {
            this.idUser = ObjectId.GenerateNewId().ToString();
            this.username = username;
            this.password = password;
        }

        public User()
        {
            this.idUser = ObjectId.GenerateNewId().ToString();
        }
    }

    

    
}