using MongoDB.Bson;
using MongoDB.Bson.Serialization.Attributes;

namespace ClassroomManagementSystem.Models
{
    public class Course
    {
        [BsonId]
        [BsonRepresentation(BsonType.ObjectId)]
        public string Id { get; set; }

        [BsonElement("title")]
        public string Title { get; set; }

        [BsonElement("description")]
        public string Description { get; set; }

        [BsonElement("teacher")]
        public string Teacher { get; set; }
    }
}
