namespace CaseManagement.Settings
{
    public class MongoDBSettings
    {
        public MongoDbInfo DhakaDb { get; set; } = new();
        public MongoDbInfo BarishalDb { get; set; } = new();
    }

    public class MongoDbInfo
    {
        public string ConnectionString { get; set; } = string.Empty;
        public string DatabaseName { get; set; } = string.Empty;
    }
}
