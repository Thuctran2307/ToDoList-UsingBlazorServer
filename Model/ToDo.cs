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

        public bool isCheckOut;

        public string idTodoInDay;
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
            this.isCheckOut = false;
            this.idTodoInDay = "";
        }

        public ToDo(string userId, string title, string description, string status, string priority, string timeStart, string timeEnd, string idTodoInDay)
        {
            this.id = ObjectId.GenerateNewId().ToString();
            this.userId = userId;
            this.title = title;
            this.description = description;
            this.status = status;
            this.timeStart = timeStart;
            this.timeEnd = timeEnd;
            this.priority = priority;
            this.isCheckOut = false;
            this.idTodoInDay = idTodoInDay;
        }

        public ToDo(ToDo model){
            this.id = model.id;
            this.userId = model.userId;
            this.title = model.title;
            this.description = model.description;
            this.status = model.status;
            this.timeStart = model.timeStart;
            this.timeEnd = model.timeEnd;
            this.priority = model.priority;
            this.isCheckOut = model.isCheckOut;
            this.idTodoInDay = model.idTodoInDay;
        }

    }
}
