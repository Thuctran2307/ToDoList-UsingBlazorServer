using MongoDB.Bson;
using MongoDB.Bson.Serialization.Attributes;

namespace New.Model
{
    public class ToDo
    {
        [BsonId]
        public string id;

        public string userId;
        public string title;
        public string description;
        public string status;
        public string timeStart;
        public string timeEnd;
        public string priority;


        // contructor

        public ToDo()
        {
            this.id = ObjectId.GenerateNewId().ToString();
            this.userId = "";
            this.title = "";
            this.description = "";
            this.status = "";
            this.timeStart = "";
            this.timeEnd = "";
            this.priority = "";
        }

        public ToDo(string userId, string title, string description, string status, string priority, string timeStart, string timeEnd)
        {
            this.id = ObjectId.GenerateNewId().ToString();
            this.userId = userId;
            this.title = title;
            this.description = description;
            this.status = status;
            this.timeStart = timeStart;
            this.timeEnd = timeEnd;
            this.priority = priority;
        }

    }
}
