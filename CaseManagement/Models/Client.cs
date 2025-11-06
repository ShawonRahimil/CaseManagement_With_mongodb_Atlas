using MongoDB.Bson;
using MongoDB.Bson.Serialization.Attributes;

namespace CaseManagement.Models
{
    public class Client
    {
        [BsonId]
        [BsonRepresentation(BsonType.ObjectId)]
        public string? Id { get; set; }

        public string Name { get; set; } = null!;
        public string Contact { get; set; } = string.Empty;
        public string Address { get; set; } = string.Empty;
    }
}
