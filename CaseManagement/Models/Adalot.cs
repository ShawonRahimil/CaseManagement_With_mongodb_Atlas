using MongoDB.Bson;
using MongoDB.Bson.Serialization.Attributes;

namespace CaseManagement.Models
{
    public class Adalot
    {
        [BsonId]
        [BsonRepresentation(BsonType.ObjectId)]
        public string? Id { get; set; }

        public string Name { get; set; } = null!;

        // Fragment key
        public string Location { get; set; } = null!; // "Dhaka" or "Barishal"
    }
}
