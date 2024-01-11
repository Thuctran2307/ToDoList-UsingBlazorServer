using MongoDB.Bson.Serialization.Attributes;

namespace New.Model
{
    class User
    {
        [BsonId]
        public string idUser { get; set; }

        public string username { get; set; }

        public string password { get; set; }
    }
}