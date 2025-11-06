using MongoDB.Bson;
using MongoDB.Bson.Serialization.Attributes;

namespace CaseManagement.Models
{
    public class Section
    {
        [BsonId]
        [BsonRepresentation(BsonType.ObjectId)]
        public string? Id { get; set; }

        public string SectionName { get; set; } = null!;
        public string Description { get; set; } = string.Empty;
    }
}
