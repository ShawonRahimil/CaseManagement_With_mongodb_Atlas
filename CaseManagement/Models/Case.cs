using MongoDB.Bson;
using MongoDB.Bson.Serialization.Attributes;

namespace CaseManagement.Models
{
    public class Case
    {
        [BsonId]
        [BsonRepresentation(BsonType.ObjectId)]
        public string? Id { get; set; }

        public string CaseName { get; set; } = null!;

        // Fragment key
        public string CaseType { get; set; } = null!; // "MurderCase" or "Churi"

        public string Description { get; set; } = string.Empty;

        public DateTime FiledDate { get; set; } = DateTime.UtcNow;
    }
}
