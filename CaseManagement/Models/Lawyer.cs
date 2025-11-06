using MongoDB.Bson;
using MongoDB.Bson.Serialization.Attributes;

namespace CaseManagement.Models
{
    public class Lawyer
    {
        [BsonId]
        [BsonRepresentation(BsonType.ObjectId)]
        public string? Id { get; set; }

        public string Name { get; set; } = null!;
        public string Specialization { get; set; } = string.Empty;
        public int ExperienceYears { get; set; }
    }
}
