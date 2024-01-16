using MongoDB.Bson.Serialization.Attributes;

namespace New.Model
{
    public class ToDoInDay
    {
        [BsonId]
        public string id { get; set; }

        public long date { get; set; }

        public bool isCheckOut { get; set; }

        public bool isCheckIn { get; set; }

        public string idUser { get; set; }

        public ToDoInDay()
        {
            this.id = MongoDB.Bson.ObjectId.GenerateNewId().ToString();
            this.date = DateTime.Today.Ticks;
            this.isCheckOut = false;
            this.isCheckIn = false;
            this.idUser = "";
        }
        
    }

    
}